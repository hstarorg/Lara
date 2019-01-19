namespace Lara.Pay.Tenpay.Request
{
    public class BaseWechatRequest
    {
        public string AppId { get; set; }

        public string MerchantId { get; set; }

        public string NonceStr { get; set; }

        public string Sign { get; set; }
    }
}