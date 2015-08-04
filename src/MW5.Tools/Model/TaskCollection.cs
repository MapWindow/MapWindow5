// -------------------------------------------------------------------------------------------
// <copyright file="TaskCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    internal class TaskCollection : ITaskCollection
    {
        private readonly List<IGisTask> _tasks = new List<IGisTask>();

        public event EventHandler Cleared;

        public event EventHandler<TaskEventArgs> TaskChanged;

        public int Count
        {
            get { return _tasks.Count; }
        }

        public void AddTask(IGisTask task)
        {
            task.StatusChanged += (s, e) => FireTaskChanged(s as IGisTask, TaskEvent.StatusChanged);
            _tasks.Add(task);
            FireTaskChanged(task, TaskEvent.Added);
        }

        public void RemoveTask(IGisTask task)
        {
            _tasks.Remove(task);
            FireTaskChanged(task, TaskEvent.Removed);
        }

        public void Clear()
        {
            _tasks.Clear();
            FireCollectionCleared();
        }

        public IEnumerator<IGisTask> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FireCollectionCleared()
        {
            var handler = Cleared;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void FireTaskChanged(IGisTask task, TaskEvent taskEvent)
        {
            var handler = TaskChanged;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(task, taskEvent));
            }
        }
    }
}