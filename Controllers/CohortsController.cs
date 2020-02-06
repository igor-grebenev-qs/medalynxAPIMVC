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
        public ActionResult<List<Cohort>> GetAll()
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            return Program.MedialynxData.cohortDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cohort> GetById(string id)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }

            return cohorts[0];
        }

        /// <summary>
        /* Object sample
            {
                "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
                "numberOfSubjectsRequired": 1,
                "cohortType": "unknown",
                "request": 0,
                "cohortEnumLinks": [
                    {
                        "cohortEnumId": "{cc77ecca-8279-4c9d-b321-064ba492ba9e}",
                        "enumItemId": null,
                        "include": 0,
                        "percentage": 0,
                        "numberOfSubjects": 0,
                        "enumItem":
                            {
                                "stageOfTumour": 3,
                                "numberOfNodesAffected": 6,
                                "numberOfMetastasis": 6
                            }
                    }
                ]
            }
        */
        /// </summary>
        /// <param name="cohort"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Create(CohortAPI cohortApi)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            cohortApi.Id = Guid.NewGuid().ToString("B");

            // setup cohort
            Cohort cohort = new Cohort();
            cohort.Id = cohortApi.Id;
            cohort.UserId = cohortApi.UserId;
            cohort.NumberOfSubjectsRequired = cohortApi.NumberOfSubjectsRequired;
            cohort.CohortType = cohortApi.CohortType;
            cohort.Request = cohortApi.Request;
            cohort.CreationDate = DateTime.UtcNow;
            cohort.LastUpdate = cohort.CreationDate;
            // create cohort
            Program.MedialynxData.cohortDBAPI.Add(cohort);
            // create cohort links (neccessary enum items will be created with link)
            Program.MedialynxData.cohortEnumLinkDBAPI.CreateLinks(cohort.Id, cohortApi.cohortEnumLinks);

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Update(CohortAPI cohortApi)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            Guid id = Utils.ToGuid(cohortApi.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }

            // setup cohort
            Cohort cohort = new Cohort();
            cohort.Id = cohortApi.Id;
            cohort.UserId = cohortApi.UserId;
            cohort.NumberOfSubjectsRequired = cohortApi.NumberOfSubjectsRequired;
            cohort.CohortType = cohortApi.CohortType;
            cohort.Request = cohortApi.Request;
            cohort.LastUpdate = DateTime.UtcNow;
            // update cohort
            Program.MedialynxData.cohortDBAPI.Update(cohort);
            // update/create/delete cohort links (neccessary enum items will be created with link)
            Program.MedialynxData.cohortEnumLinkDBAPI.UpdateLinks(cohort.Id, cohortApi.cohortEnumLinks);

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
