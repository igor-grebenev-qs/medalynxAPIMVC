using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models.User;

namespace MedalynxAPI
{
    public class UserDBAPI
    {
        public List<User> Get(string userId = "{00000000-0000-0000-0000-000000000000}")
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

        public void Add(User user)
        {
            using (var dbContext = new MedialynxDbUserContext()) {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void Update(User user)
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
        }
    }
}