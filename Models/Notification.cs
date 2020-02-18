using System;

namespace MedalynxAPI.Models
{
    public class Notification
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public int NotificationType { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
