using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    public class CohortEnumsDBAPI
    {
        public List<CohortEnums> Get(string enumItemId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(enumItemId);
            List<CohortEnums> enums = new List<CohortEnums>();
            using (var dbContext = new MedialynxDbCohortEnumsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    CohortEnums enumItem = dbContext.CohortEnums.FirstOrDefault(enumItem => enumItem != null && enumItem.Id == sid);
                    enums.Add(enumItem);
                }
                else
                {
                    // Add all users
                    enums.AddRange(dbContext.CohortEnums);
                }
            }
            return enums;
        }

        public void Add(CohortEnums enumItem)
        {
            using (var dbContext = new MedialynxDbCohortEnumsContext()) {
                dbContext.CohortEnums.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(CohortEnums enumItem)
        {
            using (var dbContext = new MedialynxDbCohortEnumsContext()) {
                CohortEnums existsItem = dbContext.CohortEnums.FirstOrDefault(item => item != null && item.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<CohortEnums>(enumItem, existsItem))
                    {
                        dbContext.CohortEnums.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}