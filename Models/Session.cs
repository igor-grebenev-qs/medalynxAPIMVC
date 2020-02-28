using System;

namespace MedalynxAPI.Models
{
    public class Session : BaseModelEntry
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
