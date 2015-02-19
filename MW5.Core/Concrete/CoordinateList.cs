using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class CoordinateList : IList<ICoordinate>
    {
        private int _partIndex;
        private readonly Shape _shape;

        internal CoordinateList(Shape shape, int partIndex)
        {
            _shape = shape;
            _partIndex = partIndex;
        }

        #region IList<ICoordinate> Members

        public IEnumerator<ICoordinate> GetEnumerator()
        {
            return ListHelper.GetEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICoordinate item)
        {
            var pnt = item.GetInternal();
            if (pnt != null)
            {
                var index = _shape.numPoints;
                _shape.InsertPoint(pnt, ref index);
            }
        }

        public int Count
        {
            get { return _shape.numPoints; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(ICoordinate item)
        {
            var pnt = item.GetInternal();
            if (pnt != null)
            {
                for (var i = 0; i < _shape.numPoints; i++)
                {
                    if (_shape.Point[i] == pnt)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void Insert(int index, ICoordinate item)
        {
            var pnt = item.GetInternal();
            if (pnt != null)
            {
                _shape.InsertPoint(pnt, ref index);
            }
        }

        public void RemoveAt(int index)
        {
            _shape.DeletePoint(index);
        }

        public ICoordinate this[int index]
        {
            get
            {
                if (index < 0 || index > _shape.numPoints)
                {
                    return null;
                }
                return new Coordinate(_shape.Point[index]);
            }
            set
            {
                var pnt = value.GetInternal();
                if (pnt != null)
                {
                    _shape.Point[index] = pnt;
                }
            }
        }

        public void Clear()
        {
            // TODO: implement in ocx
            for (var i = _shape.numPoints - 1; i >= 0; i--)
            {
                _shape.DeletePoint(i);
            }
        }

        public bool Contains(ICoordinate item)
        {
            var pnt = item.GetInternal();
            if (pnt != null)
            {
                // TODO: implememnt in ocx
                for (var i = 0; i < _shape.numPoints; i++)
                {
                    if (_shape.Point[i] == pnt)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Remove(ICoordinate item)
        {
            var pnt = item.GetInternal();
            if (pnt != null)
            {
                // TODO: implememnt in ocx
                for (var i = 0; i < _shape.numPoints; i++)
                {
                    if (_shape.Point[i] == pnt)
                    {
                        _shape.DeletePoint(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(ICoordinate[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}