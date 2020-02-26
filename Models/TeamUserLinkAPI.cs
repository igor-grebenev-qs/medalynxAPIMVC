using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models
{
    [NotMapped]
    public class TeamUserLinkAPI
    {
        public string UserId { get; set; }
    }
}
