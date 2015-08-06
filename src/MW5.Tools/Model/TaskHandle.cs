using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Shared.Log;

namespace MW5.Tools.Model
{
    public class TaskHandle : ITaskHandle
    {
        private CancellationToken _cancellationToken;

        public TaskHandle(ITaskProgress progress, CancellationToken cancellationToken, WaitHandle pauseHandle, 
                          IApplicationCallback callback)
        {
            if (progress == null) throw new ArgumentNullException("progress");
            if (pauseHandle == null) throw new ArgumentNullException("pauseHandle");
            if (callback == null) throw new ArgumentNullException("callback");

            ErrorCallback = callback;
            PauseHandle = pauseHandle;
            Progress = progress;
            _cancellationToken = cancellationToken;
        }

        public IApplicationCallback ErrorCallback { get; private set; }

        public ITaskProgress Progress { get; private set; }

        public WaitHandle PauseHandle { get; private set; }

        public bool IsCancelled
        {
            get { return _cancellationToken.IsCancellationRequested; }
        }

        public void AbortIfCancelled()
        {
            _cancellationToken.ThrowIfCancellationRequested();
        }

        public void CheckPauseAndCancel()
        {
            AbortIfCancelled();
            PauseHandle.WaitOne();
        }
    }
}
