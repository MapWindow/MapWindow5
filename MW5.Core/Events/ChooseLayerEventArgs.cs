using System;
using AxMapWinGIS;

namespace MW5.Core.Events
{
    public class ChooseLayerEventArgs : EventArgs
    {
        private readonly _DMapEvents_ChooseLayerEvent _args;

        internal ChooseLayerEventArgs(_DMapEvents_ChooseLayerEvent args)
        {
            _args = args;
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
            set { _args.layerHandle = value; }
        }
    }
}
