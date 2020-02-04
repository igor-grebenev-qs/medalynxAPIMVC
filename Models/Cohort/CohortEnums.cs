using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.User
{
    [NotMapped]
    public class CohortEnums
    {
        public static Dictionary<string, string> cohortEnums = new Dictionary<string, string>(){
            {"DeseaseStates", "{3089e988-cbaa-4417-9ff2-447a3d90a534}"},
            {"GeneticMatches", "{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}"},
            {"Biomarkers", "{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}"},
            {"Demographics", "{47f7bac5-60e6-4161-86d9-4ec5f561cafa}"},
            {"Ethnicitys", "{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}"},
            {"StageOfDeseases", "{cc77ecca-8279-4c9d-b321-064ba492ba9e}"},
            {"Prognosis", "{5d65643e-4060-48e3-a094-347133b0ed81}"},
            {"PreviousTreatments", "{152583bb-7105-462e-ad74-c9702696feae}"}
       };
    }
}
