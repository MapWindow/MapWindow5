using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    internal class GisTask: IGisTask
    {
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

        public GisTaskStatus Status { get; private set; }

        public bool Run()
        {
            StartTime = DateTime.Now;
            Status = GisTaskStatus.Running;

            // TODO: implement asynchronous execution
            bool result = Tool.Run();

            FinishTime = DateTime.Now;
            Status = result ? GisTaskStatus.Success : GisTaskStatus.Failure;

            return result;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
