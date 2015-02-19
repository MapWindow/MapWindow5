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
    public class TilesLoadedEventArgs: EventArgs
    {
        private readonly _DMapEvents_TilesLoadedEvent _args;

        internal TilesLoadedEventArgs(_DMapEvents_TilesLoadedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public string Key
        {
            get { return _args.key; }
        }

        public bool SnapShot
        {
            get { return _args.snapShot; }
        }
    }
}
