using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
using MedalynxAPI.Models.Cohort.CohortEnums;
using MedalynxAPI.Models.User;

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
        private object GetEnumValue(string enumId, string enumItemId) {
            switch (enumId) {
                case CohortEnumsDictionary.DeseaseStates:
                    return Program.MedialynxData.deseaseStatesDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.GeneticMatches:
                    return Program.MedialynxData.geneticMatchesDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.Biomarkers:
                    return Program.MedialynxData.biomarkersDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.Demographics:
                    return Program.MedialynxData.demographicsDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.Ethnicitys:
                    return Program.MedialynxData.ethnicitysDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.StageOfDeseases:
                    return Program.MedialynxData.stageOfDeseasesDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.Prognosis:
                    return Program.MedialynxData.prognosisDBAPI.Get("", enumItemId).FirstOrDefault();
                case CohortEnumsDictionary.PreviousTreatments:
                    return Program.MedialynxData.previousTreatmentsDBAPI.Get("", enumItemId).FirstOrDefault();
            }
            return null;
        }
        public List<CohortEnumLinkRepresentation> GetLinksByCohort(string cohortId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(cohortId);
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    List<CohortEnumLink> links = dbContext.CohortEnumLink.Where(link => link != null && link.CohortId == sid).ToList();
                    List<CohortEnumLinkRepresentation> representation = new List<CohortEnumLinkRepresentation>();
                    foreach (CohortEnumLink enumLink in links)
                    {
                        CohortEnumLinkRepresentation p = new CohortEnumLinkRepresentation(enumLink);
                        p.CohortEnumItem = this.GetEnumValue(enumLink.CohortEnumId, enumLink.EnumItemId);
                        representation.Add(p);
                    }
                    return representation;
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
                        case CohortEnumsDictionary.DeseaseStates:
                            using (var dbDeseaseStatesContext = new MedialynxDbDeseaseStatesContext()) {
                                links.AddRange(ExistingOptionsAsLink<DeseaseStates>(new List<DeseaseStates>(dbDeseaseStatesContext.DeseaseStates), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.GeneticMatches:
                            using (var dbGeneticMatchesContext = new MedialynxDbGeneticMatchesContext()) {
                                links.AddRange(ExistingOptionsAsLink<GeneticMatches>(new List<GeneticMatches>(dbGeneticMatchesContext.GeneticMatches), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.Biomarkers:
                            using (var dbBiomarkersContext = new MedialynxDbBiomarkersContext()) {
                                links.AddRange(ExistingOptionsAsLink<Biomarkers>(new List<Biomarkers>(dbBiomarkersContext.Biomarkers), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.Demographics:
                            using (var dbDemographicsContext = new MedialynxDbDemographicsContext()) {
                                links.AddRange(ExistingOptionsAsLink<Demographics>(new List<Demographics>(dbDemographicsContext.Demographics), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.Ethnicitys:
                            using (var dbEthnicitysContext = new MedialynxDbEthnicitysContext()) {
                                links.AddRange(ExistingOptionsAsLink<Ethnicitys>(new List<Ethnicitys>(dbEthnicitysContext.Ethnicitys), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.StageOfDeseases:
                            using (var dbStageOfDeseasesContext = new MedialynxDbStageOfDeseasesContext()) {
                                links.AddRange(ExistingOptionsAsLink<StageOfDeseases>(new List<StageOfDeseases>(dbStageOfDeseasesContext.StageOfDeseases), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.Prognosis:
                            using (var dbPrognosisContext = new MedialynxDbPrognosisContext()) {
                                links.AddRange(ExistingOptionsAsLink<Prognosis>(new List<Prognosis>(dbPrognosisContext.Prognosis), cohortId, enumItem.Id));
                            }
                        break;
                        case CohortEnumsDictionary.PreviousTreatments:
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

        /// <summary>
        /// Assume that EnumItemAPI contains fields for any cases. PROPS MUST HAVE SAME NAMES !!!
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <typeparam name="T"></typeparam>
        private static void DirtyCopyEnumItem<T>(EnumItemAPI src, T dest, string id){
            PropertyInfo[] destPropsInfo = dest.GetType().GetProperties();
            foreach (PropertyInfo destPropInfo in destPropsInfo) { // enumerate fields in destanation onbect
                var srcPropValue = src.GetType().GetProperty(destPropInfo.Name).GetValue(src);
                if (srcPropValue == null) { continue; } // value is not initialized

                // ENSURE THAT COHORT ENUMS NOT CONTAINS DATETIME PROPS !!!
                // Not supported for now
                // see CopyPropertyValues<T>(T src, T dest) as sample

                destPropInfo.SetValue(dest, srcPropValue);
            }
            dest.GetType().GetProperty("Id").SetValue(dest, id);
        }

        private void CreateEnumItem(CohortEnumLinkAPI linkAPI) {
            // enum item defined within link item. Must be created and used instead linkAPI.EnumItemId
            string newEnumItemId = Guid.NewGuid().ToString("B");
            // owerwrite id anyway
            linkAPI.EnumItemId = newEnumItemId;
            switch (linkAPI.CohortEnumId) {
                case CohortEnumsDictionary.DeseaseStates:
                    DeseaseStates dsItem = new DeseaseStates();
                    DirtyCopyEnumItem<DeseaseStates>(linkAPI.enumItem, dsItem, newEnumItemId);
                    Program.MedialynxData.deseaseStatesDBAPI.Add(dsItem);
                    break;
                case CohortEnumsDictionary.GeneticMatches:
                    GeneticMatches gmItem = new GeneticMatches();
                    DirtyCopyEnumItem<GeneticMatches>(linkAPI.enumItem, gmItem, newEnumItemId);
                    Program.MedialynxData.geneticMatchesDBAPI.Add(gmItem);
                    break;
                case CohortEnumsDictionary.Biomarkers:
                    Biomarkers bmItem = new Biomarkers();
                    DirtyCopyEnumItem<Biomarkers>(linkAPI.enumItem, bmItem, newEnumItemId);
                    Program.MedialynxData.biomarkersDBAPI.Add(bmItem);
                    break;
                case CohortEnumsDictionary.Demographics:
                    Demographics dmItem = new Demographics();
                    DirtyCopyEnumItem<Demographics>(linkAPI.enumItem, dmItem, newEnumItemId);
                    Program.MedialynxData.demographicsDBAPI.Add(dmItem);
                    break;
                case CohortEnumsDictionary.Ethnicitys:
                    Ethnicitys eItem = new Ethnicitys();
                    DirtyCopyEnumItem<Ethnicitys>(linkAPI.enumItem, eItem, newEnumItemId);
                    Program.MedialynxData.ethnicitysDBAPI.Add(eItem);
                    break;
                case CohortEnumsDictionary.StageOfDeseases:
                    StageOfDeseases sdItem = new StageOfDeseases();
                    DirtyCopyEnumItem<StageOfDeseases>(linkAPI.enumItem, sdItem, newEnumItemId);
                    Program.MedialynxData.stageOfDeseasesDBAPI.Add(sdItem);
                    break;
                case CohortEnumsDictionary.Prognosis:
                    Prognosis pItem = new Prognosis();
                    DirtyCopyEnumItem<Prognosis>(linkAPI.enumItem, pItem, newEnumItemId);
                    Program.MedialynxData.prognosisDBAPI.Add(pItem);
                    break;
                case CohortEnumsDictionary.PreviousTreatments:
                    PreviousTreatments ptItem = new PreviousTreatments();
                    DirtyCopyEnumItem<PreviousTreatments>(linkAPI.enumItem, ptItem, newEnumItemId);
                    Program.MedialynxData.previousTreatmentsDBAPI.Add(ptItem);
                    break;
            }
        }

        public void CreateLinks(string cohortId, List<CohortEnumLinkAPI> LinksForCreation) {
            if (LinksForCreation == null) {
                return; // nothing to create
            }
            foreach (CohortEnumLinkAPI linkAPI in LinksForCreation) {

                // enum item defined within link item. Must be created and used instead linkAPI.EnumItemId
                if (linkAPI.enumItem != null) {
                    this.CreateEnumItem(linkAPI);
                }
                this.CreateNewLink(cohortId, linkAPI);
            }
        }

        private void CreateNewLink(string cohortId, CohortEnumLinkAPI linkAPI) {
            CohortEnumLink link = new CohortEnumLink();
            link.Id = Guid.NewGuid().ToString("B");
            link.CohortId = cohortId;
            link.CohortEnumId = linkAPI.CohortEnumId;
            link.EnumItemId = linkAPI.EnumItemId;
            link.Include = linkAPI.Include;
            link.Percentage = linkAPI.Percentage;
            link.CreationDate = DateTime.UtcNow;
            link.LastUpdate = link.CreationDate;
            this.Add(link);

        }

        public void UpdateLinks(string cohortId, List<CohortEnumLinkAPI> LinksForUpdate) {
            if (LinksForUpdate == null) {
                return; // nothing to update
            }

            // collect id's for update
            List<string> updatesIds = new List<string>();
            foreach (CohortEnumLinkAPI linkAPI in LinksForUpdate) {
                Guid id = Utils.ToGuid(linkAPI.Id, false);
                if (id != Guid.Empty) { // empty = create
                    updatesIds.Add(linkAPI.Id);
                }
            }

            // exists guids
            List<string> existsIds = new List<string>();
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                List<CohortEnumLink> existsLinks = dbContext.CohortEnumLink.Where(link => link.CohortId == cohortId).ToList();
                foreach (CohortEnumLink link in existsLinks) {
                    existsIds.Add(link.Id);
                }
            }

            // check that exists id present in new links collection.
            List<string> toDeleteIds = new List<string>();
            foreach (string item in existsIds)
            {
                if (!updatesIds.Contains(item)) {
                    toDeleteIds.Add(item);
                }
            }
            // remove not exists limks
            this.RemoveRange(toDeleteIds);

            foreach (CohortEnumLinkAPI linkAPI in LinksForUpdate) {
                // enum item defined within link item. Must be created and used instead linkAPI.EnumItemId
                if (linkAPI.enumItem != null) {
                    this.CreateEnumItem(linkAPI);
                }

                List<CohortEnumLink> existLinks = this.Get(linkAPI.Id);
                CohortEnumLink existLink = existLinks.Count > 0 ? existLinks[0] : null;
                if (existLink == null) {
                    this.CreateNewLink(cohortId, linkAPI);
                }
                else { // update exists link required
                    CohortEnumLink link = new CohortEnumLink();
                    link.Id = Guid.NewGuid().ToString("B");
                    link.CohortId = cohortId;
                    link.CohortEnumId = linkAPI.CohortEnumId;
                    link.EnumItemId = linkAPI.EnumItemId;
                    link.Include = linkAPI.Include;
                    link.Percentage = linkAPI.Percentage;
                    link.LastUpdate = link.CreationDate;
                    this.Update(link);
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

        public void Remove(string linkId)
        {
            List<CohortEnumLink> links = this.Get(linkId);
            if (links.Count > 0) {
                using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                    dbContext.CohortEnumLink.Remove(links[0]);
                    dbContext.SaveChanges();
                }
            }
        }

        public void RemoveRange(List<string> linkIds)
        {
            using (var dbContext = new MedialynxDbCohortEnumLinkContext()) {
                List<CohortEnumLink> linksToRemove = new List<CohortEnumLink>();
                foreach (string id in linkIds) {
                    linksToRemove.Add(dbContext.CohortEnumLink.FirstOrDefault(link => link != null && link.Id == id));
                }
                dbContext.CohortEnumLink.RemoveRange(linksToRemove);
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