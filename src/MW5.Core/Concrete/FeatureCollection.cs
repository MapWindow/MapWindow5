using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class FeatureCollection : IFeatureCollection
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
    }
}