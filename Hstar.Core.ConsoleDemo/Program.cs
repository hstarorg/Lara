using System;
using Hstar.Core.Cache;
using Hstar.Core.ConsoleDemo.Providers;
using Hstar.Core.Log;

namespace Hstar.Core.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.SetLogProvider(new NLogProvider());
            LogHelper.Debug("fdsfds",new Exception());
            CacheHelper.SetCacheProvider(new MemoryCacheProvider());
            CacheHelper.Set("aa","sss");
            var ss = CacheHelper.Get("aa");
            Console.ReadKey();
        }
    }
}
