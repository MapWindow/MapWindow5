using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class SelectionChangedEventArgs: EventArgs
    {
        private readonly _DMapEvents_SelectionChangedEvent _args;

        internal SelectionChangedEventArgs(_DMapEvents_SelectionChangedEvent args)
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
