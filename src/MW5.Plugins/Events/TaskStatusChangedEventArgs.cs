using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class TaskStatusChangedEventArgs: EventArgs
    {
        public TaskStatusChangedEventArgs(IGisTask task)
        {
            if (task == null) throw new ArgumentNullException("task");
            Task = task;
        }

        public IGisTask Task { get; private set; }
    }
}
