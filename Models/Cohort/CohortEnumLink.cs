using System;
namespace MedalynxAPI.Models
{
    // see CohortEnumLinkPresentation
    public class CohortEnumLink
    {
        public string Id { get; set; }

        public string CohortId { get; set; }

        /// <summary>
        /// Id of aggregated any enum record.
        /// Cohort enums: DeseaseStates, GeneticMatches, Biomarkers, Demographics, Ethnicity, StageOfDesease, Prognosis, PreviousTreatment
        /// </summary>
        /// <value></value>
        public string CohortEnumId { get; set; }

        public string EnumItemId { get; set; }

        public int Include { get; set; }

        public float Percentage { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}