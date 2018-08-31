namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class DownloadFundFlowParams
    {
        /// <summary>
        /// 签名类型，目前仅支持HMAC-SHA256
        /// </summary>
        public WechatSignType SignType { get; set; } = WechatSignType.HMAC_SHA256;

        /// <summary>
        /// 压缩账单
        /// </summary>
        public bool EnableGzip { get; set; }
    }
}
