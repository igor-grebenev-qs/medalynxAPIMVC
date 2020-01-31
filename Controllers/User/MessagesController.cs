using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class MessagesController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Message>> GetAll() {
            return Program.MedialynxData.messageDBAPI.GetByUser();
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Message>> GetById(string userId)
        {
            string sid = Utils.ToGuid(userId, false).ToString("B");
            return Program.MedialynxData.messageDBAPI.GetByUser(sid);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Message> Create(Message message)
        {
            Guid id = Utils.ToGuid(message.Id, false);
            message.CreationDate = DateTime.UtcNow;
            if (id == Guid.Empty) {
                message.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.messageDBAPI.Add(message);
                return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
            }
            return BadRequest();
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
