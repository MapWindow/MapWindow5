using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Tools.Model
{
    internal class GisTask: IGisTask
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private GisTaskStatus _status;
        
        public GisTask(IGisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            Tool = tool;

            Status = GisTaskStatus.NotStarted;
        }

        public IGisTool Tool { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime FinishTime { get; private set; }

        public TimeSpan ExecutionTime
        {
            get
            {
                if (Status == GisTaskStatus.NotStarted)
                {
                    return TimeSpan.Zero;
                }

                TimeSpan span = DateTime.Now - StartTime;
                return span;
            }
        }

        public GisTaskStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                FireStatusChanged();
            }
        }

        public bool Run()
        {
            StartTime = DateTime.Now;
            Status = GisTaskStatus.Running;

            bool result = Tool.Run();

            FinishTime = DateTime.Now;
            Status = result ? GisTaskStatus.Success : GisTaskStatus.Failure;

            return result;
        }

        public async void RunAsync()
        {
            // actually there is no much need for async / await here
            // Task.ContinueWith would do the job just as well
            var t = Task<bool>.Factory.StartNew(Run);
            await t;

            if (t.IsFaulted && t.Exception != null)
            {
                foreach (var ex in t.Exception.InnerExceptions)
                {
                    Logger.Current.Error("Error during tool execution: " + Tool.Name, ex);
                }
            }
        }

        public void Cancel()
        {
            // make sure that TPL task knows about it :)
            _cancellationTokenSource.Cancel();
        }

        public event EventHandler StatusChanged;

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
