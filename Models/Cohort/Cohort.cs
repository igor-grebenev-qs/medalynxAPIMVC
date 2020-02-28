using System;

namespace MedalynxAPI.Models.Cohort
{
    // see CohortPresentation
    public class Cohort : BaseModelEntry
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public int NumberOfSubjectsRequired { get; set; }
        public string CohortType { get; set; }
        public RequestType RequestAdmin { get; set; }
        public RequestType RequestUser { get; set; }
        public ObjectStatus Status { get; set; }
        public ObjectStatus RequestType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
