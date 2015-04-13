using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Shared.Log;

namespace MW5.Plugins.Log
{
    public class LogEntry: ILogEntry
    {
        public LogEntry(string msg, LogLevel level)
        {
            Message = msg;
            Level = level;
        }

        public LogEntry(string msg, LogLevel level, Exception ex)
            :this(msg, level)
        {
            Exception = ex;
            TimeStamp = DateTime.Now;
        }

        public string Message { get; private set; }
        public LogLevel Level { get; private set; }
        public Exception Exception { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Level.ToString().ToUpper(), Message);
        }
    }
}
