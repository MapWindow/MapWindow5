// -------------------------------------------------------------------------------------------
// <copyright file="BaseLogger.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public abstract class BaseLogger
    {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="param">The parameter.</param>
        public void Debug(string msg, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Debug);
        }

        public void Error(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Error, ex);
        }

        public void Fatal(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Fatal, ex);
        }

        public void Info(string msg, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Info);
        }

        /// <summary>
        /// Traces the specified message.
        /// Only needed in debug installers, should do nothing for stable releases
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="param">The parameter.</param>
        public void Trace(string msg, params object[] param)
        {
#if DEBUG
            // Only enable when really needed:
            // Log(string.Format(msg, param), LogLevel.Debug);
#endif
        }

        public void Warn(string msg, Exception ex, params object[] param)
        {
            Log(string.Format(msg, param), LogLevel.Warn, ex);
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

        protected abstract void Log(string msg, LogLevel level, Exception ex = null);
    }
}