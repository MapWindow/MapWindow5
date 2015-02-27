using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GeometryPartCollection : IList<IGeometry>
    {
        private readonly Shape _shape;

        public GeometryPartCollection(Shape shape)
        {
            _shape = shape;
        }

        #region IList<IGeometry> Members

        public IEnumerator<IGeometry> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IGeometry item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IGeometry item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IGeometry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IGeometry item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public int IndexOf(IGeometry item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IGeometry item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public IGeometry this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}