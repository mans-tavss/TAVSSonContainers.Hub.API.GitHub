using Hub.API.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hub.API.Services
{
    public class ChannelsService : IChannelsService
    {
        private readonly IMongoCollection<Domain.Channel> _channel;
        public ChannelsService(IChannelsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _channel = database.GetCollection<Domain.Channel>(settings.ChannelsCollectionName);
        }



    }
}
