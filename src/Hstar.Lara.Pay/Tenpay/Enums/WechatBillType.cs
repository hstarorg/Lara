namespace Hstar.Lara.Pay.Tenpay.Enums
{
    public enum WechatBillType
    {
        /// <summary>
        /// 当日所有订单信息，默认值
        /// </summary>
        ALL,

        /// <summary>
        /// 当日成功支付的订单
        /// </summary>
        SUCCESS,

        /// <summary>
        /// 当日退款订单
        /// </summary>
        REFUND,

        /// <summary>
        /// 当日充值退款订单
        /// </summary>
        RECHARGE_REFUND
    }
}
