using System;
using Hstar.Core.Cache;
using Hstar.Core.ConsoleDemo.Providers;
using Hstar.Core.Ioc;
using Hstar.Core.Log;
using Hstar.Core.Serializer;

namespace Hstar.Core.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 日志
            LogHelper.SetLogProvider(new NLogProvider());
            LogHelper.Debug("fdsfds",new Exception());

            //缓存
            CacheHelper.SetCacheProvider(new MemoryCacheProvider());
            CacheHelper.Set("aa","sss");
            var ss = CacheHelper.Get("aa");
            Console.WriteLine(ss);

            //IOC
            IocHelper.SetIocProvider(new AutofacProvider());
            var test1=IocHelper.GetInstance<Test1>();
            Console.WriteLine(test1.GetTest());

            //Json
            JsonSerializerHelper.SetJsonProvider(new FastJsonProvider());
            //FastJSON不支持匿名类型
            ss = test1.TestJson();
            Console.WriteLine(ss);
            Console.ReadKey();
        }
    }
}
