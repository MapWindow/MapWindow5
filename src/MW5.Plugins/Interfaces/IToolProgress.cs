using System;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface IToolProgress
    {
        void Update(string msg, int value);

        void Clear();

        event EventHandler<ProgressEventArgs> ProgressChanged;

        event EventHandler Hide;
    }
}
