using System;
using System.ComponentModel;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Services.Concrete
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

        public LogLevel Level { get; set; }

        [Browsable(false)]
        public string Message { get; private set; }
        
        [Browsable(false)]
        public Exception Exception { get; private set; }

        [DisplayName("Time")]
        public DateTime TimeStamp { get; private set; }

        public string DetailedMessage
        {
            get
            {
                string s = Message;

                if (Exception != null)
                {
                    s += Environment.NewLine + Exception.Message + Environment.NewLine + Exception.StackTrace;
                }

                return s;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Level.ToString().ToUpper(), Message);
        }
    }
}
