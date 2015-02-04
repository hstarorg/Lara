using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hstar.Core.Serializer;

namespace Hstar.Core.ConsoleDemo.Providers
{
    /// <summary>
    /// Jil 需要.Net 4.5支持
    /// </summary>
    class JilJsonProvider:IJsonSerializerProvider
    {
        public string Serialize(object obj, string datetimeFormat = null)
        {
            throw new NotImplementedException();
        }

        public T Deserialize<T>(string jsonString)
        {
            throw new NotImplementedException();
        }
    }
}
