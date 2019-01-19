using Hstar.Lara.Pay.Tenpay;
using Hstar.Lara.Pay.Tenpay.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hstar.Lara.Pay.Tests
{
    public class WechatPayUtilTest
    {
        [Theory]
        [InlineData(5), InlineData(1), InlineData(32)]
        public void Test_Build_Valid_Nonce_Str(int maxLength)
        {
            var nonceStr = WechatPayUtil.BuildNonceStr(maxLength);
            Assert.Equal(maxLength, nonceStr.Length);
        }

        [Theory]
        [InlineData(-1), InlineData(0), InlineData(33)]
        public void Test_Build_Nonce_Str_Throw_Error(int maxLength)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var nonceStr = WechatPayUtil.BuildNonceStr(maxLength);
            });
        }

        [Fact]
        public void Test_Build_Sign_OK()
        {
            var data = new Dictionary<string, string>
            {
                { "appid", "wxd930ea5d5a258f4f" },
                { "mch_id", "10000100" },
                { "device_info", "1000" },
                { "body", "test" },
                { "nonce_str", "ibuaiVcKdpRxkhJA" }
            };
            var key = "192006250b4c09247ec02edce69f6a2d";
            var sign = WechatPayUtil.BuildSign(WechatSignType.MD5, key, data);
            Assert.Equal("9A0A8659F005D6984697E2CA0A9CF3B7", sign); // 验证Md5
            sign = WechatPayUtil.BuildSign(WechatSignType.HMAC_SHA256, key, data);
            Assert.Equal("6A9AE1657590FD6257D693A078E1C3E4BB6BA4DC30B23E0EE2496E54170DACD6", sign); // 验证HMAC_SHA256
        }
    }
}
