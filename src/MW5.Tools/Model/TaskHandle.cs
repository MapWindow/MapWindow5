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
    /// <summary>
    /// Represents a handle of the task that is passed to the IGisTool.Run method to report progress and 
    /// respond to the user actions.
    /// </summary>
    public class TaskHandle : ITaskHandle
    {
        private CancellationToken _cancellationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskHandle"/> class.
        /// </summary>
        public TaskHandle(ITaskProgress progress, CancellationToken cancellationToken, WaitHandle pauseHandle, 
                          IApplicationCallback callback)
        {
            if (progress == null) throw new ArgumentNullException("progress");
            if (pauseHandle == null) throw new ArgumentNullException("pauseHandle");
            if (callback == null) throw new ArgumentNullException("callback");

            Callback = callback;
            PauseHandle = pauseHandle;
            Progress = progress;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        public IApplicationCallback Callback { get; private set; }

        /// <summary>
        /// Gets the progress.
        /// </summary>
        public ITaskProgress Progress { get; private set; }

        /// <summary>
        /// Gets the pause handle.
        /// </summary>
        public WaitHandle PauseHandle { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the task is cancelled.
        /// </summary>
        public bool IsCancelled
        {
            get { return _cancellationToken.IsCancellationRequested; }
        }

        /// <summary>
        /// Aborts async execution by using cancellation token if user has canceled the execution via UI.
        /// </summary>
        public void AbortIfCancelled()
        {
            _cancellationToken.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// Checks if the execution should be paused or canceled.
        /// </summary>
        public void CheckPauseAndCancel()
        {
            AbortIfCancelled();
            PauseHandle.WaitOne();
        }
    }
}
