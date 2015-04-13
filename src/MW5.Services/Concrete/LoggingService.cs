using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Plugins.Log
{
    public class LoggingService: ILoggingService
    {
        private readonly List<LogEntry> _entries = new List<LogEntry>();

        private readonly IAppContext _context;

        public event EventHandler<LogEventArgs> EntryAdded;

        public LoggingService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            var broadcaster = _context.Container.Resolve<IBroadcasterService>();
            EntryAdded += (s, e) =>
            {
                broadcaster.BroadcastEvent(p => p.LogEntryAdded_, this, new LogEventArgs(e.Entry));
            };

            if (Logger.Current == null)
            {
                Logger.Current = this;
            }
        }

        void IApplicationCallback.Error(string tagOfSender, string errorMsg)
        {
            Debug("Error reported: " + errorMsg);
        }

        void IApplicationCallback.Progress(string tagOfSender, int percent, string message)
        {
            if (_context.Initialized)
            {
                _context.StatusBar.ShowProgress(message, percent);
            }
        }

        void IApplicationCallback.ClearProgress()
        {
            if (_context.Initialized)
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

        public IReadOnlyList<ILogEntry> Entries
        {
            get { return _entries; }
        }

        private void Log(string msg, LogLevel level, Exception ex = null)
        {
            var entry = new LogEntry(msg, level, ex);
            _entries.Add(entry);

            WriteToDebug(entry.ToString());

            FireEntryAdded(entry);

            // TODO: display info about exception
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
