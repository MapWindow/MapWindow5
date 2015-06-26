using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Equin.BindingListView
{
    /// <summary>
    /// A basic list of key-value pairs that store the indicies of items in a source list.
    /// The key part is actually an <see cref="EditableObject&lt;T&gt;"/> so we have to extract the inner <typeparamref name="T"/> object
    /// when processing the list.
    /// </summary>
    /// <typeparam name="T">The type of item in the source list.</typeparam>
    internal class SourceIndexList<T> : List<KeyValuePair<EditableObject<T>, int>>
    {
        public void Add(EditableObject<T> item, int index)
        {
            Add(new KeyValuePair<EditableObject<T>, int>(item, index));
        }

        /// <summary>
        /// Searches for a given source index value, returning the list index of the value.
        /// </summary>
        /// <param name="sourceIndex">The source index to find.</param>
        /// <returns>Returns the index in this list of the source index, or -1 if not found.</returns>
        public int IndexOfSourceIndex(int sourceIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Value == sourceIndex)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Searches for a given item, returning the index of the value in this list.
        /// </summary>
        /// <param name="item">The <typeparamref name="T"/> item to search for.</param>
        /// <returns>Returns the index in this list of the item, or -1 if not found.</returns>
        public int IndexOfItem(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Key.Object.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Searches for a given item's <see cref="EditableObject&lt;T&gt;"/> wrapper, returning the index of the value in this list.
        /// </summary>
        /// <param name="item">The <see cref="EditableObject&lt;T&gt;"/> to search for.</param>
        /// <returns>Returns the index in this list of the item, or -1 if not found.</returns>
        public int IndexOfKey(EditableObject<T> item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Key.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checks if the list contains a given item.
        /// </summary>
        /// <param name="item">The <typeparamref name="T"/> item to check for.</param>
        /// <returns>True if the item is contained in the list, otherwise false.</returns>
        public bool ContainsItem(T item)
        {
            return (IndexOfItem(item) != -1);
        }

        /// <summary>
        /// Checks if the list contains a given <see cref="EditableObject&lt;T&gt;"/> key.
        /// </summary>
        /// <param name="item">The key to search for.</param>
        /// <returns>True if the key is contained in the list, otherwise false.</returns>
        public bool ContainsKey(EditableObject<T> key)
        {
            return (IndexOfKey(key) != -1);
        }

        /// <summary>
        /// Returns an array of all the <see cref="EditableObject&lt;T&gt;"/> keys in the list.
        /// </summary>
        public EditableObject<T>[] Keys
        {
            get
            {
                return ConvertAll<EditableObject<T>>(new Converter<KeyValuePair<EditableObject<T>, int>, EditableObject<T>>(
                    delegate(KeyValuePair<EditableObject<T>, int> kvp)
                    { return kvp.Key; }
                )).ToArray();
            }
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator&lt;T&gt;"/> to iterate over all the keys in this list.
        /// </summary>
        /// <returns>The <see cref="IEnumerator&lt;T&gt;"/> to use.</returns>
        public IEnumerator<EditableObject<T>> GetKeyEnumerator()
        {
            foreach (KeyValuePair<EditableObject<T>, int> kvp in this)
            {
                yield return kvp.Key;
            }
        }
    }
}