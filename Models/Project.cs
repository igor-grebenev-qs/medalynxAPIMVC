using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
    public class Project
    {
        public Project(){}
        public Project(ProjectAPI projectApi){
            this.Access = projectApi.Access;
            this.Name = projectApi.Name;
        }
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string Access { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    [NotMapped]
    public class ProjectAPI
    {
        public string Access { get; set; }
        public string Name { get; set; }
    }
}
