using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class StageOfDiseasesDBAPI
    {
        public List<StageOfDiseases> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbStageOfDiseasesContext()) {
                return dbContext.StageOfDiseases.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.StageOfTumour.ToString().Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            StageOfDiseases enumItem = (StageOfDiseases) enumItemObject;
            using (var dbContext = new MedialynxDbStageOfDiseasesContext()) {
                dbContext.StageOfDiseases.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(StageOfDiseases enumItem)
        {
            using (var dbContext = new MedialynxDbStageOfDiseasesContext()) {
                var existsItem = dbContext.StageOfDiseases.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<StageOfDiseases>(enumItem, existsItem))
                    {
                        dbContext.StageOfDiseases.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}