using Hstar.Lara.Utilities.Extensions;
using System.Security.Cryptography;
using System.Text;

namespace Hstar.Lara.Utilities.Security
{
    public static class SHAHelper
    {
        /// <summary>
        /// 计算字符串的HMACSHA256值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key">HMACSHA256的KEY</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeHMACSHA256Hash(this string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var hash = new HMACSHA256(encoding.GetBytes(key));
            var bytes = hash.ComputeHash(encoding.GetBytes(str));
            return bytes.ToHexString(true);
        }
    }
}