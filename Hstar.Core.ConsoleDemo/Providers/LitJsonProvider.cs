using Hstar.Core.Serializer;
using LitJson;

namespace Hstar.Core.ConsoleDemo.Providers
{
    public class LitJsonProvider:IJsonSerializerProvider
    {
        public string Serialize(object obj, string datetimeFormat = null)
        {
            return JsonMapper.ToJson(obj);
        }

        public T Deserialize<T>(string jsonString)
        {
            return JsonMapper.ToObject<T>(jsonString);
        }
    }
}
