namespace Hstar.Lara.Pay.Tenpay.Enums
{
    /// <summary>
    /// 订单号类型
    /// 微信订单号查询的优先级是： refund_id > out_refund_no > transaction_id > out_trade_no
    /// </summary>
    public enum OrderNumberType
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        TransactionId,

        /// <summary>
        /// 商户订单号
        /// </summary>
        OutTradeNO,

        /// <summary>
        /// 商户退款单号
        /// </summary>
        OutRefundNO,

        /// <summary>
        /// 微信退款单号
        /// </summary>
        RefundId
    }
}