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
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly ILogger _logger;
        public ApiBaseController( ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<WechatController>();
        } 
        
        
    }
}