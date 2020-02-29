using System;

namespace MedalynxAPI.Models
{
    public class Notification : BaseModelEntry
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public ObjectStatus Status { get; set; }
        public ObjectStatus RequestType { get; set; }
        public RequestType Request { get; set; }
        public int Processing { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
