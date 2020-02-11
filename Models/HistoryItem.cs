using System;

namespace MedalynxAPI.Models
{
    public class HistoryItem
    {
        public HistoryItem(){}
        public HistoryItem(string userId, string objectType, string message){
            UserId = userId;
            ObjectType = objectType;
            Message = message;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ObjectType { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
