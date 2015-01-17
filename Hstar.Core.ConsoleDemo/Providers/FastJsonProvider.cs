using System.Collections.Generic;
using fastJSON;
using Hstar.Core.Serializer;

namespace Hstar.Core.ConsoleDemo.Providers
{
    public class FastJsonProvider:IJsonSerializerProvider
    {
        public string Serialize(object obj, string datetimeFormat = null)
        {
            return JSON.ToJSON(obj, new JSONParameters { UseUTCDateTime = true, UseExtensions = false, EnableAnonymousTypes =true});
        }

        public T Deserialize<T>(string jsonString)
        {
            return JSON.ToObject<T>(jsonString);
        }
    }
}
