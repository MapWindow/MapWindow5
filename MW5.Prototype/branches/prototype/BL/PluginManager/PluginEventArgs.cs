using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.PluginManager
{
    public class PluginEventArgs : EventArgs
    {
        public object[] Objects { get; set; }
    }
}
