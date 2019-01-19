using Lara.Pay.Tenpay.Enums;

namespace Lara.Pay.Tenpay.Params
{
    public class BaseParams
    {
        /// <summary>
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;
    }
}