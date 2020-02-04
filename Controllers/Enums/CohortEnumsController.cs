using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers.Enums
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class CohortEnumsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CohortEnums>> GetAll()
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            return Program.MedialynxData.cohortEnumsDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortEnums> GetById(string id)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<CohortEnums> items = Program.MedialynxData.cohortEnumsDBAPI.Get(sid);
            if (items.Count != 1)
            {
                return NotFound();
            }

            return items[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortEnums> Create(CohortEnums item)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            Guid id = Utils.ToGuid(item.Id, false);
            if (id == Guid.Empty) {
                item.Id = Guid.NewGuid().ToString("B");
            }
            Program.MedialynxData.cohortEnumsDBAPI.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
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
