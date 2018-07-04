using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hstar.Lara.Utilities.Security
{
    public static class MD5Helper
    {
        public static string ComputeMD5Hash(this string str, Encoding encoding = null, Encoding outputEncoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            if (outputEncoding == null)
            {
                outputEncoding = Encoding.UTF8;
            }
            var md5 = MD5.Create();
            var md5Bytes = md5.ComputeHash(encoding.GetBytes(str));
            return outputEncoding.GetString(md5Bytes);
        }

        public static string ComputeHMACMD5Hash(this string str, Encoding encoding = null, Encoding outputEncoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            if (outputEncoding == null)
            {
                outputEncoding = Encoding.UTF8;
            }
            var hmacMD5 = HMACMD5.Create();
            var md5Bytes = hmacMD5.ComputeHash(encoding.GetBytes(str));
            return outputEncoding.GetString(md5Bytes);
        }
    }
}
