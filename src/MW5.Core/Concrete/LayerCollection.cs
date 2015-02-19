using System;
using System.Collections;
using System.Collections.Generic;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class LayerCollection : IEnumerable<ILayer>
    {
        private readonly AxMap _axMap;

        internal LayerCollection(AxMap axMap)
        {
            if (axMap == null)
            {
                throw new NullReferenceException("Map reference is null.");
            }
            _axMap = axMap;
        }

        public ILayer this[int position]
        {
            get
            {
                if (position >= 0 && position < Count)
                {
                    var layerHandle = _axMap.get_LayerHandle(position);
                    if (layerHandle == -1)
                    {
                        return null;
                    }
                    return new Layer(_axMap, layerHandle);
                }
                return null;
            }
        }

        public int Count
        {
            get { return _axMap.NumLayers; }
        }

        public IFeatureSet GetFeatureSet(int layerHandle)
        {
            var sf = _axMap.get_Shapefile(layerHandle);
            if (sf != null)
            {
                return new FeatureSet(sf);
            }
            return null;
        }

        #region IEnumerable<Layer> Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ILayer> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var l = this[i];
                if (l == null)
                    break;
                yield return l;
            }
        }

        #endregion

        public int Add(ILayerSource layerSource, bool visible = true)
        {
            return _axMap.AddLayer(layerSource.InternalObject, visible);
        }

        public bool Move(int initialPosition, int targetPosition)
        {
            return _axMap.MoveLayer(initialPosition, targetPosition);
        }

        public bool MoveBottom(int initialPosition)
        {
            return _axMap.MoveLayerBottom(initialPosition);
        }

        public bool MoveDown(int initialPosition)
        {
            return _axMap.MoveLayerDown(initialPosition);
        }

        public bool MoveTop(int initialPosition)
        {
            return _axMap.MoveLayerTop(initialPosition);
        }

        public bool MoveUp(int initialPosition)
        {
            return _axMap.MoveLayerUp(initialPosition);
        }

        public int AddFromDatabase(string connectionString, string layerNameOrQuery, bool visible = true)
        {
            return _axMap.AddLayerFromDatabase(connectionString, layerNameOrQuery, visible);
        }

        public int AddFromFilename(string filename, FileOpenStrategy openStrategy = FileOpenStrategy.AutoDetect, bool visible = true)
        {
            return _axMap.AddLayerFromFilename(filename, (tkFileOpenStrategy)openStrategy, visible);
        }

        public void RemoveAll()
        {
            _axMap.RemoveAllLayers();
        }

        public void Remove(int layerHandle)
        {
            _axMap.RemoveLayer(layerHandle);
        }

        public void RemoveWithoutClosing(int layerHandle)
        {
            _axMap.RemoveLayerWithoutClosing(layerHandle);
        }
    }
}