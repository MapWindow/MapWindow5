using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;

namespace MW5.Tools.Helpers
{
    internal static class TaskHelper
    {
        public static TaskIcons GetStatusIcon(this IGisTask task)
        {
            switch (task.Status)
            {
                case GisTaskStatus.NotStarted:
                    return TaskIcons.Execution;
                case GisTaskStatus.Running:
                    return TaskIcons.InProgress;
                case GisTaskStatus.Success:
                    return TaskIcons.Success;
                case GisTaskStatus.Failed:
                    return TaskIcons.Error;
                case GisTaskStatus.Cancelled:
                    return TaskIcons.Cancel;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
