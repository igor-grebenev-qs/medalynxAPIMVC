using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;
using MedalynxAPI.Models.User;
using Microsoft.Extensions.Primitives;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpGet("{enumId}/values")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<object>> GetEnumValues(string enumId)
        {
            // validate that session exists
            if (!Utils.ValidateSession(this.Request.Headers)) { return BadRequest(); }

            StringValues filterHeaders;
            this.Request.Headers.TryGetValue("Filter", out filterHeaders);

            string sid = Utils.ToGuid(enumId, false).ToString("B");
            List<CohortEnums> items = Program.MedialynxData.cohortEnumsDBAPI.Get(sid);
            if (items.Count != 1)
            {
                return NotFound(); // Enum not found
            }
            switch (sid) {
                case CohortEnumsDictionary.DeseaseStates:
                    return Program.MedialynxData.deseaseStatesDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.GeneticMatches:
                    return Program.MedialynxData.geneticMatchesDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.Biomarkers:
                    return Program.MedialynxData.biomarkersDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.Demographics:
                    return Program.MedialynxData.demographicsDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.Ethnicitys:
                    return Program.MedialynxData.ethnicitysDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.StageOfDeseases:
                    return Program.MedialynxData.stageOfDeseasesDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.Prognosis:
                    return Program.MedialynxData.prognosisDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
                case CohortEnumsDictionary.PreviousTreatments:
                    return Program.MedialynxData.previousTreatmentsDBAPI.Get(filterHeaders.Count > 0 ? filterHeaders[0] : "");
            }
            return null;
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("{enumId}/values")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
