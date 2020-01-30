namespace MedalynxAPI.Models.Cohort.CohortEnums
{
    public class StageOfDeseases
    {
        public string Id { get; set; }
        public int StageOfTumour { get; set; }
        public int NumberOfNodesAffected { get; set; }
        public int NumberOfMetastasis { get; set; }
    }
}