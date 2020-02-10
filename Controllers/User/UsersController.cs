﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;
using medalynxAPIMVC.Notifications;
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
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            return Program.MedialynxData.userDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string id)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

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
            if (!Utils.ValidateSession(this.Request.Headers)) { return; }

            string sid = Utils.ToGuid(sessionId, false).ToString("B");
            Program.MedialynxData.sessionDBAPI.Delete(sid);
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

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CredentialsInfo> Login(Credentials credentials)
        {
            #pragma warning disable 4014
            //EmailService.SendEmailOauth2Async(credentials.UserEmail, "login success", "google test");
            #pragma warning restore 4014
            User user = Program.MedialynxData.userDBAPI.GetByEmail(credentials.UserEmail);
            if (user == null) {
                return NotFound();
            }
            if (user.Password == credentials.Password) { // OK!!!
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
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Create(User user)
        {
            Guid id = Utils.ToGuid(user.Id, false);
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

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Update(User user)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            Guid id = Utils.ToGuid(user.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            user.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.userDBAPI.Update(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("Login")]
        [HttpOptions("Logout/{sessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
