using System;

namespace MedalynxAPI.Models.Cohort
{
    // see CohortPresentation
    public class Cohort
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int NumberOfSubjectsRequired { get; set; }
        public string CohortType { get; set; }
        public RequestType RequestAdmin { get; set; }
        public RequestType RequestUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
