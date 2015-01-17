using System;

namespace Hstar.Core.Log
{
    public static class LogHelper
    {
        private static ILogProvider staticLogProvider;
        public static void SetLogProvider(ILogProvider logProvider)
        {
            staticLogProvider = logProvider;
        }

        private static void CheckLogProviderNotNull()
        {
            if (staticLogProvider == null)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("使用Log之前，请先调用LogHelper.SetLogProvider初始化！");
            }
        }

        public static void Trace(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Trace(errMsg, ex);
        }

        public static void Debug(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Debug(errMsg, ex);
        }

        public static void Info(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Info(errMsg, ex);
        }

        public static void Warn(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Warn(errMsg, ex);
        }

        public static void Error(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Error(errMsg, ex);
        }
        public static void Fatal(string errMsg, Exception ex)
        {
            CheckLogProviderNotNull();
            staticLogProvider.Fatal(errMsg, ex);
        }
    }
}
