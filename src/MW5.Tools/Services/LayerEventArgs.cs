using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model;

namespace MW5.Tools.Services
{
    internal class LayerEventArgs: EventArgs
    {
        public LayerEventArgs(LayerWrapper layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            Layer = layer;
        }

        public LayerWrapper Layer { get; private set; }
    }
}
