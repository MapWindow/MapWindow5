using System.Threading;
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

        IApplicationCallback Callback { get; }
    }
}
