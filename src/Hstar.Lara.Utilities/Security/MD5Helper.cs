using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Hstar.Lara.Utilities.Security
{
    public static class MD5Helper
    {
        public static string ComputeMD5Hash(this string str, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var md5 = MD5.Create();
            var md5Bytes = md5.ComputeHash(encoding.GetBytes(str));
            return string.Join("", md5Bytes.Select(x => x.ToString("x2")));
        }

        public static string ComputeHMACMD5Hash(this string str, string key, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var hmacMD5 = new HMACMD5(encoding.GetBytes(key));
            var md5Bytes = hmacMD5.ComputeHash(encoding.GetBytes(str));
            return string.Join("", md5Bytes.Select(x => x.ToString("x2")));
        }
    }
}
