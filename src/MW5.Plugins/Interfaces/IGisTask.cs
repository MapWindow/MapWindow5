// -------------------------------------------------------------------------------------------
// <copyright file="IGisTask.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Represents a task object that can be used for asynchronous execution of GIS tool and its progress monitoring.
    /// </summary>
    public interface IGisTask
    {
        /// <summary>
        /// Occurs when status of the task changed.
        /// </summary>
        event EventHandler<TaskStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Gets the execution time.
        /// </summary>
        TimeSpan ExecutionTime { get; }

        /// <summary>
        /// Gets the execution finish time.
        /// </summary>
        DateTime FinishTime { get; }

        /// <summary>
        /// Gets a value indicating whether the task execution is finished, no matter whether it was successful or not.
        /// </summary>
        bool IsFinished { get; }

        /// <summary>
        /// Gets a value indicating whether task execution was is paused.
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the task that should be executed after the current one is finished.
        /// </summary>
        IGisTask NextTask { get; set; }

        /// <summary>
        /// Reports progress of task.
        /// </summary>
        ITaskProgress Progress { get; }

        /// <summary>
        /// Gets the execution start time.
        /// </summary>
        DateTime StartTime { get; }

        /// <summary>
        /// Gets the status the task.
        /// </summary>
        GisTaskStatus Status { get; }

        /// <summary>
        /// Gets the tool the task is executing.
        /// </summary>
        IGisTool Tool { get; }

        /// <summary>
        /// Cancels the task execution.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Pauses the execution of the task.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the execution of the task.
        /// </summary>
        void Resume();

        /// <summary>
        /// Runs the task on the current thread.
        /// </summary>
        bool Run(CancellationToken token);

        /// <summary>
        /// Runs the task asynchronously.
        /// </summary>
        void RunAsync();

        /// <summary>
        /// Toggles the paused state of the task.
        /// </summary>
        void TogglePause();
    }
}