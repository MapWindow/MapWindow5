using System;
using System.Collections.Generic;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskCollection: IEnumerable<IGisTask>
    {
        void AddTask(IGisTask task);

        int Count { get; }

        event EventHandler CollectionChanged;

        event EventHandler<TaskEventArgs> TaskStatusChanged;

        void Clear();
    }
}
