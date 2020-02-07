﻿using Hub.API.Contracts.V1.Requests;
using Hub.API.Contracts.V1.Responses;
using Hub.API.Domain;
using Hub.API.Hubs;
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
        private readonly IMongoCollection<Domain.User> _user;
        private readonly ChatHub _hub;
        public ChannelsService(IChannelsDatabaseSettings channelsettings, IUsersDatabaseSettings usresettings, ChatHub hub)
        {
            var client = new MongoClient(channelsettings.ConnectionString);
            var database = client.GetDatabase(channelsettings.DatabaseName);
            _hub = hub;
            _channel = database.GetCollection<Domain.Channel>(channelsettings.ChannelsCollectionName);
            _user = database.GetCollection<User>(usresettings.UsersCollectionName);
        }
        #region Channel and Mesaages

        public async Task<bool> CreateChannel(Domain.Channel channel)
        {
            var Channel = new Domain.Channel()
            {
                AdminId = channel.AdminId,
                Caption = channel.Caption,
                ChannelId = channel.ChannelId,
                ImgPath = "",
                Messages = new List<Message>(),
                Name = channel.Name,
                Status = false,
                Users = new List<User>() { channel.Users.FirstOrDefault() }
            };
            try
            {
                await _channel.InsertOneAsync(Channel);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<bool> DeleteChannel(string CID)
        {
            var ack = await _channel.DeleteOneAsync(x => x.ChannelId == CID);
            if (ack.IsAcknowledged)
            {
                return true;
            }
            return false;
        }

        public async Task<Domain.Channel> GetChannel(string CID) 
        {
           var result = await _channel.FindAsync(x => x.ChannelId == CID);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<MinChannelViewModel>> GetChannels(string UID)
        {
            var result = await _channel.FindAsync(x =>x.Users.Exists(y => y.UserId == UID));
            return result.ToList()
                .Select(x =>
                new MinChannelViewModel { Caption = x.Caption ,Name =x.Name , ChannelId=x.ChannelId,ImgPath =x.ImgPath,Status= x.Status});
        }
        #endregion

        public async Task<bool> CreateUser( User user)
        {
            try
            {
                await _user.InsertOneAsync(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
             
        }

 

        public async Task<IEnumerable<User>> SearchUser(string filter)
        {
            var users = await _user.FindAsync(x => x.Name.Contains(filter));

            return users.ToList();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _user.FindAsync(x =>true);

            return users.ToList();
        }

        public async Task<bool> InsertImgtoChannel(string CID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertImgtoUser(string UID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ModifyChannel(string CID, ModifyChannelViewModel model )
        {
            var channel = await GetChannel(CID);
            channel.Caption = model.Caption;
            channel.Name = channel.Name;
            var ack = await _channel.ReplaceOneAsync( x => x.ChannelId == channel.ChannelId , channel);
            return ack.IsAcknowledged;
        }

        public async Task<bool> SendMessage(string CID, string UID , Message message)
        {
           await _hub.GroupCast(UID, CID, message.Body);
            var channel = await GetChannel(CID);
            channel.Messages.Add(message);
            var ack = await _channel.ReplaceOneAsync( x=>x.ChannelId ==CID , channel );
            return ack.IsAcknowledged;
        }
    }
}
