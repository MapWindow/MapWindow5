using System;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskProgress
    {
        void Update(string msg, int value);

        void TryUpdate(string msg, int step, int total, ref int lastPercent);

        void Clear();

        event EventHandler<ProgressEventArgs> ProgressChanged;

        event EventHandler Hide;
    }
}
