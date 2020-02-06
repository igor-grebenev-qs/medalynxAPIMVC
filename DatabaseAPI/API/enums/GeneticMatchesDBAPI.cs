using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort.CohortEnums;

namespace MedalynxAPI
{
    public class GeneticMatchesDBAPI
    {
        public List<GeneticMatches> Get(string filter = "", string enumItemId = "")
        {
            using (var dbContext = new MedialynxDbGeneticMatchesContext()) {
                return dbContext.GeneticMatches.Where(enumItem => enumItemId == "" || enumItem.Id == enumItemId).Where(enumItem => filter == "" || enumItem.Chromosome.Contains(filter) || enumItem.Ref.Contains(filter) || enumItem.Alt.Contains(filter)).ToList();
            }
        }

        public void Add(object enumItemObject)
        {
            GeneticMatches enumItem = (GeneticMatches) enumItemObject;
            using (var dbContext = new MedialynxDbGeneticMatchesContext()) {
                dbContext.GeneticMatches.Add(enumItem);
                dbContext.SaveChanges();
            }
        }

        public void Update(GeneticMatches enumItem)
        {
            using (var dbContext = new MedialynxDbGeneticMatchesContext()) {
                var existsItem = dbContext.GeneticMatches.FirstOrDefault(u => u != null && u.Id == enumItem.Id);
                if (existsItem != null)
                {
                    if (Utils.CopyPropertyValues<GeneticMatches>(enumItem, existsItem))
                    {
                        dbContext.GeneticMatches.Update(existsItem);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}