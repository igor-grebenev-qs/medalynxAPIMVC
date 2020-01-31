using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    public class EnviromentDBAPI
    {
        // Get Enviroment by user
        public List<Enviroment> Get(string userId = "{00000000-0000-0000-0000-000000000000}")
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

        public void Add(Enviroment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                dbContext.Enviroments.Add(enviroment);
                dbContext.SaveChanges();
            }
        }

        public void Update(Enviroment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                Enviroment existsEnviroment = dbContext.Enviroments.FirstOrDefault(env => env != null && env.Id == enviroment.Id);
                if (existsEnviroment != null)
                {
                    if (Utils.CopyPropertyValues<Enviroment>(enviroment, existsEnviroment))
                    {
                        dbContext.Enviroments.Update(existsEnviroment);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}