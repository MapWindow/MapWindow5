using System;
using System.Collections.Generic;
using System.ComponentModel;
using log4net;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Services.Concrete
{
    public class LoggingService: ILoggingService
    {
        private readonly ILog _log4NetLogger;

        private readonly SortableBindingList<ILogEntry> _entries = new SortableBindingList<ILogEntry>();

        private IAppContext _context;

        public event EventHandler<LogEventArgs> EntryAdded;

        public LoggingService()
        {
            _log4NetLogger = LogManager.GetLogger(typeof(Logger));

            if (Logger.Current == null)
            {
                Logger.Current = this;
            }
        }

        public void Init(object appContext)
        {
            var context = appContext as IAppContext;
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            var broadcaster = _context.Container.Resolve<IBroadcasterService>();
            EntryAdded += (s, e) =>
            {
                broadcaster.BroadcastEvent(p => p.LogEntryAdded_, this, new LogEventArgs(e.Entry));
            };
        }

        private bool AppContextReady()
        {
            return _context != null && _context.Initialized;
        }

        void IApplicationCallback.Error(string tagOfSender, string errorMsg)
        {
            Debug(errorMsg);
        }

        void IApplicationCallback.Progress(string tagOfSender, int percent, string message)
        {
            if (AppContextReady())
            {
                _context.StatusBar.ShowProgress(message, percent);
            }
        }

        void IApplicationCallback.ClearProgress()
        {
            if (AppContextReady())
            {
                _context.StatusBar.HideProgress();
            }
        }

        public void Info(string msg, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Info);

        }

        public void Debug(string msg, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Debug);
        }

        public void Warn(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Warn, ex);
        }

        public void Error(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Error, ex);
        }

        public void Fatal(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Fatal, ex);
        }

        public void Write(string msg, LogLevel level, params object[] param)
        {
            switch (level)
            {
                case LogLevel.Info:
                case LogLevel.All:
                    Info(msg, param);
                    break;
                case LogLevel.Debug:
                    Debug(msg, param);
                    break;
                case LogLevel.Warn:
                    Warn(msg, null, param);
                    break;
                case LogLevel.Error:
                    Error(msg, null, param);
                    break;
                case LogLevel.Fatal:
                    Fatal(msg, null, param);
                    break;
            }
        }

        public IReadOnlyList<ILogEntry> Entries
        {
            get { return _entries; }
        }

        public void Clear()
        {
            _entries.Clear();
        }

        private void Log(string msg, LogLevel level, Exception ex = null)
        {
            var entry = new LogEntry(msg, level, ex);
            _entries.Add(entry);

            WriteToDebug(entry.ToString());

            FireEntryAdded(entry);

            AddToFile(entry);

            // TODO: display info about exception
        }

        private void AddToFile(LogEntry entry)
        {
            switch (entry.Level)
            {
                case LogLevel.Info:
                    _log4NetLogger.Info(entry.Message, entry.Exception);
                    break;
                case LogLevel.Debug:
                    _log4NetLogger.Debug(entry.Message, entry.Exception);
                    break;
                case LogLevel.Warn:
                    _log4NetLogger.Warn(entry.Message, entry.Exception);
                    break;
                case LogLevel.Error:
                    _log4NetLogger.Error(entry.Message, entry.Exception);
                    break;
                case LogLevel.Fatal:
                    _log4NetLogger.Fatal(entry.Message, entry.Exception);
                    break;
            }
            
        }

        private void WriteToDebug(string msg, params object[] param)
        {
            System.Diagnostics.Debug.Print(msg, param);
        }

        private void FireEntryAdded(LogEntry entry)
        {
            var handler = EntryAdded;
            if (handler != null)
            {
                handler(this, new LogEventArgs(entry));
            }
        }
    }
}
