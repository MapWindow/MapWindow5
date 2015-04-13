using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared.Log
{
    public class LogEventArgs: EventArgs
    {
        public LogEventArgs(ILogEntry entry)
        {
            Entry = entry;
        }

        public ILogEntry Entry { get; private set; }
    }
}
