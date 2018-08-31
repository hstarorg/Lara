namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class RefundOrderParams
    {
        /// <summary>
        /// 签名类型
        /// </summary>
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;

        /// <summary>
        /// 退款货币种类
        /// </summary>
        public WechatFeeType RefundFeeType { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundDesc { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        public RefundAccountType RefundAccount { get; set; }

        /// <summary>
        /// 退款结果通知url（如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效。）
        /// </summary>
        public string NotifyUrl { get; set; }
    }
}
