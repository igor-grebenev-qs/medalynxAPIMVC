using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;

namespace MedalynxAPI
{
    public class TeamDBAPI
    {
        // Get team by id
        public Team GetById(string teamId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(teamId, false);
            if (id == Guid.Empty) {
                return null;
            }

            using (var dbContext = new MedialynxDbTeamContext()) {
                string sid = id.ToString("B");
                return dbContext.Teams.FirstOrDefault(team => team != null && team.Id == sid);
            }
        }

        public List<Team> Get(string teamId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(teamId);
            List<Team> teams = new List<Team>();
            using (var dbContext = new MedialynxDbTeamContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Team team = dbContext.Teams.FirstOrDefault(team => team != null && team.Id == sid);
                    teams.Add(team);
                }
                else
                {
                    // Add all teams
                    teams.AddRange(dbContext.Teams);
                }
            }
            return teams;
        }

        public bool Remove(string teamId)
        {
            Guid id = Utils.ToGuid(teamId);
            using (var dbContext = new MedialynxDbTeamContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Team team = dbContext.Teams.FirstOrDefault(team => team != null && team.Id == sid);
                    if (team != null) {
                        dbContext.Teams.Remove(team);
                        dbContext.SaveChanges();
                    }
                    return true;
                }
            }
            return false;
        }

        public List<User> GetTeamUsers(string teamId)
        {
            Guid id = Utils.ToGuid(teamId);
            using (var dbContext = new MedialynxDbTeamUserLinkContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    List<TeamUserLink> links = dbContext.TeamUserLinks.Where(link => link != null && link.TeamId == sid).ToList();
                    List<User> users = new List<User>();
                    using (var dbContextUser = new MedialynxDbUserContext()) {
                        foreach (var link in links) {
                            users.AddRange(dbContextUser.Users.Where(user => user != null && user.Id == link.UserId));
                        }
                    }
                    return users;
                }
            }
            return new List<User>();
        }

        public void Add(Team team)
        {
            using (var dbContext = new MedialynxDbTeamContext()) {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }
        }

        public TeamUserLink AddUserToTeam(string teamId, string userId)
        {
            TeamUserLink link = new TeamUserLink();
            link.Id = Guid.NewGuid().ToString("B");
            link.TeamId = teamId;
            link.UserId = userId;
            link.AccessRights = "DEFAULT"; // not supported yet
            using (var dbContext = new MedialynxDbTeamUserLinkContext()) {
                dbContext.TeamUserLinks.Add(link);
                dbContext.SaveChanges();
            }

            return link;
        }

        public TeamUserLink DeleteUserFromTeam(string teamId, string userId)
        {
            using (var dbContext = new MedialynxDbTeamUserLinkContext()) {
                TeamUserLink teamUserLink = dbContext.TeamUserLinks.FirstOrDefault(link => link.TeamId == teamId && link.UserId == userId);
                if (teamUserLink != null) {
                    dbContext.TeamUserLinks.Remove(teamUserLink);
                    dbContext.SaveChanges();
                }
                return teamUserLink;
            }
        }

        public void Update(Team team)
        {
            using (var dbContext = new MedialynxDbTeamContext()) {
                Team existsTeam = dbContext.Teams.FirstOrDefault(t => t != null && t.Id == team.Id);
                if (existsTeam != null)
                {
                    if (Utils.CopyPropertyValues<Team>(team, existsTeam))
                    {
                        dbContext.Teams.Update(existsTeam);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}