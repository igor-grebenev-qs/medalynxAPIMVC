using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;


namespace MedalynxAPI.Models
{
    [NotMapped]
    public class ProjectRepresentation : Project
    {
        public ProjectRepresentation(Project project) {
            Utils.CopyPropertyValues<Project>(project, this);
            this.Cohorts = Program.MedialynxData.cohortDBAPI.GetAllByProject(project.Id);
            this.Environments = Program.MedialynxData.environmentDBAPI.GetByProject(project.Id);
            this.Team = Program.MedialynxData.teamDBAPI.GetById(project.TeamId);
            this.Users = Program.MedialynxData.teamDBAPI.GetTeamUsers(this.Team.Id);
            this.Owner = Program.MedialynxData.teamDBAPI.GetTeamOwner(this.Team.Id);
            this.Notification = Program.MedialynxData.notificationDBAPI.GetByProject(project.Id);
        }

        public List<Models.Cohort.Cohort> Cohorts {get; private set;}
        public List<Models.Environment> Environments {get; private set;}
        public Models.Team Team {get; private set;}
        public List<Models.User.User> Users {get; private set;}
        public Models.User.User Owner {get; private set;}
        public List<Models.Notification> Notification {get; private set;}
    }
}
