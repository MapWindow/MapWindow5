using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Utilities
{
    public class GenericEnumerator<T> : IEnumerator<T>
    {

        private IEnumerable<T> _collection;
        private int _position;
        private int _max;

        public GenericEnumerator(IEnumerable<T> collection)
        {
            _collection = collection;
            // The position start at -1 and represents the current index.
            // A foreach loop calls MoveNext and _position is set to 0.
            _position = -1;
            // Get the maximum number of items in the alphabet.
            // When the maximum index is reached we are at the end of the alphabet.
            _max = _collection.Count() - 1;
        }

        /// <summary>
        /// Returns the item at the current index in a foreach loop.
        /// </summary>
        /// <remarks>Is only called when MoveNext returned True.</remarks>
        public T Current
        {
            get { return _collection.ElementAt(_position); }
        }

        /// <summary>
        /// This is the non-generic version of Current.
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        /// <summary>
        /// Moves to the next item in a collection.
        /// If this returns true it means the index is not the last index
        /// in the collection yet. If true is returned the Current Property
        /// is called.
        /// </summary>
        /// <returns>True if the last index has not been reached yet.</returns>
        public bool MoveNext()
        {
            if (_position < _max)
            {
                _position += 1;
                return true;
            }
            return false;
        }

        /// <summary>
        /// For interoperability with COM. Not supported/implemented.
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented. This is used in rare cases where the Enumerator
        /// opens up a database connection or files and needs to close them.
        /// </summary>
        public void Dispose()
        {
            // Do not throw an exception here.
            // This method is called after every loop!
        }

    }
}
