using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Concrete
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
