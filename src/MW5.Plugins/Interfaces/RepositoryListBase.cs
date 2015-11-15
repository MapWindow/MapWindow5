using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Model;
using MW5.Shared;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// A base class for repository collections based on BindingList. Use DataSource property to display in combo boxes or grids.
    /// </summary>
    public class RepositoryListBase<T>: IEnumerable<T>
        where T: class
    {
        protected readonly BindingList<T> _list;

        public event EventHandler<RepositoryListEventArgs<T>> ItemAdded;
        
        public event EventHandler<RepositoryListEventArgs<T>> ItemRemoved;

        public event EventHandler<RepositoryListEventArgs<T>> ItemUpdated;

        public event EventHandler ItemsCleared;

        public RepositoryListBase()
        {
            _list = new BindingList<T>();
        }

        public IBindingList DataSource
        {
            get { return _list; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);

            DelegateHelper.FireEvent(this, ItemAdded, new RepositoryListEventArgs<T>(item)); 
        }

        public void Remove(T item)
        {
            _list.Remove(item);

            DelegateHelper.FireEvent(this, ItemRemoved, new RepositoryListEventArgs<T>(item)); 
        }

        public void Clear()
        {
            _list.Clear();

            DelegateHelper.FireEvent(this, ItemsCleared); 
        }

        public void Update(T item)
        {
            int index = _list.IndexOf(item);
            if (index != -1)
            {
                _list[index] = item;
                DelegateHelper.FireEvent(this, ItemUpdated, new RepositoryListEventArgs<T>(item)); 
            }
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Add(item);
            }
        }
    }
}
