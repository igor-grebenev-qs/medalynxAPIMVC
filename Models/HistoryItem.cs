using System;

namespace MedalynxAPI.Models
{
    public class HistoryItem : BaseModelEntry
    {
        public HistoryItem(){}
        public HistoryItem(string userId, string objectId, string objectType, string message){
            if (userId == null) {
                throw new Exception("User Id must be initialized");
            }
            UserId = userId;
            if (objectId == null) {
                throw new Exception("Object Id must be initialized");
            }
            ObjectId = objectId;
            ObjectType = objectType;
            Message = message;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
