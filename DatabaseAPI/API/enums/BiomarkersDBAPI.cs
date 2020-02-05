using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class BiomarkersDBAPI
    {
        public List<Biomarkers> Get(string filter = "")
        {
            using (var dbContext = new MedialynxDbBiomarkersContext()) {
                return dbContext.Biomarkers.Where(enumItem => filter == "" || enumItem.DeseaseState.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            Biomarkers enumItem = (Biomarkers) enumItemObject;
            using (var dbContext = new MedialynxDbBiomarkersContext()) {
                dbContext.Biomarkers.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(Biomarkers enumItem)
        {
            using (var dbContext = new MedialynxDbBiomarkersContext()) {
                var existsItem = dbContext.Biomarkers.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<Biomarkers>(enumItem, existsItem))
                    {
                        dbContext.Biomarkers.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}