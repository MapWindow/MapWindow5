using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class LayerAddedEventArgs: EventArgs
    {
        private readonly _DMapEvents_LayerAddedEvent _args;

        internal LayerAddedEventArgs(_DMapEvents_LayerAddedEvent args)
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
    }
}
