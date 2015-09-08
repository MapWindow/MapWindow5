using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    internal class LayerEventArgs: EventArgs
    {
        public LayerEventArgs(InputSource layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            Layer = layer;
        }

        public InputSource Layer { get; private set; }
    }
}
