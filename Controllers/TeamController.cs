using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class TeamController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Team>> GetAll()
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            return Program.MedialynxData.teamDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Team> GetById(string id)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Team> teams = Program.MedialynxData.teamDBAPI.Get(sid);
            if (teams.Count != 1)
            {
                return NotFound("Teams count is " + teams.Count + ". Await 1 object.");
            }

            return teams[0]; // teams count must equal 1
        }

        [HttpGet("TeamUsers/{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<User>> GetTeamUsers(string teamId)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            string sid = Utils.ToGuid(teamId, false).ToString("B");
            return Program.MedialynxData.teamDBAPI.GetTeamUsers(teamId);
        }

        [HttpPut("AddUser/{teamId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TeamUserLink> AddUser(string teamId, TeamUserLinkAPI request)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(teamId, false);
            if (id == Guid.Empty) {
                return BadRequest("Team id is not valid (" + teamId + ")");
            }

            id = Utils.ToGuid(request.UserId, false);
            if (id == Guid.Empty) {
                return BadRequest("User id is not valid (" + request.UserId + ")");
            }

            TeamUserLink link = Program.MedialynxData.teamDBAPI.AddUserToTeam(sessionUserId, teamId, request.UserId);

            return new ActionResult<TeamUserLink>(link);
        }

        [HttpPut("RemoveUser/{teamId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TeamUserLink> RemoveUser(string teamId, TeamUserLinkAPI request)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(teamId, false);
            if (id == Guid.Empty) {
                return BadRequest("Team id is not valid (" + teamId + ")");
            }

            id = Utils.ToGuid(request.UserId, false);
            if (id == Guid.Empty) {
                return BadRequest("User id is not valid (" + request.UserId + ")");
            }

            TeamUserLink link = Program.MedialynxData.teamDBAPI.DeleteUserFromTeam(teamId, request.UserId);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    link.Id,
                    this.GetType().ToString(),
                    "User removed from team with id: " + teamId + " <- (" + request.UserId + ")"
                )
            );
            return new ActionResult<TeamUserLink>(link);
        }

        internal static Team CreateTeam(string sessionUserId, string ownerUserId, TeamAPI teamApi) {
            Team team = new Team(teamApi);
            team.Id = Guid.NewGuid().ToString("B");

            // setup dates
            team.CreationDate = DateTime.UtcNow;
            team.LastUpdate = team.CreationDate;

            // create team
            Program.MedialynxData.teamDBAPI.Add(team);
            Program.MedialynxData.teamDBAPI.AddUserToTeam(sessionUserId, team.Id, ownerUserId, "OWNER");
            
            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    team.Id,
                    typeof(TeamController).ToString(),
                    "Create team called with data: " + JsonSerializer.Serialize(team)
                )
            );
            return team;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Team> Create(TeamAPI teamApi)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }


            Team team = CreateTeam(sessionUserId, teamApi.UserId, teamApi);

            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Team> Update(Team team)
        {
            // validate that session exists
            string sessionUserId;
            if (!Utils.ValidateSession(this.Request.Headers, out sessionUserId)) { return BadRequest("Session does not exists."); }

            Guid id = Utils.ToGuid(team.Id, false);
            if (id == Guid.Empty) {
                return BadRequest("Invalid id (" + id + ")");
            }

            team.LastUpdate = DateTime.UtcNow;
            // update team
            Program.MedialynxData.teamDBAPI.Update(team);

            Program.MedialynxData.historyDBAPI.Add(
                new HistoryItem(
                    sessionUserId,
                    team.Id,
                    this.GetType().ToString(),
                    "Update team called with data: " + JsonSerializer.Serialize(team)
                )
            );

            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [HttpOptions("TeamUsers/{teamId}")]
        [HttpOptions("AddUser/{teamId}")]
        [HttpOptions("RemoveUser/{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.Environment> Options()
        {
            return Ok();
        }
    }
}
