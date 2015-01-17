using System;
using Hstar.Core.Log;
using NLog;

namespace Hstar.Core.ConsoleDemo.Providers
{
   public class NLogProvider:ILogProvider
   {
       private readonly Logger logger;

       public NLogProvider(string loggerName="*")
       {
           var logFactory = new LogFactory();
           logger = logFactory.GetLogger(loggerName);
           
       }
       public void Trace(string errMsg, Exception ex)
       {
           logger.Trace(errMsg,ex);
       }

       public void Debug(string errMsg, Exception ex)
       {
           logger.Debug(errMsg, ex);
       }

       public void Info(string errMsg, Exception ex)
       {
           logger.Info(errMsg, ex);
       }

       public void Warn(string errMsg, Exception ex)
       {
           logger.Warn(errMsg, ex);
       }

       public void Error(string errMsg, Exception ex)
       {
           logger.Error(errMsg, ex);
       }

       public void Fatal(string errMsg, Exception ex)
       {
           logger.Fatal(errMsg, ex);
       }
    }
}
