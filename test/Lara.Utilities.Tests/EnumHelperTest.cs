using Hstar.Lara.Utilities.Common;
using System.ComponentModel;
using Xunit;

namespace Hstar.Lara.Utilities.Tests
{
    public class EnumHelperTest
    {
        public enum TestEnum
        {
            Empty,
            Value1,

            [Description("第二个值")]
            Value2
        }

        [Theory]
        [InlineData(TestEnum.Empty, "Empty")]
        [InlineData(TestEnum.Value1, "Value1")]
        [InlineData(TestEnum.Value2, "Value2")]
        public void ConvertStringToEnum(TestEnum expected, string enumText)
        {
            var value = EnumHelper.ToEnum<TestEnum>(enumText);
            Assert.Equal(expected, value);
            value = enumText.ToEnum<TestEnum>();
            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData(TestEnum.Empty, "empty")]
        [InlineData(TestEnum.Value1, "value1")]
        [InlineData(TestEnum.Value2, "VALUE2")]
        [InlineData(TestEnum.Value2, "VAlue2")]
        public void ConvertStringToEnumIngoreCase(TestEnum expected, string enumText)
        {
            var value = EnumHelper.ToEnum<TestEnum>(enumText, true);
            Assert.Equal(expected, value);
            value = enumText.ToEnum<TestEnum>(true);
            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData(TestEnum.Empty, "ABC")]
        [InlineData(TestEnum.Empty, "DEF")]
        [InlineData(TestEnum.Empty, "")]
        public void WillReturnZeroWhenConvertFailed(TestEnum expected, string enumText)
        {
            var value = EnumHelper.ToEnum<TestEnum>(enumText);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void GetEnumEntriesSucess()
        {
            var value = EnumHelper.GetEnumEntries(TestEnum.Empty);
            Assert.Equal(3, value.Count);
            Assert.Equal("Value1", value[1].Item3);
            Assert.Equal("第二个值", value[2].Item3);
        }

        [Fact]
        public void GetEnumEntriesSucess2()
        {
            var value = EnumHelper.GetEnumEntries<TestEnum>();
            Assert.Equal(3, value.Count);
            Assert.Equal("Value1", value[1].Item3);
            Assert.Equal("第二个值", value[2].Item3);
        }

        [Fact]
        public void GetEnumNameTest()
        {
            var enumName = EnumHelper.GetEnumName(TestEnum.Value1);
            Assert.Equal("Value1", enumName);
        }
    }
}