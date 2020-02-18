using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class PrognosisDBAPI
    {
        public List<Prognosis> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbPrognosisContext()) {
                return dbContext.Prognosis.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.Keyword.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            Prognosis enumItem = (Prognosis) enumItemObject;
            using (var dbContext = new MedialynxDbPrognosisContext()) {
                dbContext.Prognosis.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(Prognosis enumItem)
        {
            using (var dbContext = new MedialynxDbPrognosisContext()) {
                var existsItem = dbContext.Prognosis.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<Prognosis>(enumItem, existsItem))
                    {
                        dbContext.Prognosis.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}