using System;
using System.Runtime.Caching;
using Hstar.Core.Cache;

namespace Hstar.Core.ConsoleDemo.Providers
{
    public class MemoryCacheProvider : ICacheProvider
    {
        private readonly MemoryCache mc;

        public MemoryCacheProvider()
        {
            mc=new MemoryCache("__mc__");
        }
        public object Get(string key)
        {
            return mc.Get(key);
        }

        public void Set(string key, object value,DateTimeOffset dateTimeOffset=default(DateTimeOffset))
        {
            mc.Set(key, value, dateTimeOffset==default(DateTimeOffset)?DateTimeOffset.MaxValue:dateTimeOffset);
        }
    }
}
