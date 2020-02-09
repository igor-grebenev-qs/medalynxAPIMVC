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
            this.Id = coh.Id;
            this.UserId = coh.UserId;
            this.NumberOfSubjectsRequired = coh.NumberOfSubjectsRequired;
            this.CohortType = coh.CohortType;
            this.Request = coh.Request;
            this.CreationDate = coh.CreationDate;
            this.LastUpdate = coh.LastUpdate;
        }
        public List<CohortEnumLinkRepresentation> CohortEnumLinks { get; set; }
    }
}
