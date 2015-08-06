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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private GisTaskStatus _status;
        private ITaskProgress _progress;

        public GisTask(GisToolBase tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;
            Status = GisTaskStatus.NotStarted;
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

        public async void RunAsync()
        {
            var token = _cancellationTokenSource.Token;

            // actually there is not much need for async / await here
            // Task.ContinueWith would do the job fine as well
            try
            {
                var t = Task<bool>.Factory.StartNew(() => Run(token), token);
                await t;
            }
            catch (OperationCanceledException ex)
            {
                FinishTime = DateTime.Now;
                Status = GisTaskStatus.Cancelled;
            }
            catch(Exception ex)
            {
                Logger.Current.Error("Error during tool execution: " + Tool.Name, ex);
                Status = GisTaskStatus.Failed;
                FinishTime = DateTime.Now;

                // await rethrows only the first exception;
                // with Task.ContinueWith AggregateException will be rethrown
                //if (t.IsFaulted && t.Exception != null)
                //{
                //    foreach (var ex in t.Exception.InnerExceptions)
                //    {

                //    }
                //}
            }
        }

        private void FireStatusChanged()
        {
            var handler = StatusChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
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

        public void Error(string tagOfSender, string errorMsg)
        {
            Tool.Log.Error(errorMsg, null);
        }

        void IApplicationCallback.Progress(string tagOfSender, int percent, string message)
        {
            Progress.Update(message, percent);
        }

        public void ClearProgress()
        {
            Progress.Clear();
        }
    }
}