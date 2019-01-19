using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hstar.Lara.Cache.Tests
{
    [TestClass]
    public class SimpleMemoryCacheTest
    {
        private static CacheItem<int> intCache;
        private static int cacheValue = 1;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            intCache = SimpleMemoryCache.Create<int>(() =>
            {
                cacheValue++;
                return Task.Run(() => cacheValue);
            }, cacheValue);
        }

        [DataTestMethod]
        [DataRow(null, 1)]
        [DataRow(2, 2)]
        [DataRow(99999, 99999)]
        [DataRow(-1, -1)]
        [DataRow(0, 0)]
        public void Test_Get_Set_Cache_Value(int? value, int expected)
        {
            if (value != null)
            {
                var setValueTask = intCache.SetValue(value.Value);
                setValueTask.Wait();
            }
            var task = intCache.GetValue();
            task.Wait();
            Assert.AreEqual(expected, task.Result);
        }
    }
}