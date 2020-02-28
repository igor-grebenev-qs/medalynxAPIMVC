using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;


namespace MedalynxAPI.Models
{
    [NotMapped]
    public class ProjectListItemRepresentation : Project
    {
        public ProjectListItemRepresentation(Project project) {
            Utils.CopyPropertyValues<Project>(project, this);
            this.UsersCount = Program.MedialynxData.teamDBAPI.GetTeamUsersCount(this.TeamId);
            this.Owner = Program.MedialynxData.teamDBAPI.GetTeamOwner(this.TeamId);
            this.Notification = Program.MedialynxData.notificationDBAPI.GetByProject(project.Id);
        }

        public int UsersCount {get; private set;}
        public Models.User.User Owner {get; private set;}
        public List<Models.Notification> Notification {get; private set;}
    }
}
