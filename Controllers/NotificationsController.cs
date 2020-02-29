using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class NotificationsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Notification>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            return Program.MedialynxData.notificationDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Notification> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Notification> notifications = Program.MedialynxData.notificationDBAPI.Get(sid);
            if (notifications.Count != 1)
            {
                return NotFound();
            }

            return notifications[0];
        }

        [HttpGet("ByProject/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Notification>> GetByProject(string projectId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(projectId, false).ToString("B");
            List<Notification> notifications = Program.MedialynxData.notificationDBAPI.GetByProject(sid);

            return notifications;
        }

        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Notification> Create(Notification notification)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(notification.Id, false);
            notification.CreationDate = DateTime.UtcNow;
            notification.LastUpdate = notification.CreationDate;
            if (id == Guid.Empty) {
                notification.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.notificationDBAPI.Add(notification);
                return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
            }
            return BadRequest("Notification can't be created. Invalid id (" + id + ")");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Notification> Update(Notification notification)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(notification.Id, false);
            if (id == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }
            notification.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.notificationDBAPI.Update(notification);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    notification.Id,
                    this.GetType().ToString(),
                    "Update notification called with data: " + JsonSerializer.Serialize(notification)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }
        */

        [HttpPut("Processed/{notificationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Notification> Processed(string notificationId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(notificationId, false);
            if (id == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }
            var notifications = Program.MedialynxData.notificationDBAPI.Get(notificationId);
            Notification forUpdate = notifications[0];
            forUpdate.Processing = 1;
            forUpdate.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.notificationDBAPI.Update(forUpdate);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    notificationId,
                    this.GetType().ToString(),
                    "Processed notification called id: " + notificationId
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = notificationId }, forUpdate);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("ByProject/{projectId}")]
        [HttpOptions("Processed/{notificationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
