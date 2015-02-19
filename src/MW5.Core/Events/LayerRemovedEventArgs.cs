using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
{
    public class LayerRemovedEventArgs: EventArgs
    {
        private readonly _DMapEvents_LayerRemovedEvent _args;

        internal LayerRemovedEventArgs(_DMapEvents_LayerRemovedEvent args)
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

        public bool RemoveAllLayers
        {
            get { return _args.fromRemoveAllLayers; }
        }
    }
}
