using System;

namespace Hstar.Core.Log
{
    public interface ILogProvider
    {
        void Trace(string errMsg, Exception ex);

        void Debug(string errMsg, Exception ex);

        void Info(string errMsg, Exception ex);

        void Warn(string errMsg, Exception ex);

        void Error(string errMsg, Exception ex);

        void Fatal(string errMsg, Exception ex);

    }
}
