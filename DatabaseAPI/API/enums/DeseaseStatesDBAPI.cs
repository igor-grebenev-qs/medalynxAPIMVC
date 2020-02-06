using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class DeseaseStatesDBAPI
    {
        public List<DeseaseStates> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbDeseaseStatesContext()) {
                return dbContext.DeseaseStates.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.DeseaseState.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            DeseaseStates enumItem = (DeseaseStates) enumItemObject;
            using (var dbContext = new MedialynxDbDeseaseStatesContext()) {
                dbContext.DeseaseStates.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(DeseaseStates enumItem)
        {
            using (var dbContext = new MedialynxDbDeseaseStatesContext()) {
                var existsItem = dbContext.DeseaseStates.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<DeseaseStates>(enumItem, existsItem))
                    {
                        dbContext.DeseaseStates.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}