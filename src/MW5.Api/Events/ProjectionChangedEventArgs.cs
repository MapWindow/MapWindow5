using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Events
{
    public class ProjectionMismatchEventArgs: EventArgs, ICancellableEvent
    {
        private readonly _DMapEvents_ProjectionMismatchEvent _args;

        internal ProjectionMismatchEventArgs(_DMapEvents_ProjectionMismatchEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public bool CancelAdding
        {
            get { return _args.cancelAdding == tkMwBoolean.blnTrue; }
            set { _args.cancelAdding = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }

        public bool Cancel => CancelAdding;

        public bool Reproject
        {
            get { return _args.reproject == tkMwBoolean.blnTrue; }
            set { _args.reproject = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
        }
    }
}
