using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Services.Concrete;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Tools.Services
{
    public class ToolLogger: LoggingServiceBase
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        protected override void Log(string msg, LogLevel level, Exception ex = null)
        {
            _stringBuilder.AppendLine(level + msg);
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
