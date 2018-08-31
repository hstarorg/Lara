namespace Hstar.Lara.Pay.Tenpay.Enums
{
    /// <summary>
    /// 仅针对老资金流商户使用
    /// </summary>
    public enum RefundAccountType
    {
        /// <summary>
        /// 未结算资金退款（默认使用未结算资金退款）
        /// </summary>
        REFUND_SOURCE_UNSETTLED_FUNDS,

        /// <summary>
        /// 可用余额退款
        /// </summary>
        REFUND_SOURCE_RECHARGE_FUNDS
    }
}
