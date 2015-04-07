using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class ToolboxToolEventArgs: EventArgs
    {
        public ToolboxToolEventArgs(IGisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
        }

        public IGisTool Tool { get; private set; }
    }
}
