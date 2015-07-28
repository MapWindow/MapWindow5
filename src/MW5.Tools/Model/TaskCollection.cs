using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    internal class TaskCollection: ITaskCollection
    {
        private readonly List<IGisTask> _tasks = new List<IGisTask>();

        public void AddTask(IGisTask task)
        {
            _tasks.Add(task);
            FireCollectionChanged();
        }

        public int Count
        {
            get { return _tasks.Count; }
        }

        public event EventHandler CollectionChanged;

        public void Clear()
        {
            _tasks.Clear();
            FireCollectionChanged();
        }

        public IEnumerator<IGisTask> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FireCollectionChanged()
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
