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

        [HttpGet("ByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CohortRepresentation> GetByUserId(string userId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            StringValues requestTypeHeaders;

            this.Request.Headers.TryGetValue("Not-Rejected", out requestTypeHeaders);
            bool notRejected = requestTypeHeaders.Count > 0;

            string sid = Utils.ToGuid(userId, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetFirstByUser(sid, notRejected);
            if (cohort == null)
            {
                return NotFound();
            }

            return this.GetCohortRepresentation(cohort);
        }

        [HttpGet("AllByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cohort>> GetAllByUserId(string userId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(userId, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.GetAllByUser(sid);
            if (cohorts.Count == 0)
            {
                return NotFound();
            }

            return cohorts;
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
            Cohort existsCohort = Program.MedialynxData.cohortDBAPI.GetFirstByUser(cohortApi.UserId);
            if (existsCohort != null) {
                return BadRequest("Cohort already exists"); // cohort already exists. Please use update.
            }

            cohortApi.Id = Guid.NewGuid().ToString("B");

            // setup cohort
            Cohort cohort = new Cohort();
            cohort.Id = cohortApi.Id;
            cohort.UserId = cohortApi.UserId;
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

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    cohort.Id,
                    this.GetType().ToString(),
                    "Create cohort called with data:" + JsonSerializer.Serialize(cohortApi)
                )
            );

            // reload and alive cohort
            string sid = Utils.ToGuid(cohort.Id, false).ToString("B");
            List<Cohort> cohorts = Program.MedialynxData.cohortDBAPI.Get(sid);
            if (cohorts.Count != 1)
            {
                return NotFound();
            }

            Notification notification = new Notification();
            notification.Id = Guid.NewGuid().ToString("B");
            notification.UserId = sessionUserId;
            notification.Message = "Cohort created";
            notification.NotificationType = 0;
            notification.Status = NotificationStatus.Created;
            notification.CreationDate = DateTime.UtcNow;
            notification.LastUpdate = notification.CreationDate;
            Program.MedialynxData.notificationDBAPI.Add(notification);

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
            cohort.UserId = cohortApi.UserId;
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
                    "Update cohort called with data:" + JsonSerializer.Serialize(cohortApi)
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

        [HttpPut("Archive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> Archive(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            if (cohort.Status != ObjectStatus.Default) {
                return BadRequest("You can't archive current cohort");
            }

            cohort.Status = ObjectStatus.Archived;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Archive cohort called with id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> MarkDeleted(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            if (cohort.Status != ObjectStatus.Default) {
                return BadRequest("You can't delete current cohort");
            }

            cohort.Status = ObjectStatus.Deleted;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Delete (mark as deleted) cohort called with id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("ApproveAdmin/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> ApproveAdmin(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            cohort.RequestAdmin = RequestType.Approved;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Cohort approved by admin. id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("ApproveUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> ApproveUser(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            cohort.RequestUser = RequestType.Approved;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Cohort approved by user. id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("RejectAdmin/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> RejectAdmin(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            cohort.RequestAdmin = RequestType.Rejected;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Cohort rejected by admin. id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpPut("RejectUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cohort> RejectUser(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid cohortId = Utils.ToGuid(id, false);
            if (cohortId == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            string sid = Utils.ToGuid(id, false).ToString("B");
            Cohort cohort = Program.MedialynxData.cohortDBAPI.GetById(sid);
            if (cohort == null)
            {
                return NotFound();
            }

            cohort.RequestUser = RequestType.Rejected;

            Program.MedialynxData.cohortDBAPI.Update(cohort);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    sid,
                    this.GetType().ToString(),
                    "Cohort rejected by user. id: " + id
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
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
                return NotFound();
            }

            if ((int)cohort.RequestType != requestType.RequestType) {
                cohort.RequestType = (DeletionArchiveRequestType) requestType.RequestType;

                Program.MedialynxData.cohortDBAPI.Update(cohort);

                Program.MedialynxData.historyDBAPI.Add(
                    new HistoryItem(
                        sessionUserId,
                        sid,
                        this.GetType().ToString(),
                        "Cohort RequestType updated. id: " + id
                    )
                );
            }
            return CreatedAtAction(nameof(GetById), new { id = cohort.Id }, cohort);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("AllByUser/{userId}")]
        [HttpOptions("ByUser/{userId}")]
        [HttpOptions("Archive/{id}")]
        [HttpOptions("Delete/{id}")]
        [HttpOptions("ApproveAdmin/{id}")]
        [HttpOptions("ApproveUser/{id}")]
        [HttpOptions("RejectAdmin/{id}")]
        [HttpOptions("RejectUser/{id}")]
        [HttpOptions("RequestType/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
