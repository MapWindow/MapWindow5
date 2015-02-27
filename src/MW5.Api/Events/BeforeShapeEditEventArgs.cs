using System;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Api.Events
{
    public class BeforeShapeEditEventArgs : EventArgs
    {
        private readonly _DMapEvents_BeforeShapeEditEvent _args;

        internal BeforeShapeEditEventArgs(_DMapEvents_BeforeShapeEditEvent args)
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

        public bool Cancel
        {
            get { return _args.cancel == tkMwBoolean.blnTrue; }
            set { _args.cancel = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }

        public int ShapeIndex
        {
            get { return _args.shapeIndex; }
        }
    }
}
