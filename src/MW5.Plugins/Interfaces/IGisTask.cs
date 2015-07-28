using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Interfaces
{
    public interface IGisTask
    {
        IGisTool Tool { get; }

        DateTime StartTime { get; }

        DateTime FinishTime { get; }

        TimeSpan ExecutionTime { get; }

        GisTaskStatus Status { get; }

        bool Run();

        void Cancel();
    }
}
