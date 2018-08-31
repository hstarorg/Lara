namespace Hstar.Lara.Pay.Tenpay.Models
{
    public class DownloadBillParams
    {
        public WechatSignType SignType { get; set; } = WechatSignType.MD5;

        public bool EnalbeGzip { get; set; }
    }
}
