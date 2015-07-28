using System;
using System.Collections.Generic;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskCollection: IEnumerable<IGisTask>
    {
        void AddTask(IGisTask task);

        int Count { get; }

        event EventHandler CollectionChanged;

        void Clear();
    }
}
