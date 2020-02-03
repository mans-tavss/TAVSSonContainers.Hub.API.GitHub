using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Options
{
    public class ChannelsDatabaseSettings : IChannelsDatabaseSettings
    {
        public string ChannelsCollectionName { get ; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IChannelsDatabaseSettings
    {
        string ChannelsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
