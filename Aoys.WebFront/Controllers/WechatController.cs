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
    public class WechatController : ControllerBase
    {
        private readonly WechatSettings wechatSettings;
        private readonly ILogger _logger;
        public WechatController(IOptions<WechatSettings> options, ILoggerFactory logFactory)
        {
            wechatSettings = options.Value;
            _logger = logFactory.CreateLogger<WechatController>();
        }
        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        public IActionResult Get([FromQuery]PostModel postModel, [FromQuery]string echostr)
        {
            _logger.LogDebug($"有请求进入,{Request.QueryString}");
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, wechatSettings.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + postModel.Signature + ","
                    + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, wechatSettings.Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }
    }
}