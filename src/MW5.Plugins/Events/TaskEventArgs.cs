using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class TaskEventArgs: EventArgs
    {
        public TaskEventArgs(IGisTask task)
        {
            if (task == null) throw new ArgumentNullException("task");
            Task = task;
        }

        public IGisTask Task { get; private set; }
    }
}
