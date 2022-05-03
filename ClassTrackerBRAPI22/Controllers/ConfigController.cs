using ClassTrackerBRAPI22.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerBRAPI22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        IConfiguration _config;
        public ConfigController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public IActionResult GetSetting()
        {
            Settings settings = new Settings()
            {
                first = _config.GetValue<string>("Settings:first"),
                second = _config.GetValue<string>("Settings:second"),
                third = _config.GetValue<string>("Settings:third"),
                fourth = _config.GetValue<string>("Settings:fourth"),
            };

            return Ok(settings);
        }
    }
}
