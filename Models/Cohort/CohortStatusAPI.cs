using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
        [NotMapped]
        public class CohortStatusAPI {
            public int Status { get; set; }
        }
}