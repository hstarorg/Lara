using Hstar.Lara.Pay.Tenpay.Enums;

namespace Hstar.Lara.Pay.Tenpay.Params
{
    public class UnifiedorderParams : BaseParams
    {
        public string DeviceInfo { get; set; }

        public string Detail { get; set; }

        public string Attach { get; set; }

        public WechatFeeType FeeType { get; set; }

        public string TimeStart { get; set; }

        public string TimeExpire { get; set; }

        public string GoodsTag { get; set; }

        /// <summary>
        /// no_credit--指定不能使用信用卡支付
        /// </summary>
        public string LimitPay { get; set; }

        public string SceneInfo { get; set; }
    }
}