using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class DiseaseStatesDBAPI
    {
        public List<DiseaseStates> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbDiseaseStatesContext()) {
                return dbContext.DiseaseStates.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.DiseaseState.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            DiseaseStates enumItem = (DiseaseStates) enumItemObject;
            using (var dbContext = new MedialynxDbDiseaseStatesContext()) {
                dbContext.DiseaseStates.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(DiseaseStates enumItem)
        {
            using (var dbContext = new MedialynxDbDiseaseStatesContext()) {
                var existsItem = dbContext.DiseaseStates.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<DiseaseStates>(enumItem, existsItem))
                    {
                        dbContext.DiseaseStates.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}