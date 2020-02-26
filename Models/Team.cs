using System;

namespace MedalynxAPI.Models
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
