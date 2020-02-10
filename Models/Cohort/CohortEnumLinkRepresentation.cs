using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
    /// <summary>
    /// Alive link with uploaded enum item.
    /// </summary>
    [NotMapped]
    public class CohortEnumLinkRepresentation : CohortEnumLink
    {
        public CohortEnumLinkRepresentation(CohortEnumLink link) {
            this.Id = link.Id;
            this.CohortId = link.CohortId;
            this.CohortEnumId = link.CohortEnumId;
            this.EnumItemId = link.EnumItemId;
            this.Include = link.Include;
            this.Percentage = link.Percentage;
            this.CreationDate = link.CreationDate;
            this.LastUpdate = link.LastUpdate;
        }

        public object EnumItem  { get; set; }
    }
}