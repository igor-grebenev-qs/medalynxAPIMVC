using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.Cohort
{
    /// <summary>
    /// Alive cohort with uploaded links.
    /// </summary>
    [NotMapped]
    public class CohortRepresentation : Cohort
    {
        public CohortRepresentation(Cohort coh) {
            Utils.CopyPropertyValues<Cohort>(coh, this);
        }
        public List<CohortEnumLinkRepresentation> CohortEnumLinks { get; set; }
    }
}
