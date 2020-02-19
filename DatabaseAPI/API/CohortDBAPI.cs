using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;

namespace MedalynxAPI
{
    public class CohortDBAPI
    {
        // Get cohort by id
        public Cohort GetById(string cohortId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(cohortId, false);
            if (id == Guid.Empty) {
                return null;
            }

            using (var dbContext = new MedialynxDbCohortContext()) {
                string sid = id.ToString("B");
                return dbContext.Cohorts.FirstOrDefault(cohort => cohort != null && cohort.Id == sid);
            }
        }

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

        public bool Remove(string cohortId)
        {
            Guid id = Utils.ToGuid(cohortId);
            using (var dbContext = new MedialynxDbCohortContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Cohort cohort = dbContext.Cohorts.FirstOrDefault(c => c != null && c.Id == sid);
                    if (cohort != null) {
                        dbContext.Cohorts.Remove(cohort);
                        dbContext.SaveChanges();

                        using (var dbContextLinks = new MedialynxDbCohortEnumLinkContext()) {
                            List<CohortEnumLink> links = dbContextLinks.CohortEnumLink.Where(link => link != null && link.CohortId == sid).ToList();
                            dbContextLinks.RemoveRange(links);
                            dbContextLinks.SaveChanges();
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public Cohort GetByUser(string userId, RequestType requestType)
        {
            Guid id = Utils.ToGuid(userId);
            using (var dbContext = new MedialynxDbCohortContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.Cohorts.FirstOrDefault(c => c != null && c.UserId == sid &&
                        (requestType == RequestType.Any || 
                        (requestType == RequestType.CreatedOrApproved && (c.RequestUser == RequestType.Created || c.RequestUser == RequestType.Approved)) ||
                        c.RequestUser == requestType)
                        );
                }
            }
            return null;
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