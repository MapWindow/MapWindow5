using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
{
    public class SelectionChangedEventArgs: EventArgs
    {
        private readonly _DMapEvents_SelectionChangedEvent _args;

        internal SelectionChangedEventArgs(_DMapEvents_SelectionChangedEvent args)
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
