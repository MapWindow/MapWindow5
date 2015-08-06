using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskHandle
    {
        ITaskProgress Progress { get; }

        WaitHandle PauseHandle { get; }

        bool IsCancelled { get; }

        void AbortIfCancelled();

        void CheckPauseAndCancel();
    }
}
