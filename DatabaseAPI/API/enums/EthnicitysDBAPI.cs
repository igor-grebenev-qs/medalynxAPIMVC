using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class EthnicitysDBAPI
    {
        public List<Ethnicitys> Get(string filter = "")
        {
            using (var dbContext = new MedialynxDbEthnicitysContext()) {
                return dbContext.Ethnicitys.Where(enumItem => filter == "" || enumItem.Nationality.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            Ethnicitys enumItem = (Ethnicitys) enumItemObject;
            using (var dbContext = new MedialynxDbEthnicitysContext()) {
                dbContext.Ethnicitys.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(Ethnicitys enumItem)
        {
            using (var dbContext = new MedialynxDbEthnicitysContext()) {
                var existsItem = dbContext.Ethnicitys.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<Ethnicitys>(enumItem, existsItem))
                    {
                        dbContext.Ethnicitys.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}