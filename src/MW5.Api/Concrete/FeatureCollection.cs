using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class FeatureCollection : IEnumerable<IFeature>
    {
        private readonly Shapefile _shapefile;

        internal FeatureCollection(Shapefile sf)
        {
            if (sf == null)
            {
                throw new NullReferenceException("Shapefile reference is null.");
            }
            _shapefile = sf;
        }

        #region IFeatureCollection Members

        public IEnumerator<IFeature> GetEnumerator()
        {
            for (var i = 0; i < _shapefile.NumShapes; i++)
            {
                yield return new Feature(_shapefile, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public int EditAdd(IGeometry geometry)
        {
            return _shapefile.EditAddShape(geometry.GetInternal());
        }

        public bool EditClear()
        {
            return _shapefile.EditClear();
        }

        public bool EditDelete(int index)
        {
            return _shapefile.EditDeleteShape(index);
        }

        public bool EditInsert(IGeometry geometry, ref int index)
        {
            return _shapefile.EditInsertShape(geometry.GetInternal(), ref index);
        }

        public bool EditUpdate(int index, IGeometry geometryNew)
        {
            return _shapefile.EditUpdateShape(index, geometryNew.GetInternal());
        }

        public IFeature this[int index]
        {
            get
            {
                if (index < 0 || index >= _shapefile.NumShapes)
                {
                    throw new IndexOutOfRangeException("Feature index is out of range.");
                }
                return new Feature(_shapefile, index);
            }
        }
    }
}