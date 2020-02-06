using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.Cohort
{
    [NotMapped]
    public class CohortPresentation : Cohort
    {
        public CohortPresentation(Cohort coh) {
            this.Id = coh.Id;
            this.UserId = coh.UserId;
            this.NumberOfSubjectsRequired = coh.NumberOfSubjectsRequired;
            this.CohortType = coh.CohortType;
            this.Request = coh.Request;
            this.CreationDate = coh.CreationDate;
            this.LastUpdate = coh.LastUpdate;
        }
        public List<CohortEnumLinkPresentation> CohortEnumLinks { get; set; }
    }
}
