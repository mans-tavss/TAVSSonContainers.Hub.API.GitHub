using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub.API.Controllers.V1
{
    
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _NS;

        public NotificationsController(INotificationsService NS)
        {
            _NS = NS;
        }
    }
}