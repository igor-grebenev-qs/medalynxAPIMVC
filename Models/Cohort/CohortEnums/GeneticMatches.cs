namespace MedalynxAPI.Models.Cohort.CohortEnums
{
    public class GeneticMatches : BaseModelEntry
    {
        public string Id { get; set; }
        public string Chromosome { get; set; }
        public int Position { get; set; }
        public string Ref { get; set; }
        public string Alt { get; set; }
        public string dbSNP { get; set; }
    }
}