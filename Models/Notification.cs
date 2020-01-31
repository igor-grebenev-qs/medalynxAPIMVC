using System;

namespace MedalynxAPI.Models
{
    public class Notification
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public int NoicationType { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
