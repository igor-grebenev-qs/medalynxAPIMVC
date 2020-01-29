using System;

namespace medalynxAPIMVC.Models.Cohort
{
    public class CohortEnums
    {
        public string Id { get; set; } // guid
        public string Name { get; set; } // Display name
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}