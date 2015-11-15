using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Events
{
    public class RepositoryListEventArgs<T>: EventArgs
        where T: class
    {
        public RepositoryListEventArgs(T item)
        {
            if (item == null) throw new ArgumentNullException();
            Item = item;
        }

        public T Item { get; private set;}
    }
}
