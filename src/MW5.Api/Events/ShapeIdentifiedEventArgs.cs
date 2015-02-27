using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class ShapeIdentifiedEventArgs: EventArgs
    {
        private readonly _DMapEvents_ShapeIdentifiedEvent _args;

        internal ShapeIdentifiedEventArgs(_DMapEvents_ShapeIdentifiedEvent args)
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
        
        public double PointX
        {
            get { return _args.pointX; }
        }

        public double PointY
        {
            get { return _args.pointY; }
        }
    }
}
