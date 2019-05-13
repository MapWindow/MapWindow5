﻿using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Api.Events
{
    public class ValidateShapeEventArgs : EventArgs, ICancellableEvent
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

        public bool Cancel
        {
            get { return _args.cancel == tkMwBoolean.blnTrue; }
            set { _args.cancel = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
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
