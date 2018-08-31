using Hstar.Lara.Pay.Tenpay.Models;
using System;

namespace Hstar.Lara.Pay.Tenpay
{
    public class WechatPayClient
    {
        private readonly WechatPaySettings settings;

        const string WechatPayApiHost = "https://api.mch.weixin.qq.com";

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
        /// 统一下单
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
        /// 查询订单
        /// 提供所有微信支付订单的查询，商户可以通过该接口主动查询订单状态，完成下一步的业务逻辑
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
        /// <param name="outTradeNO">商户自定义订单ID</param>
        /// <param name="optionalParams">可选配置参数</param>
        public void CloseOrder(string nonceStr, string sign, string outTradeNO, CloseOrderParams optionalParams = null)
        {

        }

        /// <summary>
        /// 查询退款
        /// 提交退款申请后，通过调用该接口查询退款状态。退款有一定延时，用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。
        /// 接口链接：https://api.mch.weixin.qq.com/pay/refundquery
        /// 不需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名</param>
        /// <param name="orderNumberType">订单号类型</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="optionalParams">可选配置参数</param>
        public void QueryRefund(string nonceStr, string sign, OrderNumberType orderNumberType, string orderNumber, QueryRefundParams optionalParams = null)
        {

        }

        /// <summary>
        /// 下载对账单
        /// 商户可以通过该接口下载历史交易清单。比如掉单、系统错误等导致商户侧和微信侧数据不一致，通过对账单核对后可校正支付状态。
        /// 接口链接：https://api.mch.weixin.qq.com/pay/downloadbill
        /// 不需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名</param>
        /// <param name="billDate">对账单日期</param>
        /// <param name="billType">账单类型</param>
        /// <param name="optionalParams">可选配置参数</param>
        public void DownloadBill(string nonceStr, string sign, DateTime billDate, WechatBillType billType = WechatBillType.ALL, DownloadBillParams optionalParams = null)
        {

        }

        /// <summary>
        /// 拉取订单评价数据
        /// 商户可以通过该接口拉取用户在微信支付交易记录中针对你的支付记录进行的评价内容
        /// 接口链接：https://api.mch.weixin.qq.com/billcommentsp/batchquerycomment
        /// 需要证书
        /// </summary>
        /// <param name="nonceStr">随机字符串，不长于32位。</param>
        /// <param name="sign">签名</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="offset">位移（偏移量）</param>
        /// <param name="optionalParams">可选配置参数</param>
        public void BatchQueryOrderComment(string nonceStr, string sign, DateTime beginTime, DateTime endTime, int offset = 0, BatchQueryOrderCommentParams optionalParams = null)
        {

        }

        /// <summary>
        /// 申请退款
        /// 当交易发生之后一段时间内，由于买家或者卖家的原因需要退款时，卖家可以通过退款接口将支付款退还给买家，微信支付将在收到退款请求并且验证成功之后，按照退款规则将支付款按原路退到买家帐号上。
        /// 接口链接：https://api.mch.weixin.qq.com/secapi/pay/refund
        /// 请求需要双向证书
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <param name="sign"></param>
        /// <param name="orderNumberType"></param>
        /// <param name="orderNumber"></param>
        /// <param name="outRefundNo"></param>
        /// <param name="totalFee"></param>
        /// <param name="refundFee"></param>
        /// <param name="optionalParams"></param>
        public void RefundOrder(string nonceStr, string sign, OrderNumberType orderNumberType, string orderNumber, string outRefundNo, int totalFee, int refundFee, RefundOrderParams optionalParams = null)
        {

        }

        /// <summary>
        /// 下载资金账单
        /// 商户可以通过该接口下载自2017年6月1日起 的历史资金流水账单。
        /// 接口链接：https://api.mch.weixin.qq.com/pay/downloadfundflow
        /// 请求需要双向证书
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <param name="sign"></param>
        /// <param name="billDate"></param>
        /// <param name="accountType"></param>
        /// <param name="optionalParams"></param>
        public void DownloadFundFlow(string nonceStr, string sign, DateTime billDate, WechatAccountType accountType, DownloadFundFlowParams optionalParams = null)
        {

        }
    }
}
