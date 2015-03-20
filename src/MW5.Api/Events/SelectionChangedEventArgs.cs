using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class SelectionChangedEventArgs: EventArgs
    {
        private int _layerHandle;
        private bool _updateMap;

        internal SelectionChangedEventArgs(_DMapEvents_SelectionChangedEvent args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
            _layerHandle = args.layerHandle;
            _updateMap = false;
        }

        public SelectionChangedEventArgs(int layerHandle, bool updateMap = false)
        {
            _layerHandle = layerHandle;
            _updateMap = updateMap;
        }

        public bool UpdateMap
        {
            get { return _updateMap; }
        }

        public int LayerHandle
        {
            get { return _layerHandle; }
        }
    }
}
