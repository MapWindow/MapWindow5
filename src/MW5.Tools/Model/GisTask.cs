// -------------------------------------------------------------------------------------------
// <copyright file="GisTask.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    internal class GisTask : IGisTask, IApplicationCallback
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private readonly IGisTool _tool;
        private ITaskProgress _progress;
        private GisTaskStatus _status;

        public GisTask(IGisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            _tool = tool;
            Status = GisTaskStatus.NotStarted;
        }

        public event EventHandler<TaskStatusChangedEventArgs> StatusChanged;

        public bool IsFinished
        {
            get
            {
                switch (Status)
                {
                    case GisTaskStatus.Success:
                    case GisTaskStatus.Failed:
                    case GisTaskStatus.Cancelled:
                        return true;
                }

                return false;
            }
        }

        public bool IsPaused
        {
            get { return Status == GisTaskStatus.Paused; }
        }

        public void Pause()
        {
            if (Status == GisTaskStatus.Running)
            {
                Status = GisTaskStatus.Paused;
                _pauseEvent.Reset();
            }
        }

        public void Resume()
        {
            if (IsPaused)
            {
                Status = GisTaskStatus.Running;
            }
            _pauseEvent.Set();
        }

        public void TogglePause()
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                if (!IsFinished)
                {
                    Pause();
                }
            }
        }

        public TimeSpan ExecutionTime
        {
            get
            {
                if (Status == GisTaskStatus.NotStarted)
                {
                    return TimeSpan.Zero;
                }

                var span = DateTime.Now - StartTime;
                return span;
            }
        }

        public DateTime FinishTime { get; private set; }

        public DateTime StartTime { get; private set; }

        public GisTaskStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                FireStatusChanged();
            }
        }

        public IGisTool Tool
        {
            get { return _tool; }
        }

        public void Cancel()
        {
            // make sure that TPL task knows about it :)
            _cancellationTokenSource.Cancel();
        }

        public bool Run(CancellationToken cancellationToken)
        {
            var handle = new TaskHandle(Progress, _cancellationTokenSource.Token, _pauseEvent, this);

            return Tool.Run(handle);
        }

        public void RunAsync()
        {
            _tool.Callback = this;

            var token = _cancellationTokenSource.Token;

            StartTime = DateTime.Now;
            Status = GisTaskStatus.Running;

            var t = Task<bool>.Factory.StartNew(() => Run(token), token, TaskCreationOptions.LongRunning,
                    TaskScheduler.Default).ContinueWith(task =>
                        {
                            try
                            {
                                FinishTime = DateTime.Now;

                                if (task.IsCanceled || _cancellationTokenSource.IsCancellationRequested)
                                {
                                    Status = GisTaskStatus.Cancelled;
                                    return;
                                }

                                try
                                {
                                    // exception will be observed here, so don't check IsFaulted afterwards
                                    if (!task.Result)
                                    {
                                        Status = GisTaskStatus.Failed;
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Current.Error("Error during tool execution: " + Tool.Name, ex);
                                    Status = GisTaskStatus.Failed;
                                    return;
                                }

                                try
                                {
                                    Status = _tool.AfterRun() ? GisTaskStatus.Success : GisTaskStatus.Failed;
                                }
                                catch (Exception ex)
                                {
                                    Logger.Current.Error("Failed to save datasource: " + Tool.Name, ex);
                                    Status = GisTaskStatus.Failed;
                                }
                            }
                            finally
                            {
                                // stop reporting progress from datasources
                                _tool.CleanUp();
                            }
                        }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public ITaskProgress Progress
        {
            get { return _progress ?? (_progress = new EventProgress()); }
            set
            {
                if (value == null) value = new EmptyProgress();
                _progress = value;
            }
        }

        void IApplicationCallback.Error(string tagOfSender, string errorMsg)
        {
            _tool.Log.Error(errorMsg, null);
        }

        void IApplicationCallback.Progress(string tagOfSender, int percent, string message)
        {
            // for tools that don't support cancellation it may be the only place
            // to pause, for others additional check won't affect the performance much
            _pauseEvent.WaitOne();

            Progress.Update(message, percent);
        }

        void IApplicationCallback.ClearProgress()
        {
            Progress.Clear();
        }

        bool IApplicationCallback.CheckAborted()
        {
            // the calls to IStopExecution interface may be more frequent than progress reporting,
            // so this is a good place to check for pause when long MapWinGIS method is running
            _pauseEvent.WaitOne();

            return _cancellationTokenSource.IsCancellationRequested;
        }

        private void FireStatusChanged()
        {
            var handler = StatusChanged;
            if (handler != null)
            {
                handler(this, new TaskStatusChangedEventArgs(this));
            }
        }
    }
}