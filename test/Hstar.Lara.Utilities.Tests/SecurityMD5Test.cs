using Hstar.Lara.Utilities.Security;
using System.Text;
using Xunit;

namespace Hstar.Lara.Utilities.Tests
{
    public class SecurityMD5Test
    {
        [Theory]
        [InlineData("", "d41d8cd98f00b204e9800998ecf8427e")]
        [InlineData("admin", "21232f297a57a5a743894a0e4a801fc3")]
        [InlineData("123456", "e10adc3949ba59abbe56e057f20f883e")]
        [InlineData("12345678901234567890", "fd85e62d9beb45428771ec688418b271")]
        [InlineData("中文", "a7bac2239fcdcb3a067903d8077c4a07")]
        public void Test_Base_MD5(string str, string expected)
        {
            var value = MD5Helper.ComputeMD5Hash(str);
            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData("", "d41d8cd98f00b204e9800998ecf8427e")]
        [InlineData("admin", "19a2854144b63a8f7617a6f225019b12")]
        [InlineData("123456", "ce0bfd15059b68d67688884d7a3d3e8c")]
        [InlineData("12345678901234567890", "6ee0e5753a9debb78c31074ca18cf0eb")]
        [InlineData("中文", "73c6c8cd2f94355ef015e5265d5e65b1")]
        public void Test_Base_MD5_With_Unicode_Encoding(string str, string expected)
        {
            var value = MD5Helper.ComputeMD5Hash(str, Encoding.Unicode);
            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData("", "7ea66aaa771c3c3c2b146df55f69e653")]
        [InlineData("admin", "f044f0f029bc033e893ae5b3a2d45864")]
        [InlineData("123456", "b8e91a37b5a5b21ea7aec961b3eea43b")]
        [InlineData("12345678901234567890", "7ef0886c11ac989ea87a06a45d8c6b9c")]
        [InlineData("中文", "9ccf6bd70dc8d8487b867369e6653965")]
        public void Test_Base_HMAC_MD5(string str, string expected)
        {
            var key = "12345";
            var value = MD5Helper.ComputeHMACMD5Hash(str, key);
            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData("", "5758b7e60fbbacc41be92b37d77e5d56")]
        [InlineData("admin", "ca9f5169c94708e7ec61f4ef9e235c2b")]
        [InlineData("123456", "8149b7635ade6cf9bc4794f66d469835")]
        [InlineData("12345678901234567890", "fef06b4b5306820f7015c78af05e8735")]
        [InlineData("中文", "5000ce8ea09c2f00dee1ef411be0da97")]
        public void Test_Base_HMAC_MD5_With_Unicode_Encoding(string str, string expected)
        {
            var key = "99999";
            var value = MD5Helper.ComputeHMACMD5Hash(str, key, Encoding.Unicode);
            Assert.Equal(expected, value);
        }
    }
}
