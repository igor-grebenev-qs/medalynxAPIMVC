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
    public class CohortEnumLinkController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CohortEnumLink>> GetAll() {
            List<CohortEnumLink> links = Program.MedialynxData.cohortEnumLinkDBAPI.GetLink();
            return links;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortEnumLink> GetById(string id)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<CohortEnumLink> links = Program.MedialynxData.cohortEnumLinkDBAPI.GetLink(sid);
            if (links.Count != 1)
            {
                return NotFound();
            }

            return links[0];
        }

        [HttpGet("CohortId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortEnumLink> GetByCohortId(string id)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            CohortEnumLink link = Program.MedialynxData.cohortEnumLinkDBAPI.GetLinkByCohort(sid);
            if (link == null)
            {
                return NotFound();
            }

            return link;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortEnumLink> Create(CohortEnumLink link)
        {
            Guid id = Utils.ToGuid(link.Id, false);
            link.CreationDate = DateTime.UtcNow;
            link.LastUpdate = link.CreationDate;
            if (id == Guid.Empty) {
                link.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.cohortEnumLinkDBAPI.AddCohortEnumLink(link);
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
            Guid id = Utils.ToGuid(link.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            link.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.cohortEnumLinkDBAPI.UpdateCohortEnumLink(link);
            return CreatedAtAction(nameof(GetById), new { id = link.Id }, link);
        }
    }
}
