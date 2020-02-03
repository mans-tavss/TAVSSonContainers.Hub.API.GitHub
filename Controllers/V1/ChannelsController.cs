using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.API.Contracts.V1;
using Hub.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub.API.V1.Controllers
{
    
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelsService _ChaneelService;

        public ChannelsController(IChannelsService channelsService)
        {
            _ChaneelService = channelsService;
        }

    }
}