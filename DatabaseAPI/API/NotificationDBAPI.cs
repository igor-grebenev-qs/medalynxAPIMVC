using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    public class NotificationDBAPI
    {
        public List<Notification> Get(string notificationId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(notificationId);
            List<Notification> notifications = new List<Notification>();

            using (var dbContext = new MedialynxDbNotificationsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Notification notification = dbContext.Notifications.FirstOrDefault(item => item != null && item.Id == sid);
                    if (notification != null) {
                        notifications.Add(notification);
                    }
                }
                else
                {
                    // Add all items
                    notifications.AddRange(dbContext.Notifications);
                }
            }
            return notifications;
        }

        public List<Notification> GetByProject(string projectId)
        {
            Guid id = Utils.ToGuid(projectId);
            List<Notification> notifications = new List<Notification>();

            using (var dbContext = new MedialynxDbNotificationsContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    notifications.AddRange(dbContext.Notifications.Where(item => item != null && item.ProjectId == sid));
                }
            }
            return notifications;
        }

        public void Add(Notification notification)
        {
            using (var dbContext = new MedialynxDbNotificationsContext()) {
                dbContext.Notifications.Add(notification);
                dbContext.SaveChanges();
            }
        }

        public void Update(Notification notification)
        {
            using (var dbContext = new MedialynxDbNotificationsContext()) {
                Notification existsNotification = dbContext.Notifications.FirstOrDefault(n => n != null && n.Id == notification.Id);
                if (existsNotification != null)
                {
                    if (Utils.CopyPropertyValues<Notification>(notification, existsNotification))
                    {
                        dbContext.Notifications.Update(existsNotification);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}