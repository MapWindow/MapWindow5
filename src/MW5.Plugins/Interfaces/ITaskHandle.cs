using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Shared.Log;

namespace MW5.Plugins.Interfaces
{
    public interface ITaskHandle
    {
        ITaskProgress Progress { get; }

        WaitHandle PauseHandle { get; }

        bool IsCancelled { get; }

        void AbortIfCancelled();

        void CheckPauseAndCancel();

        IApplicationCallback ErrorCallback { get; }
    }
}
