using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class CohortEnumLinkController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CohortEnumLink>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            return Program.MedialynxData.cohortEnumLinkDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortEnumLink> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<CohortEnumLink> links = Program.MedialynxData.cohortEnumLinkDBAPI.Get(sid);
            if (links.Count != 1)
            {
                return NotFound();
            }

            return links[0];
        }

        [HttpGet("CohortId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CohortEnumLinkRepresentation>> GetByCohortId(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<CohortEnumLinkRepresentation> links = Program.MedialynxData.cohortEnumLinkDBAPI.GetLinksByCohort(sid);

            return links;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortEnumLink> Create(CohortEnumLink link)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid id = Utils.ToGuid(link.Id, false);
            link.CreationDate = DateTime.UtcNow;
            link.LastUpdate = link.CreationDate;
            if (id == Guid.Empty) {
                link.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.cohortEnumLinkDBAPI.Add(link);
                return CreatedAtAction(nameof(GetById), new { id = link.Id }, link);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortEnumLink> Update(CohortEnumLink link)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            Guid id = Utils.ToGuid(link.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            link.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.cohortEnumLinkDBAPI.Update(link);
            return CreatedAtAction(nameof(GetById), new { id = link.Id }, link);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("CohortId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
