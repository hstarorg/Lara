using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Lara.Cache
{
    public class CacheItem<T>
    {
        private readonly ICacheEntry cacheEntry;
        private readonly Func<Task<T>> updateFunc;

        public CacheItem(ICacheEntry cacheEntry, Func<Task<T>> updateFunc)
        {
            this.cacheEntry = cacheEntry;
            this.updateFunc = updateFunc;
        }

        public async Task<T> GetValue()
        {
            var cacheValue = (T)Convert.ChangeType(this.cacheEntry.Value, typeof(T));
            if (cacheValue == null)
            {
                cacheValue = await this.updateFunc();
                this.cacheEntry.SetValue(cacheEntry);
            }
            return cacheValue;
        }

        public async Task SetValue(T value)
        {
            await Task.Run(() => this.cacheEntry.SetValue(value));
        }
    }
}