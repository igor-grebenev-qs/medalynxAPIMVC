using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.User;

namespace MedalynxAPI
{
    public class MessageDBAPI
    {
        // Get Environment by user
        public List<Message> GetByUser(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<Message> messages = new List<Message>();
            using (var dbContext = new MedialynxDbMessagesContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    IEnumerable<Message> elist = dbContext.Messages.Where(msg => msg != null && msg.UserId == sid);
                    messages.AddRange(elist);
                }
                else
                {
                    messages.AddRange(dbContext.Messages);
                }
            }
            return messages;
        }

        public void Add(Message message)
        {
            using (var dbContext = new MedialynxDbMessagesContext()) {
                dbContext.Messages.Add(message);
                dbContext.SaveChanges();
            }
        }
    }
}