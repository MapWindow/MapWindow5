using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class DockPanelCancelEventArgs: DockPanelEventArgs
    {
        public DockPanelCancelEventArgs(IDockPanel panel, string key) : base(panel, key)
        {
        }

        public bool Cancel { get; set; }
    }
}
