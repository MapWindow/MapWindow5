using System;
using System.Collections.Generic;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskCollection: IEnumerable<IGisTask>
    {
        void AddTask(IGisTask task);

        void RemoveTask(IGisTask task);

        int Count { get; }

        event EventHandler<TaskEventArgs> TaskChanged;
        
        event EventHandler Cleared;

        void Clear();
    }
}
