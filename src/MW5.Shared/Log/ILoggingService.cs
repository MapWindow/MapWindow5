using System;
using System.Collections.Generic;

namespace MW5.Shared.Log
{
    public interface ILoggingService: IApplicationCallback
    {
        event EventHandler<LogEventArgs> EntryAdded;
        void Info(string msg, params object[] param);
        void Debug(string msg, params object[] param);
        void Error(string msg, Exception ex = null, params object[] param);
        void Warn(string msg, Exception ex = null, params object[] param);
        void Fatal(string msg, Exception ex = null, params object[] param);
        IReadOnlyList<ILogEntry> Entries { get; }
    }
}
