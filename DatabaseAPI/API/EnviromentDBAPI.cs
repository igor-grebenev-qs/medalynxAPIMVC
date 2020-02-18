using System;
using System.Collections.Generic;
using System.Linq;

namespace MedalynxAPI
{
    internal class EnvironmentComparer : IComparer<Models.Environment>
    {
        public int Compare(Models.Environment x, Models.Environment y)
        {
            return y.LastUpdate.CompareTo(x.LastUpdate);
        }
    }

    public class EnvironmentDBAPI
    {
        // Get Environment by user
        public List<Models.Environment> GetByUser(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<Models.Environment> environments = new List<Models.Environment>();
            using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Models.Environment environment = dbContext.Environments.FirstOrDefault(environment => environment != null && environment.UserId == sid);
                    environments.Add(environment);
                }
                else
                {
                    // Add all environments
                    environments.AddRange(dbContext.Environments);
                }
            }
            environments.Sort(new EnvironmentComparer());
            return environments;
        }

        public void Add(Models.Environment environment)
        {
            using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                dbContext.Environments.Add(environment);
                dbContext.SaveChanges();
            }
        }

        public void Update(Models.Environment environment)
        {
            using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                Models.Environment existsEnvironment = dbContext.Environments.FirstOrDefault(env => env != null && env.Id == environment.Id);
                if (existsEnvironment != null)
                {
                    if (Utils.CopyPropertyValues<Models.Environment>(environment, existsEnvironment))
                    {
                        dbContext.Environments.Update(existsEnvironment);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}