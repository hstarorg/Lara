namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class BatchQueryOrderCommentParams
    {
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;

        public int Limit { get; set; } = 200;
    }
}
