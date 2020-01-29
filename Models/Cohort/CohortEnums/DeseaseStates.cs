using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models.Cohort.CohortEnums
{
    public class DeseaseStates
    {
        public string Id { get; set; }
        public string DeseaseState { get; set; }
        public float Percentage { get; set; }
    }
}
