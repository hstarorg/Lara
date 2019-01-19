using Lara.Pay.Tenpay.Enums;

namespace Lara.Pay.Tenpay.Params
{
    public class DownloadFundFlowParams : BaseParams
    {
        public DownloadFundFlowParams()
        {
            this.SignType = WechatSignType.HMAC_SHA256;
        }

        /// <summary>
        /// 压缩账单
        /// </summary>
        public bool EnableGzip { get; set; }
    }
}