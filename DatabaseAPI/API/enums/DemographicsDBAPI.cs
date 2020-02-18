using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class DemographicsDBAPI
    {
        public List<Demographics> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbDemographicsContext()) {
                return dbContext.Demographics.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.AgeFrom.ToString().Contains(filter) || enumItem.AgeTo.ToString().Contains(filter) || enumItem.Gender.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            Demographics enumItem = (Demographics) enumItemObject;
            using (var dbContext = new MedialynxDbDemographicsContext()) {
                dbContext.Demographics.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(Demographics enumItem)
        {
            using (var dbContext = new MedialynxDbDemographicsContext()) {
                var existsItem = dbContext.Demographics.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<Demographics>(enumItem, existsItem))
                    {
                        dbContext.Demographics.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}