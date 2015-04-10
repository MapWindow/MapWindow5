using System;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Events
{
    public class ExtentsEventArgs: EventArgs
    {
        private readonly IEnvelope _extents;

        public ExtentsEventArgs(IEnvelope extents)
        {
            _extents = extents;
        }

        public IEnvelope Extents
        {
            get { return _extents; }
        }
    }
}
