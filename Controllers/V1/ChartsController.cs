using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.API.Contracts.V1;
using Hub.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly IChartsServices _service;
        public ChartsController(IChartsServices service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.Chart.GetChart)]
        public IActionResult GetChart()
        {
            _service.GetChart();
            return Ok(new { Message = "Successful Transfer" });
        }
    }
}