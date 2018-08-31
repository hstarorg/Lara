namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class QueryRefundParams
    {
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public int Offset { get; set; }
    }
}
