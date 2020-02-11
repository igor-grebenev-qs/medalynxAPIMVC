using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;

namespace MedalynxAPI
{
    public class HistoryDBAPI
    {
        public List<HistoryItem> Get(string historyId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(historyId);
            List<HistoryItem> historyItems = new List<HistoryItem>();
            using (var dbContext = new MedialynxDbHistoryContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    historyItems.Add(dbContext.HistoryItems.FirstOrDefault(item => item != null && item.Id == sid));
                }
                else
                {
                    // Add all history
                    historyItems.AddRange(dbContext.HistoryItems);
                }
            }
            return historyItems;
        }

        public List<HistoryItem> GetByUser(string userId)
        {
            Guid id = Utils.ToGuid(userId);
            using (var dbContext = new MedialynxDbHistoryContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.HistoryItems.Where(item => item != null && item.UserId == sid).ToList();
                }
            }
            return null;
        }

        public void Add(HistoryItem historyItem)
        {
            using (var dbContext = new MedialynxDbHistoryContext()) {
                dbContext.HistoryItems.Add(historyItem);
                dbContext.SaveChanges();
            }
        }
    }
}