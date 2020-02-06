using System;
namespace MedalynxAPI.Models
{
    public class CohortEnumLinkPresentation : CohortEnumLink
    {
        public CohortEnumLinkPresentation(CohortEnumLink link) {
            this.Id = link.Id;
            this.CohortId = link.CohortId;
            this.CohortEnumId = link.CohortEnumId;
            this.EnumItemId = link.EnumItemId;
            this.Include = link.Include;
            this.Percentage = link.Percentage;
            this.CreationDate = link.CreationDate;
            this.LastUpdate = link.LastUpdate;
        }

        public object CohortEnumItem  { get; set; }
    }
}