using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
        [NotMapped]
        public class RequestAPI {
            public int Request { get; set; }
        }

        [NotMapped]
        public class RequestTypeAPI {
            public int RequestType { get; set; }
        }
}