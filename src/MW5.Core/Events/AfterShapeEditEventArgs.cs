﻿using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Core.Concrete;

namespace MW5.Core.Events
{
    public class AfterShapeEditEventArgs: EventArgs
    {
        private readonly _DMapEvents_AfterShapeEditEvent _args;

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
