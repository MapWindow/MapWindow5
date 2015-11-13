using System;
using AxMapWinGIS;

namespace MW5.Api.Events
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

        public bool FromCache
        {
            get { return _args.fromCache;  }
        }
    }
}
