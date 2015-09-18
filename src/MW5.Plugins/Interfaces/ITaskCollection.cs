// -------------------------------------------------------------------------------------------
// <copyright file="ITaskCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Represents a collection of GIS tasks.
    /// </summary>
    public interface ITaskCollection : IEnumerable<IGisTask>
    {
        /// <summary>
        /// Occurs when all the tasks are cleared from the collection.
        /// </summary>
        event EventHandler Cleared;

        /// <summary>
        /// Occurs when task status changes.
        /// </summary>
        event EventHandler<TaskEventArgs> TaskChanged;

        /// <summary>
        /// Gets the number of tasks in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds the specified task.
        /// </summary>
        void Add(IGisTask task);

        /// <summary>
        /// Cancels all the running tasks.
        /// </summary>
        void CancelAll();

        /// <summary>
        /// Removed all the tasks from the collection.
        /// </summary>
        /// <param name="finishedOnly">If set to <c>true</c> only finished tasks will be removed.</param>
        void Clear(bool finishedOnly);

        /// <summary>
        /// Removes the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        void Remove(IGisTask task);
    }
}