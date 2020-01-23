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

namespace MedalynxAPI {
    public abstract class DatabaseAPI {

    }

    public class UserDBAPI : DatabaseAPI {

        private MedialynxDbContext dbContext = null;

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
            catch {
                return false;
            }
        }

        public bool UpdateUser (User user) {
            try
            {
                User existsUser = dbContext.Users.FirstOrDefault(u => u != null && u.Id == user.Id);

                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}