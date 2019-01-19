using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Lara.Cache
{
    public static class SimpleMemoryCache
    {
        private static MemoryCache memoryCache;

        static SimpleMemoryCache()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions { });
        }

        public static CacheItem<T> Create<T>(Func<Task<T>> func, T defaultValue = default(T), MemoryCacheEntryOptions options = null)
        {
            var cacheKey = Guid.NewGuid().ToString();
            var cacheEntry = memoryCache.CreateEntry(cacheKey);
            if (options != null)
            {
                cacheEntry.SetOptions(options);
            }
            cacheEntry.SetValue(defaultValue);
            return new CacheItem<T>(cacheEntry, func);
        }
    }
}