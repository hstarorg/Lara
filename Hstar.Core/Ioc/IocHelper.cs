using System;

namespace Hstar.Core.Ioc
{
    public static class IocHelper
    {
        private static IContainerProvider staticIContainerProvider;

        public static void SetIocProvider(IContainerProvider containerProvider)
        {
            staticIContainerProvider = containerProvider;
        }

        private static void CheckContainerProviderNotNull()
        {
            if (staticIContainerProvider == null)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("使用IocContainer之前，请先调用IocHelper.SetIocProvider初始化！");
            }
        }

        /// <summary>
        /// 获取实例对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            CheckContainerProviderNotNull();
            return staticIContainerProvider.GetInstance<T>();
        }
    }
}
