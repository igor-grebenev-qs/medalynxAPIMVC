using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Enums;

namespace MedalynxAPI
{
    public class AnalyticalApplicationsDBAPI
    {
        public List<AnalyticalApplicationItem> Get(string itemId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(itemId);
            List<AnalyticalApplicationItem> items = new List<AnalyticalApplicationItem>();

            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    AnalyticalApplicationItem item = dbContext.AnalyticalApplications.FirstOrDefault(item => item != null && item.Id == sid);
                    items.Add(item);
                }
                else
                {
                    // Add all items
                    items.AddRange(dbContext.AnalyticalApplications);
                }
            }
            return items;
        }

        public void Add(AnalyticalApplicationItem item)
        {
            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                dbContext.AnalyticalApplications.Add(item);
                dbContext.SaveChanges();
            }
        }

        public void Update(AnalyticalApplicationItem item)
        {
            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                AnalyticalApplicationItem existsEnumItem = dbContext.AnalyticalApplications.FirstOrDefault(itm => itm != null && itm.Id == item.Id);
                if (existsEnumItem != null)
                {
                    if (Utils.CopyPropertyValues<AnalyticalApplicationItem>(item, existsEnumItem))
                    {
                        dbContext.AnalyticalApplications.Update(existsEnumItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}