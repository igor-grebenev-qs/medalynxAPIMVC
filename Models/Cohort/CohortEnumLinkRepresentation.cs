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
            Utils.CopyPropertyValues<CohortEnumLink>(link, this);
        }

        public object EnumItem  { get; set; }
    }
}