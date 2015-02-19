using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Events
{
    public class ValidateShapeEventArgs : EventArgs
    {
        private readonly _DMapEvents_ValidateShapeEvent _args;

        internal ValidateShapeEventArgs(_DMapEvents_ValidateShapeEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public tkMwBoolean Cancel
        {
            get { return _args.cancel; }
            set { _args.cancel = value; }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
        }

        public IGeometry Geometry
        {
            get { return new Geometry(_args.shape); }
        }
    }
}
