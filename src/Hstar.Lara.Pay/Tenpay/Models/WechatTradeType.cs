namespace Hstar.Lara.Pay.Tenpay.Models
{
    public enum WechatTradeType
    {
        /// <summary>
        /// App支付
        /// </summary>
        APP,

        /// <summary>
        /// 公众号支付
        /// </summary>
        JSAPI,

        /// <summary>
        /// 原生扫码支付
        /// </summary>
        NATIVE,

        /// <summary>
        /// 刷卡支付
        /// </summary>
        MICROPAY
    }
}