using System;
using System.IO;
using System.Linq;
using MedalynxAPI.Models;

using MySql.Data.MySqlClient;

namespace MedalynxAPI
{
    public class Patches
    {
        public static void ApplyPatches() {
            try
            {
                var curDir = Directory.GetCurrentDirectory()+"/patches";
                var sqlFiles = Directory.EnumerateFiles(curDir, "*.sql", SearchOption.TopDirectoryOnly);

                foreach (string filePath in sqlFiles)
                {
                    // name format:
                    // database_patch_patchOrder_patchId.sql
                    // sample: database_patch_001_{29d8be4e-394f-4c28-888d-cd6f5811951a}.sql
                    string shortName = filePath.Substring(filePath.LastIndexOf("/")+1).Replace(".sql","");
                    string[] fileInfo = shortName.Split("_");
                    int patchOrder = Int32.Parse(fileInfo[2]);
                    string patchId = fileInfo[3];

                    using (var dbContext = new MedialynxDbMetadataContext()) {
                        var existsMetadata = dbContext.Metadata.FirstOrDefault(md => md.MetadataOrder == patchOrder);
                        if (existsMetadata == null) {
                            string scriptBody = File.ReadAllText(filePath);
                            Patches.ApplySinglePatch(patchOrder, patchId, scriptBody);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static void ApplySinglePatch(int metadataOrder, string patchId, string scriptBody) {
            using (var dbContext = new MedialynxDbMetadataContext()) {
                // Execute patch query
                using (MySqlConnection connection = new MySqlConnection(BaseDbContext.ConnectionString)){
                    connection.Open();
                    // An unhandled exception of type 'System.InvalidOperationException' occurred in MedalynxAPI.dll: 'The transaction associated with this command is not the connection's active ...
                    // using (var sqlTxn = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    // { ... sqlTxn.Commit();}
                    using (var cmd = connection.CreateCommand()) {
                        cmd.CommandText = scriptBody;
                        cmd.ExecuteNonQuery();
                    }

                    // Save metadata object
                    Metadata md = new Metadata();
                    md.Id = Guid.NewGuid().ToString("B");
                    md.MetadataOrder = metadataOrder;
                    md.Comment = "Patch applied: " + patchId;
                    md.Data = scriptBody;
                    md.CreationDate = DateTime.UtcNow;
                    
                    dbContext.Metadata.Add(md);
                    dbContext.SaveChanges();

                    // Add history log
                    Program.MedialynxData.historyDBAPI.Add(
                        new HistoryItem(
                            "n/a",
                            md.Id,
                            typeof(Metadata).ToString(),
                            "Patch applied: " + patchId
                        )
                    );

                }
            }
        }
    }
}