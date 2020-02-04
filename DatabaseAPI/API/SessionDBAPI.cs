using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    public class SessionDBAPI
    {
        public Session Get(string sessionId)
        {
            Guid id = Utils.ToGuid(sessionId, false);
            using (var dbContext = new MedialynxDbSessionContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.Sessions.FirstOrDefault(session => session != null && session.Id == sid);
                }
            }
            return null;
        }

        public Session GetByUser(string userId)
        {
            Guid id = Utils.ToGuid(userId);
            using (var dbContext = new MedialynxDbSessionContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    return dbContext.Sessions.FirstOrDefault(session => session != null && session.UserId == sid);
                }
            }
            return null;
        }

        internal void Add(Session session)
        {
            using (var dbContext = new MedialynxDbSessionContext()) {
                dbContext.Sessions.Add(session);
                dbContext.SaveChanges();
            }
        }

        internal void Update(Session session)
        {
            using (var dbContext = new MedialynxDbSessionContext()) {
                Session existsSession = dbContext.Sessions.FirstOrDefault(s => s != null && s.Id == session.Id);
                if (existsSession != null)
                {
                    if (Utils.CopyPropertyValues<Session>(session, existsSession))
                    {
                        dbContext.Sessions.Update(existsSession);
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        internal void Delete(string userId)
        {
            using (var dbContext = new MedialynxDbSessionContext()) {
                Guid id = Utils.ToGuid(userId);
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    IEnumerable<Session> sessions = dbContext.Sessions.Where(session => session != null && session.Id == sid);
                    dbContext.Sessions.RemoveRange(sessions);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}