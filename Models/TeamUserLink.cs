using System;

namespace MedalynxAPI.Models
{
    public class TeamUserLink
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public string AccessRights { get; set; }
    }
}
