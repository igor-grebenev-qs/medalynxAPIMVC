using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Enums;

namespace MedalynxAPI.Controllers.Enums
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class CohortEnumsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CohortEnums>> GetAll() {
            return Program.MedialynxData.cohortEnumsDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortEnums> GetById(string id)
        {
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
