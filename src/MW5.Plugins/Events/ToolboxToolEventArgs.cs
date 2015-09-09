using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class ToolboxToolEventArgs: EventArgs
    {
        public ToolboxToolEventArgs(ITool tool, bool batchMode = false)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
        }

        public ITool Tool { get; private set; }

        public bool BatchMode { get; set; }
    }
}
