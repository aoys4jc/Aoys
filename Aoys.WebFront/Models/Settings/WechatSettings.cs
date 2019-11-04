using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aoys.WebFront.Models.Settings
{
    public class WechatSettings
    {
        public string AppID { get; set; }

        public string AppSecret { get; set; }

        public string AESKey { get; set; }

        public string Token { get; set; }
    }
}
