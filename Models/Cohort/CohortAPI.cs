using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.Cohort
{
    /// <summary>
    /// EnumItemAPI contains all possible fields for cohort enums
    /// </summary>
    [NotMapped]
    public class EnumItemAPI {
        public string Id { get; set; }
        public float AgeFrom { get; set; }
        public float AgeTo { get; set; }
        public string Alt { get; set; }
        public string Chromosome { get; set; }
        public string dbSNP { get; set; }
        public string DiseaseState { get; set; }
        public string Gender { get; set; }
        public string Keyword { get; set; }
        public string Nationality { get; set; }
        public int NumberOfNodesAffected { get; set; }
        public int NumberOfMetastasis { get; set; }
        public int Position { get; set; }
        public string Ref { get; set; }
        public int StageOfTumour { get; set; }
    }

    /// <summary>
    /// Link with alive enum item. Simple way to save objects in the one request.
    /// </summary>
    [NotMapped]
    public class CohortEnumLinkAPI
    {
        public string Id { get; set; }

        public string CohortId { get; set; }

        public string CohortEnumId { get; set; }

        public string EnumItemId { get; set; }

        public int Include { get; set; }

        public float Percentage { get; set; }

        public EnumItemAPI enumItem { get; set; }
    }

    /// <summary>
    /// Like CohortRepresentation.null API has differend in list item (EnumItemAPI).
    /// This is a simple way to map.
    /// </summary>
    [NotMapped]
    public class CohortAPI
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public int NumberOfSubjectsRequired { get; set; }
        public string CohortType { get; set; }
        public RequestType RequestAdmin { get; set; }
        public RequestType RequestUser { get; set; }
        public List<CohortEnumLinkAPI> cohortEnumLinks { get; set; }
    }
}
