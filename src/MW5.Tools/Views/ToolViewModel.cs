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
        public ToolViewModel(GisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
        }

        public GisTool Tool { get; private set; }

        public IGisTask Task { get; private set; }

        public bool TaskIsRunning
        {
            get { return Task != null && !Task.IsFinished; }
        }

        public IGisTask CreateTask()
        {
            Task = new GisTask(Tool);
            return Task;
        }

        public void CancelTask()
        {
            if (TaskIsRunning)
            {
                Task.Cancel();
            }
        }
    }
}
