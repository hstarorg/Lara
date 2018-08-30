using Hstar.Lara.Pay.Tenpay.Models;

namespace Hstar.Lara.Pay.Tenpay
{
    public class WechatPayClient
    {
        private readonly WechatPaySettings settings;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appId">公众账号ID</param>
        /// <param name="appSecret">APPID唯一凭证密钥</param>
        /// <param name="mchId">商户号</param>
        /// <param name="key">商户支付密钥Key，在商户平台（https://pay.weixin.qq.com）可以拿到</param>
        /// <param name="notifyUrl">通知URL地址，不能带参数</param>
        public WechatPayClient(string appId, string appSecret, string merchantId, string key, string notifyUrl)
        {
            this.settings = new WechatPaySettings
            {
                AppId = appId,
                AppSecret = appSecret,
                MerchantId = merchantId,
                Key = key,
                NotifyUrl = notifyUrl
            };
        }
        /// <summary>
        /// 统一下单（商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易会话标识后再在APP里面调起支付。）
        /// 接口链接：https://api.mch.weixin.qq.com/pay/unifiedorder
        /// 不需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名，参考：https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=4_3</param>
        /// <param name="body">商品描述</param>
        /// <param name="outTradeNO">商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*且在同一个商户号下唯一</param>
        /// <param name="totalFee">订单总金额，单位为分</param>
        /// <param name="spbillCreateIP">用户端实际ip</param>
        /// <param name="tradeType">支付类型</param>
        /// <param name="optionalParams">可选的支付参数</param>
        public void Unifiedorder(string nonceStr, string sign, string body, string outTradeNO, int totalFee, string spbillCreateIP, WechatTradeType tradeType, UnifiedorderParams optionalParams = null)
        {

        }

        /// <summary>
        /// 查询订单（提供所有微信支付订单的查询，商户可以通过该接口主动查询订单状态，完成下一步的业务逻辑）
        /// 接口链接：https://api.mch.weixin.qq.com/pay/orderquery
        /// 不需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名</param>
        /// <param name="orderNumber">订单号（微信的订单号、商户系统内部的订单号二选一）</param>
        /// <param name="isOutTradeNO">是否是商家订单号，默认false</param>
        public void QueryOrder(string nonceStr, string sign, string orderNumber, bool isOutTradeNO = false)
        {
        }

        /// <summary>
        /// 关闭订单
        /// 接口链接：https://api.mch.weixin.qq.com/pay/closeorder
        /// 不需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名</param>
        /// <param name="outTradeNO"></param>
        public void CloseOrder(string nonceStr, string sign, string outTradeNO)
        {

        }


        public void QueryRefund(string nonceStr, string sign)
        {

        }

        public void DownloadBill()
        {

        }

        public void BatchQueryOrderComment()
        {

        }
    }
}
