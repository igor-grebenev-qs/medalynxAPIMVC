using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
        [NotMapped]
        public class StatusAPI {
            public int Status { get; set; }
        }
}