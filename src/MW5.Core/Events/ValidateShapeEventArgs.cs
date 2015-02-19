using AxMapWinGIS;
using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Events
{
    public class ValidateShapeEventArgs
    {
        private readonly _DMapEvents_ValidateShapeEvent _args;

        internal ValidateShapeEventArgs(_DMapEvents_ValidateShapeEvent args)
        {
            _args = args;
        }

        public tkMwBoolean cancel;
        public int layerHandle;
        public Shape shape;

        public tkMwBoolean Cancel
        {
            get { return _args.cancel; }
            set { _args.cancel = value; }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
            set { _args.layerHandle = value; }
        }

        public IGeometry Geometry
        {
            get { return new Geometry(_args.shape); }
            set { _args.shape = value.GetInternal(); }
        }
    }
}
