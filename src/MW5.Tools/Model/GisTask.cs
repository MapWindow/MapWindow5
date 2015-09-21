// -------------------------------------------------------------------------------------------
// <copyright file="GisTask.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents a task object that can be used for asynchronous execution of GIS tool and its progress monitoring.
    /// </summary>
    internal class GisTask : IGisTask, IGlobalListener
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private readonly IGisTool _tool;
        private ITaskProgress _progress;
        private GisTaskStatus _status;

        /// <summary>
        /// Initializes a new instance of the <see cref="GisTask"/> class.
        /// </summary>
        public GisTask(IGisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            _tool = tool;
            Status = GisTaskStatus.NotStarted;
            ThreadId = -1;
        }

        void IGlobalListener.Error(string tagOfSender, string errorMsg)
        {
            _tool.Log.Error(errorMsg, null);
        }

        void IGlobalListener.Progress(string tagOfSender, int percent, string message)
        {
            // for tools that don't support cancellation it may be the only place
            // to pause, for others additional check won't affect the performance much
            _pauseEvent.WaitOne();

            Progress.Update(message, percent);
        }

        void IGlobalListener.ClearProgress()
        {
            Progress.Clear();
        }

        bool IGlobalListener.CheckAborted()
        {
            // the calls to IStopExecution interface may be more frequent than progress reporting,
            // so this is a good place to check for pause when long MapWinGIS method is running
            _pauseEvent.WaitOne();

            return _cancellationTokenSource.IsCancellationRequested;
        }

        /// <summary>
        /// Gets the identifier of the thread the task is executed on (valid only during execution, otherwise return -1).
        /// </summary>
        public int ThreadId { get; private set; }

        /// <summary>
        /// Occurs when status of the task changed.
        /// </summary>
        public event EventHandler<TaskStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Gets a value indicating whether the task execution is finished, no matter whether it was successful or not.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether task execution was is paused.
        /// </summary>
        public bool IsPaused
        {
            get { return Status == GisTaskStatus.Paused; }
        }

        /// <summary>
        /// Pauses the execution of the task.
        /// </summary>
        public void Pause()
        {
            if (Status == GisTaskStatus.Running)
            {
                Status = GisTaskStatus.Paused;
                _pauseEvent.Reset();
            }
        }

        /// <summary>
        /// Resumes the execution of the task.
        /// </summary>
        public void Resume()
        {
            if (IsPaused)
            {
                Status = GisTaskStatus.Running;
            }
            _pauseEvent.Set();
        }

        /// <summary>
        /// Toggles the paused state of the task.
        /// </summary>
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

        /// <summary>
        /// Gets the execution time.
        /// </summary>
        public TimeSpan ExecutionTime
        {
            get
            {
                if (Status == GisTaskStatus.NotStarted)
                {
                    return TimeSpan.Zero;
                }

                if (IsFinished)
                {
                    return FinishTime - StartTime;
                }

                var span = DateTime.Now - StartTime;
                return span;
            }
        }

        /// <summary>
        /// Gets the execution finish time.
        /// </summary>
        public DateTime FinishTime { get; private set; }

        /// <summary>
        /// Gets the execution start time.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the status the task.
        /// </summary>
        public GisTaskStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                FireStatusChanged();
            }
        }

        /// <summary>
        /// Gets the tool the task is executing.
        /// </summary>
        public IGisTool Tool
        {
            get { return _tool; }
        }

        /// <summary>
        /// Cancels the task execution.
        /// </summary>
        public void Cancel()
        {
            // make sure that TPL task knows about it :)
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Runs the task on the current thread.
        /// </summary>
        public bool Run(CancellationToken cancellationToken)
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;

            GlobalListeners.Attach(this);

            bool result = false;

            try
            {
                var handle = new TaskHandle(Progress, _cancellationTokenSource.Token, _pauseEvent, this);

                result = Tool.Run(handle);
            }
            finally
            {
                GlobalListeners.Detach(this);

                ThreadId = -1;
            }

            return result;
        }

        /// <summary>
        /// Runs the task asynchronously.
        /// </summary>
        public void RunAsync()
        {
            _tool.Callback = this;

            var token = _cancellationTokenSource.Token;

            StartTime = DateTime.Now;
            Status = GisTaskStatus.Running;

            var t =
                Task<bool>.Factory.StartNew(() => Run(token), token, TaskCreationOptions.LongRunning,
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
                                    _tool.Log.Error("Error during tool execution: " + Tool.Name, ex);
                                    Status = GisTaskStatus.Failed;
                                    return;
                                }

                                try
                                {
                                    Status = _tool.AfterRun() ? GisTaskStatus.Success : GisTaskStatus.Failed;
                                }
                                catch (Exception ex)
                                {
                                    _tool.Log.Error("Failed to save datasource: " + Tool.Name, ex);
                                    Status = GisTaskStatus.Failed;
                                }
                            }
                            finally
                            {
                                // running the next task
                                if (NextTask != null)
                                {
                                    NextTask.RunAsync();
                                }

                                // stop reporting progress from datasources
                                _tool.CleanUp();
                            }
                        }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Reports progress of task.
        /// </summary>
        public ITaskProgress Progress
        {
            get { return _progress ?? (_progress = new EventProgress()); }
            set
            {
                if (value == null) value = new EmptyProgress();
                _progress = value;
            }
        }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        public string Name
        {
            get
            {
                string name = _tool.TaskName;

                if (Status == GisTaskStatus.NotStarted)
                {
                    name += " [Not started]";
                }

                if (IsFinished)
                {
                    name += " [" + ExecutionTime.ToString(@"hh\:mm\:ss") + "]";
                }

                return name;
            }
        }

        /// <summary>
        /// Gets or sets the tasks that should be executed after the current one.
        /// </summary>
        public IGisTask NextTask { get; set; }

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