using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public abstract class BaseLogger
    {
        protected abstract void Log(string msg, Shared.LogLevel level, Exception ex = null);

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
    }
}
