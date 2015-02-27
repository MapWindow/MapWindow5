using System;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Api.Events
{
    public class LayerProjectionIsEmptyEventArgs: EventArgs
    {
        private readonly _DMapEvents_LayerProjectionIsEmptyEvent _args;

        internal LayerProjectionIsEmptyEventArgs(_DMapEvents_LayerProjectionIsEmptyEvent args)
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

        public bool CancelAdding
        {
            get { return _args.cancelAdding == tkMwBoolean.blnTrue; }
            set { _args.cancelAdding = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }
    }
}
