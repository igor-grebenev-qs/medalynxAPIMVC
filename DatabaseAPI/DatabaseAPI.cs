using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
using MedalynxAPI.Models.Enums;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class UserDBAPI
    {
        public List<User> GetUser(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<User> users = new List<User>();
            using (var dbContext = new MedialynxDbUserContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    User user = dbContext.Users.FirstOrDefault(user => user != null && user.Id == sid);
                    users.Add(user);
                }
                else
                {
                    // Add all users
                    users.AddRange(dbContext.Users);
                }
            }
            return users;
        }

        public void AddUser(User user)
        {
            using (var dbContext = new MedialynxDbUserContext()) {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var dbContext = new MedialynxDbUserContext()) {
                User existsUser = dbContext.Users.FirstOrDefault(u => u != null && u.Id == user.Id);
                if (existsUser != null)
                {
                    if (Utils.CopyPropertyValues<User>(user, existsUser))
                    {
                        dbContext.Users.Update(existsUser);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }

    public class EnviromentDBAPI
    {
        // Get Enviroment by user
        public List<Enviroment> GetEnviroment(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<Enviroment> enviroments = new List<Enviroment>();
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Enviroment enviroment = dbContext.Enviroments.FirstOrDefault(enviroment => enviroment != null && enviroment.UserId == sid);
                    enviroments.Add(enviroment);
                }
                else
                {
                    // Add all enviroments
                    enviroments.AddRange(dbContext.Enviroments);
                }
            }
            return enviroments;
        }

        public void AddEnviroment(Enviroment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                dbContext.Enviroments.Add(enviroment);
                dbContext.SaveChanges();
            }
        }

        public void UpdateEnviroment(Enviroment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                Enviroment existsEnviroment = dbContext.Enviroments.FirstOrDefault(env => env != null && env.Id == enviroment.Id);
                if (existsEnviroment != null)
                {
                    dbContext.Enviroments.Update(enviroment);
                    dbContext.SaveChanges();
                }
            }
        }
    }

    public class AnalyticalApplicationsDBAPI
    {
        public List<AnalyticalApplicationItem> GetEnum(string itemId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(itemId);
            List<AnalyticalApplicationItem> items = new List<AnalyticalApplicationItem>();

            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    AnalyticalApplicationItem item = dbContext.AnalyticalApplications.FirstOrDefault(item => item != null && item.Id == sid);
                    items.Add(item);
                }
                else
                {
                    // Add all items
                    items.AddRange(dbContext.AnalyticalApplications);
                }
            }
            return items;
        }

        public void AddItem(AnalyticalApplicationItem item)
        {
            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                dbContext.AnalyticalApplications.Add(item);
                dbContext.SaveChanges();
            }
        }

        public void UpdateItem(AnalyticalApplicationItem item)
        {
            using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                AnalyticalApplicationItem existsEnumItem = dbContext.AnalyticalApplications.FirstOrDefault(itm => itm != null && itm.Id == item.Id);
                if (existsEnumItem != null)
                {
                    dbContext.AnalyticalApplications.Update(item);
                    dbContext.SaveChanges();
                }
            }
        }
    }

    public class CohortEnumLinkDBAPI
    {
        public List<CohortEnumLink> GetLink(string linkId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(linkId);
            List<CohortEnumLink> links = new List<CohortEnumLink>();
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    CohortEnumLink link = dbContext.CohortEnumLink.FirstOrDefault(link => link != null && link.Id == sid);
                    links.Add(link);
                }
                else
                {
                    // Add all links
                    links.AddRange(dbContext.CohortEnumLink);
                }
            }
            return links;
        }

        public CohortEnumLink GetLinkByCohort(string cohortId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(cohortId);
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.CohortEnumLink.FirstOrDefault(link => link != null && link.CohortId == sid);
                }
            }
            return null;
        }

        internal List<CohortEnumLink> ExistingOptionsAsLink<T>(List<T> items, string cohortId, string cohortEnumId){
            List<CohortEnumLink> links = new List<CohortEnumLink>();
            foreach (var item in items){
                var Id = item.GetType().GetProperty("Id").GetValue(item, null);

                CohortEnumLink newEnumLink = new CohortEnumLink();
                newEnumLink.Id = Guid.NewGuid().ToString("B");
                newEnumLink.CohortId = cohortId;
                newEnumLink.CohortEnumId = cohortEnumId;
                newEnumLink.EnumItemId = (string) Id;
                newEnumLink.CreationDate = DateTime.UtcNow;
                newEnumLink.LastUpdate = newEnumLink.CreationDate;
                links.Add(newEnumLink);
            }

            return links;
        }

        public void GenerateCohortEnumLinks(string cohortId)
        {
            List<CohortEnumLink> links = new List<CohortEnumLink>();
            using (var dbCohortContext = new MedialynxDbCohortEnumsContext()) {
                foreach (CohortEnums enumItem in dbCohortContext.CohortEnums){
                    switch (enumItem.Id) {
                        case "{3089e988-cbaa-4417-9ff2-447a3d90a534}": // DeseaseStates
                            using (var dbDeseaseStatesContext = new MedialynxDbDeseaseStatesContext()) {
                                links.AddRange(ExistingOptionsAsLink<DeseaseStates>(new List<DeseaseStates>(dbDeseaseStatesContext.DeseaseStates), cohortId, enumItem.Id));
                            }
                        break;
                        case "{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}": // GeneticMatches
                            using (var dbGeneticMatchesContext = new MedialynxDbGeneticMatchesContext()) {
                                links.AddRange(ExistingOptionsAsLink<GeneticMatches>(new List<GeneticMatches>(dbGeneticMatchesContext.GeneticMatches), cohortId, enumItem.Id));
                            }
                        break;
                        case "{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}": // Biomarkers
                            using (var dbBiomarkersContext = new MedialynxDbBiomarkersContext()) {
                                links.AddRange(ExistingOptionsAsLink<Biomarkers>(new List<Biomarkers>(dbBiomarkersContext.Biomarkers), cohortId, enumItem.Id));
                            }
                        break;
                        case "{47f7bac5-60e6-4161-86d9-4ec5f561cafa}": // Demographics
                            using (var dbDemographicsContext = new MedialynxDbDemographicsContext()) {
                                links.AddRange(ExistingOptionsAsLink<Demographics>(new List<Demographics>(dbDemographicsContext.Demographics), cohortId, enumItem.Id));
                            }
                        break;
                        case "{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}": // Ethnicitys
                            using (var dbEthnicitysContext = new MedialynxDbEthnicitysContext()) {
                                links.AddRange(ExistingOptionsAsLink<Ethnicitys>(new List<Ethnicitys>(dbEthnicitysContext.Ethnicitys), cohortId, enumItem.Id));
                            }
                        break;
                        case "{cc77ecca-8279-4c9d-b321-064ba492ba9e}": // StageOfDeseases
                            using (var dbStageOfDeseasesContext = new MedialynxDbStageOfDeseasesContext()) {
                                links.AddRange(ExistingOptionsAsLink<StageOfDeseases>(new List<StageOfDeseases>(dbStageOfDeseasesContext.StageOfDeseases), cohortId, enumItem.Id));
                            }
                        break;
                        case "{5d65643e-4060-48e3-a094-347133b0ed81}": // Prognosis
                            using (var dbPrognosisContext = new MedialynxDbPrognosisContext()) {
                                links.AddRange(ExistingOptionsAsLink<Prognosis>(new List<Prognosis>(dbPrognosisContext.Prognosis), cohortId, enumItem.Id));
                            }
                        break;
                        case "{152583bb-7105-462e-ad74-c9702696feae}": // PreviousTreatments
                            using (var dbPreviousTreatmentsContext = new MedialynxDbPreviousTreatmentsContext()) {
                                links.AddRange(ExistingOptionsAsLink<PreviousTreatments>(new List<PreviousTreatments>(dbPreviousTreatmentsContext.PreviousTreatments), cohortId, enumItem.Id));
                            }
                        break;
                    }
                }

                using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                    dbContext.CohortEnumLink.AddRange(links);
                    dbContext.SaveChanges();
                }
            }
        }

        public void AddCohortEnumLink(CohortEnumLink link)
        {
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                dbContext.CohortEnumLink.Add(link);
                dbContext.SaveChanges();
            }
        }

        public void UpdateCohortEnumLink(CohortEnumLink link)
        {
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                CohortEnumLink existsLink = dbContext.CohortEnumLink.FirstOrDefault(l => l != null && l.Id == link.Id);
                if (existsLink != null)
                {
                    if (Utils.CopyPropertyValues<CohortEnumLink>(link, existsLink))
                    {
                        dbContext.CohortEnumLink.Update(existsLink);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }

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

        public void AddCohort(Cohort cohort)
        {
            using (var dbContext = new MedialynxDbCohortContext()) {
                dbContext.Cohorts.Add(cohort);
                dbContext.SaveChanges();
            }
        }

        public void UpdateCohort(Cohort cohort)
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