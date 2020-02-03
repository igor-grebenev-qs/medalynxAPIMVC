using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.Cohort;

namespace MedalynxAPI
{
    public class CohortDBAPI
    {
        public List<Cohort> Get(string cohortId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(cohortId);
            List<Cohort> cohorts = new List<Cohort>();
            using (var dbContext = new MedialynxDbCohortContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Cohort cohort = dbContext.Cohorts.FirstOrDefault(c => c != null && c.Id == sid);
                    cohorts.Add(cohort);
                }
                else
                {
                    // Add all cohorts
                    cohorts.AddRange(dbContext.Cohorts);
                }
            }
            return cohorts;
        }

        public void Add(Cohort cohort)
        {
            using (var dbContext = new MedialynxDbCohortContext()) {
                dbContext.Cohorts.Add(cohort);
                dbContext.SaveChanges();
            }
        }

        public void Update(Cohort cohort)
        {
            using (var dbContext = new MedialynxDbCohortContext()) {
                Cohort existsCohort = dbContext.Cohorts.FirstOrDefault(coh => coh != null && coh.Id == cohort.Id);
                if (existsCohort != null)
                {
                    if (Utils.CopyPropertyValues<Cohort>(cohort, existsCohort))
                    {
                        dbContext.Cohorts.Update(existsCohort);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}