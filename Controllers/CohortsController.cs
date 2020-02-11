using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
using Microsoft.Extensions.Primitives;

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
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            return Program.MedialynxData.cohortDBAPI.Get();
        }

        [NonAction]
        private CohortRepresentation GetCohortRepresentation(Cohort cohort) {
            CohortRepresentation cohortRepresentation = new CohortRepresentation(cohort);
            // get all alive links for cohort
            cohortRepresentation.CohortEnumLinks = Program.MedialynxData.cohortEnumLinkDBAPI.GetLinksByCohort(cohort.Id);
            return cohortRepresentation;
        }

        [HttpDelete("{cohortId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> RemoveCohort(string cohortId) {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }
            Program.MedialynxData.historyDBAPI.Add(new HistoryItem(sessionUserId, this.GetType().ToString(), "Remove cohort called with id=" + cohortId));

            return Program.MedialynxData.cohortDBAPI.Remove(cohortId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortRepresentation> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }

            return this.GetCohortRepresentation(cohorts[0]);
        }

        [HttpGet("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortRepresentation> GetByUserId(string userId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            StringValues requestTypeHeaders;

            this.Request.Headers.TryGetValue("Request-Type", out requestTypeHeaders);
            RequestType requestType = (RequestType)((requestTypeHeaders.Count == 0) ? 0 : Int32.Parse(requestTypeHeaders[0]));

            string sid = Utils.ToGuid(userId, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetByUser(sid, requestType);
            if (cohort == null)
            {
                return NotFound();
            }

            return this.GetCohortRepresentation(cohort);
        }

        /// <summary>
        /* Object sample (CohortAPI)
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
        /// <param name="CohortAPI object"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Create(CohortAPI cohortApi)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

            // validate links
            foreach (var link in cohortApi.cohortEnumLinks) {
                if (Utils.IsEmpty(link.enumItem) && link.EnumItemId == "") {
                    return BadRequest();
                }
            }
            // validate that cohort is not exists
            Cohort existsCohort = Program.MedialynxData.cohortDBAPI.GetByUser(cohortApi.UserId, RequestType.Any);
            if (existsCohort != null) {
                return BadRequest(); // cohort already exists. Please use update.
            }

            cohortApi.Id = Guid.NewGuid().ToString("B");

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    this.GetType().ToString(),
                    "Create cohort called with data:" + JsonSerializer.Serialize(cohortApi)
                )
            );

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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortRepresentation> Update(CohortAPI cohortApi)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest(); }

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

            // reload and alive cohort
            string sid = Utils.ToGuid(cohort.Id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }
            return this.GetCohortRepresentation(cohorts[0]);

        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
