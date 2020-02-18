using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class StageOfDeseasesDBAPI
    {
        public List<StageOfDeseases> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbStageOfDeseasesContext()) {
                return dbContext.StageOfDeseases.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.StageOfTumour.ToString().Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            StageOfDeseases enumItem = (StageOfDeseases) enumItemObject;
            using (var dbContext = new MedialynxDbStageOfDeseasesContext()) {
                dbContext.StageOfDeseases.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(StageOfDeseases enumItem)
        {
            using (var dbContext = new MedialynxDbStageOfDeseasesContext()) {
                var existsItem = dbContext.StageOfDeseases.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<StageOfDeseases>(enumItem, existsItem))
                    {
                        dbContext.StageOfDeseases.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}