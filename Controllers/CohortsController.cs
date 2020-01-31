using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class CohortsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Cohort>> GetAll() {
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get();
            return cohorts;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cohort> GetById(string id)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }

            return cohorts[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Create(Cohort cohort)
        {
            Guid id = Utils.ToGuid(cohort.Id, false);
            cohort.CreationDate = DateTime.UtcNow;
            cohort.LastUpdate = cohort.CreationDate;
            if (id == Guid.Empty) {
                cohort.Id = Guid.NewGuid().ToString("B");
                // create all options
                Program.MedialynxData.cohortEnumLinkDBAPI.GenerateCohortEnumLinks(cohort.Id);
                Program.MedialynxData.cohortDBAPI.AddCohort(cohort);
                return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Update(Cohort cohort)
        {
            Guid id = Utils.ToGuid(cohort.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            cohort.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.cohortDBAPI.UpdateCohort(cohort);
            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
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
