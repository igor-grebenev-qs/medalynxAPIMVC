using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using Microsoft.Extensions.Primitives;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class ProjectsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Project>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            return Program.MedialynxData.projectDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Project> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Project> projects = Program.MedialynxData.projectDBAPI.Get(sid);
            if (projects.Count != 1)
            {
                return NotFound("Projects count is " + projects.Count + ". Await 1 object.");
            }

            return projects[0]; // projects count must equal 1
        }

        [HttpGet("AllByTeam/{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Project>> GetAllByTeamId(string teamId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(teamId, false).ToString("B");
            return Program.MedialynxData.projectDBAPI.GetAllByTeam(sid);
        }

        /// </summary>
        /// <param name="Project object"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Project> Create(Project project)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            project.Id = Guid.NewGuid().ToString("B");

            // setup dates
            project.CreationDate = DateTime.UtcNow;
            project.LastUpdate = project.CreationDate;

            if (String.IsNullOrEmpty(project.TeamId)) {
                // Create team
                TeamAPI teamApi = new TeamAPI(){
                    Name = "Default Team",
                    Details = "Autocreated",
                    UserId = sessionUserId
                };
                Team team = TeamController.CreateTeam(sessionUserId, sessionUserId, teamApi);

                project.TeamId = team.Id;
            }

            // create project
            Program.MedialynxData.projectDBAPI.Add(project);

            
            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    project.Id,
                    this.GetType().ToString(),
                    "Create project called with data: " + JsonSerializer.Serialize(project)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Project> Update(Project project)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(project.Id, false);
            if (id == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            project.LastUpdate = DateTime.UtcNow;
            // update project
            Program.MedialynxData.projectDBAPI.Update(project);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    project.Id,
                    this.GetType().ToString(),
                    "Update project called with data: " + JsonSerializer.Serialize(project)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("AllByTeam/{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
