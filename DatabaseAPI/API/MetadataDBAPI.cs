using System;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    public class MetadataDBAPI
    {
        public Metadata Get(string metadataId)
        {
            Guid id = Utils.ToGuid(metadataId, false);
            using (var dbContext = new MedialynxDbMetadataContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.Metadata.FirstOrDefault(md => md != null && md.Id == sid);
                }
            }
            return null;
        }

        public Metadata GetByOrder(int metadataOrder)
        {
            using (var dbContext = new MedialynxDbMetadataContext()) {
                return dbContext.Metadata.FirstOrDefault(md => md != null && md.MetadataOrder == metadataOrder);
            }
        }

        public Metadata GetLast()
        {
            using (var dbContext = new MedialynxDbMetadataContext()) {
                return dbContext.Metadata.OrderBy(item => item.MetadataOrder).LastOrDefault();
            }
        }

        /// <summary>
        /// It's required ? I'm not sure !!!
        /// </summary>
        /// <param name="metadata"></param>
        internal void Add(Metadata metadata)
        {
            using (var dbContext = new MedialynxDbMetadataContext()) {
                dbContext.Metadata.Add(metadata);
                dbContext.SaveChanges();
            }
        }
    }
}