namespace MedalynxAPI.Models.Cohort.CohortEnums
{
    public class Demographics : BaseModelEntry
    {
        public string Id { get; set; }
        public float AgeFrom { get; set; }
        public float AgeTo { get; set; }
        public string Gender { get; set; }
    }
}