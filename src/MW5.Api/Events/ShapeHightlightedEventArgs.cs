using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class ShapeHightlightedEventArgs: EventArgs
    {
        private readonly _DMapEvents_ShapeHighlightedEvent _args;

        internal ShapeHightlightedEventArgs(_DMapEvents_ShapeHighlightedEvent args)
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

        public int ShapeIndex
        {
            get { return _args.shapeIndex; }
        }
    }
}
