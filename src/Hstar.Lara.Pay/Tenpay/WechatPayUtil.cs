using Hstar.Lara.Pay.Tenpay.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace Hstar.Lara.Pay.Tenpay
{
    public static class WechatPayUtil
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="maxLength">指定随机字符串长度，最大32</param>
        /// <returns></returns>
        public static string BuildnNonceStr(int maxLength = 32)
        {
            if (maxLength <= 0 || maxLength > 32)
            {
                throw new ArgumentOutOfRangeException("maxLength必须在1~32之间");
            }
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, maxLength);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="signType">签名类型</param>
        /// <param name="key">安全Key，来自于：微信商户平台(pay.weixin.qq.com)-->账户设置-->API安全-->密钥设置</param>
        /// <param name="data">要传送的参数字典</param>
        /// <returns></returns>
        public static string BuildSign(WechatSignType signType, string key, Dictionary<string, string> data)
        {
            return "";
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
            {
                return "";
            }
            return WebUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
            {
                return "";
            }
            return WebUtility.UrlDecode(str);
        }
    }
}