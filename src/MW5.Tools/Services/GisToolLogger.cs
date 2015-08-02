using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Tools.Services
{
    public class GisToolLogger: ILoggingService
    {
        public void Error(string tagOfSender, string errorMsg)
        {
            throw new NotImplementedException();
        }

        public void Progress(string tagOfSender, int percent, string message)
        {
            throw new NotImplementedException();
        }

        public void ClearProgress()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ILogEntry> Entries { get; private set; }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Debug(string msg, params object[] param)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<LogEventArgs> EntryAdded;

        public void Error(string msg, Exception ex = null, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string msg, Exception ex = null, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void Info(string msg, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void Init(object context)
        {
            throw new NotImplementedException();
        }

        public int MessageCount(LogLevel level, bool notDisplayed)
        {
            throw new NotImplementedException();
        }

        public void Warn(string msg, Exception ex = null, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void Write(string msg, LogLevel level, params object[] param)
        {
            throw new NotImplementedException();
        }
    }
}
