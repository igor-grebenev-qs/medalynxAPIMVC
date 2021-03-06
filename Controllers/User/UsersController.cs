﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;
using medalynxAPI.Notifications;
using Microsoft.Extensions.Primitives;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class UsersController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<User>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            return Program.MedialynxData.userDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<User> users = Program.MedialynxData.userDBAPI.Get(sid);
            if (users.Count != 1)
            {
                return NotFound();
            }

            return users[0];
        }

        [HttpGet("Logout/{sessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Logout(string sessionId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return; }

            string sid = Utils.ToGuid(sessionId, false).ToString("B");
            Program.MedialynxData.sessionDBAPI.Delete(sid);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sessionId,
                    this.GetType().ToString(),
                    "Logout called data"
                )
            );
        }

        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> Me()
        {
            StringValues sessionIdHeaders;
            this.Request.Headers.TryGetValue("Session-Id", out sessionIdHeaders);
            if (sessionIdHeaders.Count == 0)
            {
                return NotFound();
            }
            string sid = Utils.ToGuid(sessionIdHeaders[0], false).ToString("B");
            return Program.MedialynxData.userDBAPI.GetBySession(sid);
        }

        private CredentialsInfo GetCredentialsInfo(User user) {
            // login success. Session required.
            Session existsSession = Program.MedialynxData.sessionDBAPI.GetByUser(user.Id);
            CredentialsInfo credentialsInfo = new CredentialsInfo();
            if (existsSession != null) { // session exists
                credentialsInfo.Session = existsSession;
            }
            else {
                Session newSession = new Session();
                newSession.Id = Guid.NewGuid().ToString("B");;
                newSession.UserId = user.Id;
                newSession.CreationDate = DateTime.UtcNow;
                newSession.LastUpdate = newSession.CreationDate;
                Program.MedialynxData.sessionDBAPI.Add(newSession);
                credentialsInfo.Session = newSession;
            }
            credentialsInfo.User = user;
            return credentialsInfo;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CredentialsInfo> Login(Credentials credentials)
        {
            User user = Program.MedialynxData.userDBAPI.GetByEmail(credentials.UserEmail);
            if (user == null) {
                return NotFound("User " + credentials.UserEmail + " not found.");
            }

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    user.Id,
                    user.Id,
                    this.GetType().ToString(),
                    "Try to login "  + credentials.UserEmail
                )
            );

            string passwordHash = Utils.GetHashString(credentials.Password);
            if (user.Password == passwordHash) { // OK!!!
                CredentialsInfo credentialsInfo = this.GetCredentialsInfo(user);
                Program.MedialynxData.historyDBAPI.Add(
                    new HistoryItem(
                        user.Id,
                        credentialsInfo.Session.Id,
                        this.GetType().ToString(),
                        "Login Success " + credentials.UserEmail
                    )
                );
                return credentialsInfo;
            }
            return null;
        }

        [HttpPost("Password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CredentialsInfo> ValidatePassword(Credentials credentials)
        {
            // validate password
            string passwordValidationMessage;
            if (!Utils.IsValidPassword(credentials.Password, out passwordValidationMessage)) {
                return BadRequest(new ValidationResult("password", passwordValidationMessage));
            }
            return Ok();
        }

        [HttpPost("Email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CredentialsInfo> ValidateEmail(Credentials credentials)
        {
            // validate email
            if (!Utils.IsValidEmail(credentials.UserEmail)) {
                return BadRequest(new ValidationResult("email", "Invalid email address"));
            }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserRepresentation> Create(User user)
        {
            // validate email
            if (!Utils.IsValidEmail(user.Email)) {
                return BadRequest(new ValidationResult("email", "Invalid email address"));
            }

            // validate password
            string passwordValidationMessage;
            if (!Utils.IsValidPassword(user.Password, out passwordValidationMessage)) {
                return BadRequest(new ValidationResult("password", passwordValidationMessage));
            }

            User existsUser = Program.MedialynxData.userDBAPI.GetByEmail(user.Email);
            if (user != null) {
                return BadRequest("User already exists with same email");
            }

            user.Password = Utils.GetHashString(user.Password); // to hash string

            Guid id = Utils.ToGuid(user.Id, false);
            user.Email = user.Email.ToLower(); // ensure that email does not contains uppercase
            user.CreationDate = DateTime.UtcNow;
            user.LastUpdate = user.CreationDate;
            if (id == Guid.Empty) {
                user.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.userDBAPI.Add(user);

                #pragma warning disable 4014
                EmailService.SendEmailAsync(
                    user.Email,
                    "Account created successfully",
                    "Account created successfully.");
                #pragma warning restore 4014
                UserRepresentation userRepresentation = new UserRepresentation(user);
                userRepresentation.CredentialsInfo = this.GetCredentialsInfo(user);

                Program.MedialynxData.historyDBAPI.Add(
                    new HistoryItem(
                        user.Id,
                        user.Id,
                        this.GetType().ToString(),
                        "User created successfully " + JsonSerializer.Serialize(userRepresentation)
                    )
                );

                return userRepresentation;
            }
            return BadRequest("User can't be created. Provided id (" + id + ")");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Update(User user)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(user.Id, false);
            if (id == Guid.Empty) {
                return BadRequest("User id is not valid (" + id + ")");
            }
            user.Password = String.IsNullOrEmpty(user.Password) ? null : Utils.GetHashString(user.Password);
            user.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.userDBAPI.Update(user);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    user.Id,
                    this.GetType().ToString(),
                    "Update user " + user.Email + " called"
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("Login")]
        [HttpOptions("Email")]
        [HttpOptions("Password")]
        [HttpOptions("Logout/{sessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
