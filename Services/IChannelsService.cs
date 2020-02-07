using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.API.Contracts.V1.Requests;
using Hub.API.Contracts.V1.Responses;
using Hub.API.Domain;
namespace Hub.API.Services
{
    public interface IChannelsService
    {
        Task<Channel> GetChannel(string CID);
        Task<IEnumerable<MinChannelViewModel>> GetChannels(string UID);
        Task<bool> SendMessage(string CID, string UID, Message message);
        Task<bool> CreateChannel(Channel channel);
        Task<bool> DeleteChannel(string CID);
        Task<bool> ModifyChannel(string CID, ModifyChannelViewModel model );
        Task<bool> CreateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> SearchUser(string filter);
        Task<bool> InsertImgtoChannel(string CID);
        Task<bool> InsertImgtoUser(string UID);
    }
}
