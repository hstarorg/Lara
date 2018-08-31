using System;
using System.Collections.Generic;
using System.Text;

namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class CloseOrderParams
    {
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;
    }
}
