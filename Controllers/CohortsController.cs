using System;
using System.Collections.Generic;
using System.Text.Json;
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
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            return Program.MedialynxData.cohortDBAPI.Get();
        }

        [NonAction]
        private CohortRepresentation GetCohortRepresentation(Cohort cohort) {
            CohortRepresentation cohortRepresentation = new CohortRepresentation(cohort);
            // get all alive links for cohort
            cohortRepresentation.CohortEnumLinks = Program.MedialynxData.cohortEnumLinkDBAPI.GetLinksByCohort(cohort.Id);
            return cohortRepresentation;
        }

        /*
        [HttpDelete("{cohortId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> RemoveCohort(string cohortId) {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    cohortId,
                    this.GetType().ToString(),
                    "Remove (real deletion) cohort called with id=" + cohortId
                )
            );

            return Program.MedialynxData.cohortDBAPI.Remove(cohortId);
        }
        */

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortRepresentation> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound("Cohort count is " + cohorts.Count + ". Await 1 object.");
            }

            return this.GetCohortRepresentation(cohorts[0]);
        }

        [HttpGet("ByProject/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortRepresentation> GetByProjectId(string projectId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            StringValues requestTypeHeaders;

            this.Request.Headers.TryGetValue("Not-Rejected", out requestTypeHeaders);
            bool notRejected = requestTypeHeaders.Count > 0;

            string sid = Utils.ToGuid(projectId, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetFirstByProject(sid, notRejected);
            if (cohort == null)
            {
                return NotFound();
            }

            return this.GetCohortRepresentation(cohort);
        }

        [HttpGet("AllByProject/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cohort>> GetAllByProjectId(string projectId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(projectId, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.GetAllByProject(sid);
            if (cohorts.Count == 0)
            {
                return NotFound();
            }

            return cohorts;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CohortRepresentation> Create(CohortAPI cohortApi)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            // validate links
            foreach (var link in cohortApi.cohortEnumLinks) {
                bool enumItemIdDefined = link.EnumItemId != null && link.EnumItemId != "";
                if (Utils.IsEmpty(link.enumItem) && !enumItemIdDefined) {
                    return BadRequest("enumItem and enumItemIdDefined can't be null at same time.");
                }
                if (!Utils.IsEmpty(link.enumItem) && enumItemIdDefined) {
                    return BadRequest("enumItem and enumItemIdDefined can't be initialized at same time.");
                }
            }
            // validate that cohort is not exists
            Cohort existsCohort = Program.MedialynxData.cohortDBAPI.GetFirstByProject(cohortApi.ProjectId);
            if (existsCohort != null) {
                return BadRequest("Cohort already exists"); // cohort already exists. Please use update.
            }

            cohortApi.Id = Guid.NewGuid().ToString("B");

            // setup cohort
            Cohort cohort = new Cohort();
            cohort.Id = cohortApi.Id;
            cohort.ProjectId = cohortApi.ProjectId;
            cohort.NumberOfSubjectsRequired = cohortApi.NumberOfSubjectsRequired;
            cohort.CohortType = cohortApi.CohortType;
            cohort.RequestAdmin = cohortApi.RequestAdmin;
            cohort.RequestUser = cohortApi.RequestUser;
            cohort.CreationDate = DateTime.UtcNow;
            cohort.LastUpdate = cohort.CreationDate;
            // create cohort
            Program.MedialynxData.cohortDBAPI.Add(cohort);
            // create cohort links (necessary enum items will be created with link)
            Program.MedialynxData.cohortEnumLinkDBAPI.CreateLinks(cohort.Id, cohortApi.cohortEnumLinks);

            Program.MedialynxData.notificationDBAPI.Add(
                sessionUserId,
                cohortApi.ProjectId,
                "Cohort created",
                NotificationType.Cohort,
                ObjectStatus.Undefined,
                ObjectStatus.Undefined,
                RequestType.Created
            );

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    cohort.Id,
                    this.GetType().ToString(),
                    "Create cohort called with data: " + JsonSerializer.Serialize(cohortApi)
                )
            );

            // reload and alive cohort
            string sid = Utils.ToGuid(cohort.Id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }

            return this.GetCohortRepresentation(cohorts[0]);
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
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(cohortApi.Id, false);
            if (id == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            // setup cohort
            Cohort cohort = new Cohort();
            cohort.Id = cohortApi.Id;
            cohort.ProjectId = cohortApi.ProjectId;
            cohort.NumberOfSubjectsRequired = cohortApi.NumberOfSubjectsRequired;
            cohort.CohortType = cohortApi.CohortType;
            cohort.RequestAdmin = cohortApi.RequestAdmin;
            cohort.RequestUser = cohortApi.RequestUser;
            cohort.LastUpdate = DateTime.UtcNow;
            // update cohort
            Program.MedialynxData.cohortDBAPI.Update(cohort);
            // update/create/delete cohort links (neccessary enum items will be created with link)
            Program.MedialynxData.cohortEnumLinkDBAPI.UpdateLinks(cohort.Id, cohortApi.cohortEnumLinks);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    cohort.Id,
                    this.GetType().ToString(),
                    "Update cohort called with data: " + JsonSerializer.Serialize(cohortApi)
                )
            );

            // reload and alive cohort
            string sid = Utils.ToGuid(cohort.Id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }
            return this.GetCohortRepresentation(cohorts[0]);

        }

        [HttpPut("RequestType/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> UpdateRequestType(string id, RequestTypeAPI requestType)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Cohort id is not valid (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound("Cohort with id=" + sid + " not found");
            }

            if ((int)cohort.RequestType != requestType.RequestType) {
                cohort.RequestType = (ObjectStatus) requestType.RequestType;

                Program.MedialynxData.cohortDBAPI.Update(cohort);

                Program.MedialynxData.notificationDBAPI.Add(
                    sessionUserId,
                    cohort.ProjectId,
                    "Cohort request type changed",
                    NotificationType.Cohort,
                    ObjectStatus.Undefined,
                    cohort.RequestType,
                    RequestType.Undefined
                );

                Program.MedialynxData.historyDBAPI.Add(
                    new HistoryItem(
                        sessionUserId,
                        sid,
                        this.GetType().ToString(),
                        "Cohort RequestType was updated. id: " + id
                    )
                );
            }

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("Status/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> UpdateStatus(string id, StatusAPI status)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Cohort id is not valid (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound("Cohort with id=" + sid + " not found");
            }

            if ((int)cohort.Status != status.Status) {
                cohort.Status = (ObjectStatus) status.Status;

                Program.MedialynxData.cohortDBAPI.Update(cohort);

                Program.MedialynxData.notificationDBAPI.Add(
                    sessionUserId,
                    cohort.ProjectId,
                    "Cohort status changed",
                    NotificationType.Cohort,
                    cohort.Status,
                    ObjectStatus.Undefined,
                    RequestType.Undefined
                );

                Program.MedialynxData.historyDBAPI.Add(
                    new HistoryItem(
                        sessionUserId,
                        sid,
                        this.GetType().ToString(),
                        "Cohort Status was updated. id: " + id
                    )
                );
            }
            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("AllByProject/{projectId}")]
        [HttpOptions("ByProject/{projectId}")]
        [HttpOptions("RequestType/{id}")]
        [HttpOptions("Status/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
