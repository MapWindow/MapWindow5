// -------------------------------------------------------------------------------------------
// <copyright file="GisTask.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    internal class GisTask : IGisTask
    {
        private static readonly Lazy<StaTaskScheduler> _scheduler =
            new Lazy<StaTaskScheduler>(() => new StaTaskScheduler(10));

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private ITaskProgress _progress;
        private GisTaskStatus _status;

        public GisTask(GisToolBase tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
            Status = GisTaskStatus.NotStarted;
        }

        private static StaTaskScheduler Scheduler
        {
            get { return _scheduler.Value; }
        }

        public event EventHandler StatusChanged;

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

        public IGisTool Tool { get; private set; }

        public void Cancel()
        {
            // make sure that TPL task knows about it :)
            _cancellationTokenSource.Cancel();
        }

        public bool Run(CancellationToken cancellationToken)
        {
            StartTime = DateTime.Now;
            Status = GisTaskStatus.Running;

            var handle = new TaskHandle(Progress, _cancellationTokenSource.Token, _pauseEvent, this);

            bool result = Tool.Run(handle);

            FinishTime = DateTime.Now;
            Status = result ? GisTaskStatus.Success : GisTaskStatus.Failed;

            return result;
        }

        public void RunAsync()
        {
            Tool.SetCallback(this);

            var token = _cancellationTokenSource.Token;

            var t = Task<bool>.Factory.StartNew(() => Run(token), token, TaskCreationOptions.LongRunning,
                    TaskScheduler.Default).ContinueWith(task =>
                        {
                            // currently running on UI thread (TaskScheduler.FromCurrentSynchronizationContext())
                            
                            // stop reporting progress from datasources
                            Tool.SetCallback(null);   

                            if (task.IsCanceled || _cancellationTokenSource.IsCancellationRequested)
                            {
                                Status = GisTaskStatus.Cancelled;
                                FinishTime = DateTime.Now;
                                return;
                            }

                            if (task.IsFaulted && task.Exception != null)
                            {
                                Logger.Current.Error("Error during tool execution: " + Tool.Name, task.Exception);
                                Status = GisTaskStatus.Failed;
                                FinishTime = DateTime.Now;
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
            Tool.Log.Error(errorMsg, null);
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
                handler(this, new EventArgs());
            }
        }
    }
}