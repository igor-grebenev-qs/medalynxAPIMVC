using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class CohortEnumLinkDBAPI
    {
        public List<CohortEnumLink> Get(string linkId = "{00000000-0000-0000-0000-000000000000}")
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

        public void Generate(string cohortId)
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

        public void Add(CohortEnumLink link)
        {
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                dbContext.CohortEnumLink.Add(link);
                dbContext.SaveChanges();
            }
        }

        public void Update(CohortEnumLink link)
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
}