// -------------------------------------------------------------------------------------------
// <copyright file="ILoggingService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace MW5.Shared.Log
{
    public interface ILoggingService : IApplicationCallback
    {
        IReadOnlyList<ILogEntry> Entries { get; }

        void Clear();

        void Debug(string msg, params object[] param);

        event EventHandler<LogEventArgs> EntryAdded;

        void Error(string msg, Exception ex = null, params object[] param);

        void Fatal(string msg, Exception ex = null, params object[] param);

        void Info(string msg, params object[] param);

        void Init(object context);

        int MessageCount(LogLevel level, bool notDisplayed);

        void Warn(string msg, Exception ex = null, params object[] param);

        void Write(string msg, LogLevel level, params object[] param);
    }
}