using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
        [NotMapped]
        public class RequestTypeAPI {
            public int RequestType { get; set; }
        }
}