using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    internal class EnviromentComparer : IComparer<Models.Environment>
    {
        public int Compare(Models.Environment x, Models.Environment y)
        {
            return y.LastUpdate.CompareTo(x.LastUpdate);
        }
    }

    public class EnviromentDBAPI
    {
        // Get Enviroment by user
        public List<Models.Environment> GetByUser(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<Models.Environment> enviroments = new List<Models.Environment>();
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Models.Environment enviroment = dbContext.Enviroments.FirstOrDefault(enviroment => enviroment != null && enviroment.UserId == sid);
                    enviroments.Add(enviroment);
                }
                else
                {
                    // Add all enviroments
                    enviroments.AddRange(dbContext.Enviroments);
                }
            }
            enviroments.Sort(new EnviromentComparer());
            return enviroments;
        }

        public void Add(Models.Environment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                dbContext.Enviroments.Add(enviroment);
                dbContext.SaveChanges();
            }
        }

        public void Update(Models.Environment enviroment)
        {
            using (var dbContext = new MedialynxDbEnviromentsContext()) {
                Models.Environment existsEnviroment = dbContext.Enviroments.FirstOrDefault(env => env != null && env.Id == enviroment.Id);
                if (existsEnviroment != null)
                {
                    if (Utils.CopyPropertyValues<Models.Environment>(enviroment, existsEnviroment))
                    {
                        dbContext.Enviroments.Update(existsEnviroment);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}