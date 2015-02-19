using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;

namespace MW5.Core.Events
{
    public class GridOpenedEventArgs: EventArgs
    {
        private readonly _DMapEvents_GridOpenedEvent _args;

        internal GridOpenedEventArgs(_DMapEvents_GridOpenedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public int BandIndex
        {
            get { return _args.bandIndex; }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
        }

        public string GridFilename
        {
            get { return _args.gridFilename; }
        }

        public bool IsUsingProxy
        {
            get { return _args.isUsingProxy; }
        }
    }
}
