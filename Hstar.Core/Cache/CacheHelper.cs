using System;
namespace Hstar.Core.Cache
{
    public static class CacheHelper
    {
        private static ICacheProvider staticCacheProvider;

        public static void SetCacheProvider(ICacheProvider cacheProvider)
        {
            staticCacheProvider = cacheProvider;
        }

        private static void CheckCacheProviderNotNull()
        {
            if (staticCacheProvider == null)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("使用Log之前，请先调用CacheHelper.SetCacheProvider初始化！");
            }
        }
        /// <summary>
        /// 拉取缓存数据
        /// </summary>
        /// <param name="key">数据key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            CheckCacheProviderNotNull();
            return staticCacheProvider.Get(key);
        }

        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <param name="key">数据key</param>
        /// <param name="value">数据value</param>
        /// <param name="dateTimeOffset">过期时间</param>
        public static void Set(string key,object value,DateTimeOffset dateTimeOffset=default(DateTimeOffset))
        {
            CheckCacheProviderNotNull();
            staticCacheProvider.Set(key,value);
        }
    }
}
