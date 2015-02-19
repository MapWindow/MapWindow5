using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;

namespace MW5.Core.Events
{
    public class BackgroundLoadingStartedEventArgs : EventArgs
    {
        private readonly _DMapEvents_BackgroundLoadingStartedEvent _args;

        internal BackgroundLoadingStartedEventArgs(_DMapEvents_BackgroundLoadingStartedEvent args)
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

        public int TaskId
        {
            get { return _args.taskId; }
        }
    }
}
