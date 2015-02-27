using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class BackgroundLoadingFinishedEventArgs : EventArgs
    {
        private readonly _DMapEvents_BackgroundLoadingFinishedEvent _args;

        internal BackgroundLoadingFinishedEventArgs(_DMapEvents_BackgroundLoadingFinishedEvent args)
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

        public int NumFeatures
        {
            get { return _args.numFeatures; }
        }

        public int NumLoaded
        {
            get { return _args.numLoaded; }
        }

        public int TaskId
        {
            get { return _args.taskId; }
        }
    }
}
