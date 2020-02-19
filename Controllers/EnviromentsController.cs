using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("Environments")]
    public class EnvironmentsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Models.Environment>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            return Program.MedialynxData.environmentDBAPI.GetByUser();
        }

        [HttpGet("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Models.Environment> GetById(string userId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            string sid = Utils.ToGuid(userId, false).ToString("B");
            List<Models.Environment> environments = Program.MedialynxData.environmentDBAPI.GetByUser(sid);
            if (environments.Count != 1)
            {
                return NotFound();
            }

            return environments[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Models.Environment> Create(Models.Environment environment)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid id = Utils.ToGuid(environment.Id, false);
            environment.CreationDate = DateTime.UtcNow;
            environment.LastUpdate = environment.CreationDate;
            if (id == Guid.Empty) {
                environment.Id = Guid.NewGuid().ToString("B");
            }
            Program.MedialynxData.environmentDBAPI.Add(environment);

            Notification notification = new Notification();
            notification.Id = Guid.NewGuid().ToString("B");
            notification.UserId = sessionUserId;
            notification.Message = "Environment created";
            notification.NotificationType = 1;
            notification.Status = NotificationStatus.Created;
            notification.CreationDate = DateTime.UtcNow;
            notification.LastUpdate = notification.CreationDate;
            Program.MedialynxData.notificationDBAPI.Add(notification);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    this.GetType().ToString(),
                    "Create environment called with data:" + JsonSerializer.Serialize(environment)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = environment.Id }, environment);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Models.Environment> Update(Models.Environment environment)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid id = Utils.ToGuid(environment.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            Program.MedialynxData.environmentDBAPI.Update(environment);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    this.GetType().ToString(),
                    "Update environment called with data:" + JsonSerializer.Serialize(environment)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = environment.Id }, environment);
        }

        [HttpPut("Archive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Models.Environment> Archive(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid environmentId = Utils.ToGuid(id, false);
            if (environmentId == Guid.Empty) {
                return BadRequest();
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Models.Environment environment = Program.MedialynxData.environmentDBAPI.Get(sid);
            if (environment == null)
            {
                return NotFound();
            }

            if (environment.Status != ObjectStatus.Default) {
                return BadRequest("You can't archive current environment");
            }

            environment.Status = ObjectStatus.Archived;

            Program.MedialynxData.environmentDBAPI.Update(environment);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    this.GetType().ToString(),
                    "Archive environment called with id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = environment.Id }, environment);
        }

        [HttpPut("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Models.Environment> MarkDeleted(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid environmentId = Utils.ToGuid(id, false);
            if (environmentId == Guid.Empty) {
                return BadRequest();
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Models.Environment environment = Program.MedialynxData.environmentDBAPI.Get(sid);
            if (environment == null)
            {
                return NotFound();
            }

            if (environment.Status != ObjectStatus.Default) {
                return BadRequest("You can't delete current environment");
            }

            environment.Status = ObjectStatus.Deleted;

            Program.MedialynxData.environmentDBAPI.Update(environment);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    this.GetType().ToString(),
                    "Delete (mark as deleted) environment called with id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = environment.Id }, environment);
        }

        [HttpOptions]
        [HttpOptions("ByUser/{userId}")]
        [HttpOptions("Archive/{id}")]
        [HttpOptions("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
