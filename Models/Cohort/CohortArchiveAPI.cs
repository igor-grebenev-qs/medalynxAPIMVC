using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MedalynxAPI.Models
{
        [NotMapped]
        public class CohortStatusAPI {
            public List<string> EnumLinksIds { get; set; }
            public EnumLinkStatus Status { get; set; }
        }
}