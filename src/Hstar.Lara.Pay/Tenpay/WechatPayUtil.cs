using Hstar.Lara.Pay.Tenpay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Hstar.Lara.Pay.Tenpay
{
    public static class WechatPayUtil
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="maxLength">指定随机字符串长度，最大32</param>
        /// <returns></returns>
        public static string BuildNonceStr(int maxLength = 32)
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
            // Step1、对参数按照key=value的格式，并按照参数名ASCII字典序排序如下
            var strA = string.Join("&", data.OrderBy(x => x.Key)
                 .Where(x => !string.IsNullOrWhiteSpace(x.Value) && !string.IsNullOrEmpty(x.Value) && x.Value.Trim() != "")
                 .ToList()
                 .Select(x => $"{x.Key}={UrlEncode(x.Value)}"));
            // Step2、拼接API密钥
            var strSignTemp = $"{strA}&key={UrlEncode(key)}";
            // Step3、签名
            string sign = string.Empty;
            switch (signType)
            {
                case WechatSignType.HMAC_SHA256:
                    sign = ComputeHMACSHA256Hash(strSignTemp, key);
                    break;
                case WechatSignType.MD5:
                    sign = ComputeMD5Hash(strSignTemp);
                    break;
                default:
                    throw new ArgumentException("非法的签名类型");
            }
            return sign.ToUpper();
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

        /// <summary>
        /// 计算Md5签名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ComputeMD5Hash(string str)
        {
            var md5 = MD5.Create();
            var md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return string.Join("", md5Bytes.Select(x => x.ToString("x2")));
        }

        /// <summary>
        /// 计算HMAC-SHA256签名
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ComputeHMACSHA256Hash(string str, string key)
        {
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            return bytes.ToHexString(true);
        }

        /// <summary>
        /// 将字符串数组转换为十六进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="toUpper"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, bool toUpper = false)
        {
            var builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            var hexStr = builder.ToString();
            if (toUpper)
            {
                hexStr = hexStr.ToUpper();
            }
            return hexStr;
        }
    }
}