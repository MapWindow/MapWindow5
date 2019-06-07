using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Enums;

namespace MW5.Api.Events
{
    public class AfterShapeEditEventArgs: EventArgs
    {
        private readonly _DMapEvents_AfterShapeEditEvent _args;

        public AfterShapeEditEventArgs(UndoOperation operation, int layerHandle, int shapeIndex)
            : this(new _DMapEvents_AfterShapeEditEvent((tkUndoOperation)operation, layerHandle, shapeIndex))
        {
        }

        internal AfterShapeEditEventArgs(_DMapEvents_AfterShapeEditEvent args)
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

        public UndoOperation Operation
        {
            get { return (UndoOperation)_args.operation; }
        }

        public int ShapeIndex
        {
            get { return _args.shapeIndex; }
        }
    }
}
