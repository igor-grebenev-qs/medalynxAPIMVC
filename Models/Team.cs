using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
    public class Team
    {
        public Team(){}
        public Team(TeamAPI api){
            this.Name = api.Name;
            this.Details = api.Details;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    [NotMapped]
    public class TeamAPI
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string UserId { get; set; }
    }
}
