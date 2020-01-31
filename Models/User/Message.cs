using System;

namespace MedalynxAPI.Models.User
{
    public class Message
    {
        public string Id { get; set; } // guid
        public string UserId { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
