using System;

namespace Hstar.Core.Serializer
{
    public static class JsonSerializerHelper
    {
        private static IJsonSerializerProvider staticJsonSerializerProvider;

        public static void SetJsonProvider(IJsonSerializerProvider jsonSerializerProvider)
        {
            staticJsonSerializerProvider = jsonSerializerProvider;
        }

        private static void CheckJsonProviderNotNull()
        {
            if (staticJsonSerializerProvider == null)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("使用JsonSerializer之前，请先调用JsonSerializerHelper.SetJsonProvider初始化！");
            }
        }
        public static string Serialize(object obj, string datetimeFormat = null)
        {
            CheckJsonProviderNotNull();
            return staticJsonSerializerProvider.Serialize(obj, datetimeFormat);
        }

        public static T Deserialize<T>(string jsonString)
        {
            CheckJsonProviderNotNull();
            return staticJsonSerializerProvider.Deserialize<T>(jsonString);
        }
    }
}
