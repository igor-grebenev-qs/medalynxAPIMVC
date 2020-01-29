using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Enums;

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

        public bool AddUser(User user)
        {
            try
            {
                using (var dbContext = new MedialynxDbUserContext()) {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateUser(User user)
        {
            try
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
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public class EnviromentDBAPI
    {
        // Get Enviroment by user
        public List<Enviroment> GetEnviroment(string userId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(userId);
            List<Enviroment> Environments = new List<Enviroment>();
            using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Enviroment enviroment = dbContext.Environments.FirstOrDefault(enviroment => enviroment != null && enviroment.UserId == sid);
                    Environments.Add(enviroment);
                }
                else
                {
                    // Add all Environments
                    Environments.AddRange(dbContext.Environments);
                }
            }
            return Environments;
        }

        public bool AddEnviroment(Enviroment enviroment)
        {
            try
            {
                using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                    dbContext.Environments.Add(enviroment);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEnviroment(Enviroment enviroment)
        {
            try
            {
                using (var dbContext = new MedialynxDbEnvironmentsContext()) {
                    Enviroment existsEnviroment = dbContext.Environments.FirstOrDefault(env => env != null && env.Id == enviroment.Id);
                    if (existsEnviroment != null)
                    {
                        dbContext.Environments.Update(enviroment);
                        dbContext.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
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

        public bool AddItem(AnalyticalApplicationItem item)
        {
            try
            {
                using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                    dbContext.AnalyticalApplications.Add(item);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateItem(AnalyticalApplicationItem item)
        {
            try
            {
                using (var dbContext = new MedialynxDbAnalyticalApplicationsContext()) {
                    AnalyticalApplicationItem existsEnumItem = dbContext.AnalyticalApplications.FirstOrDefault(itm => itm != null && itm.Id == item.Id);
                    if (existsEnumItem != null)
                    {
                        dbContext.AnalyticalApplications.Update(item);
                        dbContext.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}