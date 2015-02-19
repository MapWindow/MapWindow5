using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;

namespace MW5.Core.Events
{
    public class LayerAddedEventArgs: EventArgs
    {
        private readonly _DMapEvents_LayerAddedEvent _args;

        internal LayerAddedEventArgs(_DMapEvents_LayerAddedEvent args)
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
    }
}
