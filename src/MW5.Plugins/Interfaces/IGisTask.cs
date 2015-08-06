using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Shared.Log;

namespace MW5.Plugins.Interfaces
{
    public interface IGisTask: IApplicationCallback
    {
        IGisTool Tool { get; }

        DateTime StartTime { get; }

        DateTime FinishTime { get; }

        TimeSpan ExecutionTime { get; }

        GisTaskStatus Status { get; }

        bool Run(CancellationToken token);

        void RunAsync();

        void Cancel();

        bool IsFinished { get; }

        bool IsPaused { get; }

        void Pause();

        void Resume();

        void TogglePause();

        event EventHandler StatusChanged;

        /// <summary>
        /// Reports progress of task.
        /// </summary>
        ITaskProgress Progress { get; }
    }
}
