using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aoys.WebFront.Models.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;

namespace Aoys.WebFront.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ApiBaseController
    {
        public HomeController( ILoggerFactory logFactory) : base(logFactory)
        {
        }
       
        //[HttpGet]
        //public async Task<> Get()
        //{
        //    _logger.LogDebug($"有请求进入,{Request.QueryString}");
        //   return 
        //}
    }
}