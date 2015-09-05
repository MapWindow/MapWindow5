using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;

namespace MW5.Tools.Views
{
    public class ToolViewModel
    {
        public ToolViewModel(IGisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
        }

        public IGisTool Tool { get; private set; }

        public IGisTask Task { get; private set; }

        public IGisTask CreateTask()
        {
            Task = new GisTask(Tool);
            return Task;
        }
    }
}
