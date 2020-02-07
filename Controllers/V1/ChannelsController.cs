using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.API.Contracts.V1;
using Hub.API.Contracts.V1.Requests;
using Hub.API.Domain;
using Hub.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub.API.V1.Controllers
{
    
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelsService _ChannelService;
        private static object successfull = new { Status = 1, Message = "Successful Transaction" };
        private static object failed = new { Status = 0, Message = "Failed Transaction" };
        public ChannelsController(IChannelsService channelsService)
        {
            _ChannelService = channelsService;
        }

        [HttpGet(ApiRoutes.Chat.GetChannels)]
        public async Task<IActionResult> GetChannels([FromBody] string UID) => Ok(await _ChannelService.GetChannels(UID));
        [HttpPost(ApiRoutes.Chat.CreateChannel)]
        public async Task<IActionResult> CreateChannel([FromForm] CreateChannelViewModel model)
        {
            var channel = new Channel() {Caption =model.Caption , Name =model.Name , AdminId = model.AdminId };
            var result =await _ChannelService.CreateChannel(channel);
            if (result)
                return Ok(successfull);
            return BadRequest(failed);
        }
        [HttpGet(ApiRoutes.Chat.SearchUser)]
        public async Task<IActionResult> SearchUser([FromBody] string filter) => Ok(await _ChannelService.SearchUser(filter));






    }
}