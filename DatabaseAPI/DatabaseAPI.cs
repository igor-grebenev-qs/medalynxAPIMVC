using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;using MedalynxAPI.Models;
using MedalynxAPI.Models.Enums;

namespace MedalynxAPI {
    public abstract class DatabaseAPI {
        internal MedialynxDbContext dbContext = null;

    }

    public class UserDBAPI : DatabaseAPI {
        public UserDBAPI (MedialynxDbContext context) {
            dbContext = context;
        }

        public List<User> GetUser (string userId = "{00000000-0000-0000-0000-000000000000}") {
            Guid id = Utils.ToGuid(userId);
            List<User> users = new List<User>();

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
            return users;
        }

        public bool AddUser (User user) {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e) {
                throw;
            }
        }

        public bool UpdateUser (User user) {
            try
            {
                User existsUser = dbContext.Users.FirstOrDefault(u => u != null && u.Id == user.Id);
                if (existsUser != null) {
                    existsUser.Email = user.Email;
                    existsUser.FirstName = user.FirstName;
                    existsUser.LastName = user.LastName;
                    existsUser.CompanyName = user.CompanyName;
                    existsUser.Request = user.Request;
                    existsUser.Password = user.Password;
                    existsUser.LastUpdate = DateTime.Now;
                    dbContext.Users.Update(existsUser);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e) {
                throw;
            }
        }
    }

    public class EnviromentDBAPI : DatabaseAPI {
        public EnviromentDBAPI (MedialynxDbContext context) {
            dbContext = context;
        }

        // Get Enviroment by user
        public List<Enviroment> GetEnviroment (string userId = "{00000000-0000-0000-0000-000000000000}") {
            Guid id = Utils.ToGuid(userId);
            List<Enviroment> enviroments = new List<Enviroment>();

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
            return enviroments;
        }

        public bool AddEnviroment (Enviroment enviroment) {
            try
            {
                dbContext.Enviroments.Add(enviroment);
                dbContext.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool UpdateEnviroment (Enviroment enviroment) {
            try
            {
                Enviroment existsEnviroment = dbContext.Enviroments.FirstOrDefault(env => env != null && env.Id == enviroment.Id);
                if (existsEnviroment != null) {
                    dbContext.Enviroments.Update(enviroment);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }

    public class DeseaseStatesDBAPI : DatabaseAPI {
        public DeseaseStatesDBAPI (MedialynxDbContext context) {
            dbContext = context;
        }

        public List<DeseaseStateItem> GetEnum (string itemId = "{00000000-0000-0000-0000-000000000000}") {
            Guid id = Utils.ToGuid(itemId);
            List<DeseaseStateItem> items = new List<DeseaseStateItem>();

            if (id != Guid.Empty)
            {
                string sid = id.ToString("B");
                DeseaseStateItem item = dbContext.DeseaseStates.FirstOrDefault(item => item != null && item.Id == sid);
                items.Add(item);
            }
            else 
            {
                // Add all items
                items.AddRange(dbContext.DeseaseStates);
            }
            return items;
        }

        public bool AddItem (DeseaseStateItem item) {
            try
            {
                dbContext.DeseaseStates.Add(item);
                dbContext.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool UpdateItem (DeseaseStateItem item) {
            try
            {
                DeseaseStateItem existsEnumItem = dbContext.DeseaseStates.FirstOrDefault(itm => itm != null && itm.Id == item.Id);
                if (existsEnumItem != null) {
                    dbContext.DeseaseStates.Update(item);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }

    public class AnalyticalApplicationsDBAPI : DatabaseAPI {
        public AnalyticalApplicationsDBAPI (MedialynxDbContext context) {
            dbContext = context;
        }

        public List<AnalyticalApplicationItem> GetEnum (string itemId = "{00000000-0000-0000-0000-000000000000}") {
            Guid id = Utils.ToGuid(itemId);
            List<AnalyticalApplicationItem> items = new List<AnalyticalApplicationItem>();

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
            return items;
        }

        public bool AddItem (AnalyticalApplicationItem item) {
            try
            {
                dbContext.AnalyticalApplications.Add(item);
                dbContext.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool UpdateItem (AnalyticalApplicationItem item) {
            try
            {
                AnalyticalApplicationItem existsEnumItem = dbContext.AnalyticalApplications.FirstOrDefault(itm => itm != null && itm.Id == item.Id);
                if (existsEnumItem != null) {
                    dbContext.AnalyticalApplications.Update(item);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}