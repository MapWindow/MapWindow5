using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// Represents a list parts of the geometry.
    /// </summary>
    public class GeometryPartCollection : IEnumerable<IGeometry>
    {
        private readonly Shape _shape;

        public GeometryPartCollection(Shape shape)
        {
            _shape = shape;
        }

        public IEnumerator<IGeometry> GetEnumerator()
        {
            for (int i = 0; i < _shape.NumParts; i++)
            {
                yield return this[i];
            }
        }

        public IGeometry this[int index]
        {
            get
            {
                if (index < 0 || index >= _shape.NumParts)
                {
                    throw new IndexOutOfRangeException("Invalid index of a part.");
                }
                return new Geometry(_shape.PartAsShape[index]);
            }
        }

        public int Count
        {
            get { return _shape.NumParts; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}