using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class ToolboxGroupEventArgs : EventArgs
    {
        public ToolboxGroupEventArgs(IToolboxGroup group)
        {
            if (group == null) throw new ArgumentNullException("group");
            Group = group;
        }

        public IToolboxGroup Group { get; private set; }
    }
}
