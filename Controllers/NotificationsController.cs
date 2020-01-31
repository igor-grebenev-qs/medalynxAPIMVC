using System;
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
        public ActionResult<List<Notification>> GetAll() {
            return Program.MedialynxData.notificationDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Notification> GetById(string id)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Notification> notifications = Program.MedialynxData.notificationDBAPI.Get(sid);
            if (notifications.Count != 1)
            {
                return NotFound();
            }

            return notifications[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Notification> Create(Notification notification)
        {
            Guid id = Utils.ToGuid(notification.Id, false);
            notification.CreationDate = DateTime.UtcNow;
            notification.LastUpdate = notification.CreationDate;
            if (id == Guid.Empty) {
                notification.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.notificationDBAPI.Add(notification);
                return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Notification> Update(Notification notification)
        {
            Guid id = Utils.ToGuid(notification.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            notification.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.notificationDBAPI.Update(notification);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
