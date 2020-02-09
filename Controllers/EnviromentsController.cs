using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("Environments")]
    public class EnviromentsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Enviroment>> GetAll()
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            return Program.MedialynxData.enviromentDBAPI.GetByUser();
        }

        [HttpGet("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Enviroment> GetById(string userId)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            string sid = Utils.ToGuid(userId, false).ToString("B");
            List<Enviroment> enviroments = Program.MedialynxData.enviromentDBAPI.GetByUser(sid);
            if (enviroments.Count != 1)
            {
                return NotFound();
            }

            return enviroments[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Enviroment> Create(Enviroment enviroment)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            Guid id = Utils.ToGuid(enviroment.Id, false);
            enviroment.CreationDate = DateTime.UtcNow;
            enviroment.LastUpdate = enviroment.CreationDate;
            if (id == Guid.Empty) {
                enviroment.Id = Guid.NewGuid().ToString("B");
            }
            Program.MedialynxData.enviromentDBAPI.Add(enviroment);
            return CreatedAtAction(nameof(GetById), new { id = enviroment.Id }, enviroment);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Enviroment> Update(Enviroment enviroment)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            Guid id = Utils.ToGuid(enviroment.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            Program.MedialynxData.enviromentDBAPI.Update(enviroment);
            return CreatedAtAction(nameof(GetById), new { id = enviroment.Id }, enviroment);
        }

        [HttpOptions]
        [HttpOptions("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
