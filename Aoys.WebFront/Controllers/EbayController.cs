using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Aoys.WebFront.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EbayController : ApiBaseController
    {
        private readonly OAuth2Api _oAuth2Api;
        public EbayController(ILoggerFactory logFactory) : base(logFactory)
        {
            CredentialUtil.Load("./ebay-config.yml");
            _oAuth2Api = new OAuth2Api();

        }
        [HttpGet]
        public IActionResult Authorization()
        {
         
        
            var scopes = new List<string> {
              "https://api.ebay.com/oauth/api_scope",
"https://api.ebay.com/oauth/api_scope/buy.order.readonly",
"https://api.ebay.com/oauth/api_scope/buy.guest.order",
"https://api.ebay.com/oauth/api_scope/sell.marketing.readonly",
"https://api.ebay.com/oauth/api_scope/sell.marketing",
"https://api.ebay.com/oauth/api_scope/sell.inventory.readonly",
"https://api.ebay.com/oauth/api_scope/sell.inventory",
"https://api.ebay.com/oauth/api_scope/sell.account.readonly",
"https://api.ebay.com/oauth/api_scope/sell.account",
"https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly",
"https://api.ebay.com/oauth/api_scope/sell.fulfillment",
"https://api.ebay.com/oauth/api_scope/sell.analytics.readonly",
"https://api.ebay.com/oauth/api_scope/sell.marketplace.insights.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.catalog.readonly",
"https://api.ebay.com/oauth/api_scope/buy.shopping.cart",
"https://api.ebay.com/oauth/api_scope/buy.offer.auction",
"https://api.ebay.com/oauth/api_scope/commerce.identity.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.identity.email.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.identity.phone.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.identity.address.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.identity.name.readonly",
"https://api.ebay.com/oauth/api_scope/commerce.identity.status.readonly",
"https://api.ebay.com/oauth/api_scope/sell.finances",
"https://api.ebay.com/oauth/api_scope/sell.item.draft",
"https://api.ebay.com/oauth/api_scope/sell.payment.dispute",
"https://api.ebay.com/oauth/api_scope/sell.item"
            };
            var authorizationUrl = _oAuth2Api.GenerateUserAuthorizationUrl(OAuthEnvironment.SANDBOX, scopes, "123456");

            return Redirect(authorizationUrl);

          
        }

        /// <summary>
        /// Ebay用户授权返回
        /// </summary>
        [HttpGet]
        public IActionResult ExchangeCode([FromQuery]string code, [FromQuery]int expires_in, [FromQuery]string state)
        {
            _logger.LogDebug($"有请求进入,{Request.QueryString}");
            var oAuthResponse = _oAuth2Api.ExchangeCodeForAccessToken(OAuthEnvironment.SANDBOX, code);

            _logger.LogDebug($"有请求进入,{JsonConvert.SerializeObject(oAuthResponse)}");

            return Ok(oAuthResponse);
            //var nextAccessToken = oAuth2Api.GetAccessToken(OAuthEnvironment.SANDBOX, oAuthResponse.RefreshToken.Token, scopes);
        }
    }
}