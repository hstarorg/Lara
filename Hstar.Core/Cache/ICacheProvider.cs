
using System;

namespace Hstar.Core.Cache
{
    public interface ICacheProvider
    {
        object Get(string key);

        void Set(string key, object value,DateTimeOffset dateTimeOffset=default(DateTimeOffset));
    }
}
