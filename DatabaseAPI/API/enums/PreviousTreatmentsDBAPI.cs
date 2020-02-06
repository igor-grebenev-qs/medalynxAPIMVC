using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class PreviousTreatmentsDBAPI
    {
        public List<PreviousTreatments> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbPreviousTreatmentsContext()) {
                return dbContext.PreviousTreatments.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.Keyword.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            PreviousTreatments enumItem = (PreviousTreatments) enumItemObject;
            using (var dbContext = new MedialynxDbPreviousTreatmentsContext()) {
                dbContext.PreviousTreatments.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(PreviousTreatments enumItem)
        {
            using (var dbContext = new MedialynxDbPreviousTreatmentsContext()) {
                var existsItem = dbContext.PreviousTreatments.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<PreviousTreatments>(enumItem, existsItem))
                    {
                        dbContext.PreviousTreatments.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}