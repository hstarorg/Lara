using System.Text;

namespace Hstar.Lara.Utilities.Extensions
{
    public static class ByteArrayExtension
    {
        /// <summary>
        /// 将字符串数组转换为十六进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="toUpper">[可选]是否需要转换为大写字符串，默认false</param>
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
