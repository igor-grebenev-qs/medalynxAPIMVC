using System;

namespace MedalynxAPI.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string Access { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
