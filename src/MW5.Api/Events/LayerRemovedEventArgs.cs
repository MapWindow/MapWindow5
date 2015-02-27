using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class LayerRemovedEventArgs: EventArgs
    {
        private readonly _DMapEvents_LayerRemovedEvent _args;

        internal LayerRemovedEventArgs(_DMapEvents_LayerRemovedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
        }

        public bool RemoveAllLayers
        {
            get { return _args.fromRemoveAllLayers; }
        }
    }
}
