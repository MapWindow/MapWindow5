using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Events
{
    public class PluginMessageEventArgs: EventArgs
    {
        public PluginMessageEventArgs(string message)
        {
            if (message == null) throw new ArgumentNullException("message");
            Message = message;
        }

        public string Message { get; private set; }
    }
}
