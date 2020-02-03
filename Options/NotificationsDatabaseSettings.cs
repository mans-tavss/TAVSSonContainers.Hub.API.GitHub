using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Options
{
    public class NotificationsDatabaseSettings : INotificationsDatabaseSettings
    {
        public string NotificationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface INotificationsDatabaseSettings
    {
        string NotificationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
