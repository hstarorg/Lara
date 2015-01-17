using Hstar.Core.Serializer;
using Newtonsoft.Json;
namespace Hstar.Core.ConsoleDemo.Providers
{
    public class JsonNetProvider:IJsonSerializerProvider
    {
        public string Serialize(object obj, string datetimeFormat = null)
        {
            var settings = new JsonSerializerSettings();
            if (!string.IsNullOrEmpty(datetimeFormat))
            {
                settings.DateFormatString = datetimeFormat;
            }
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
