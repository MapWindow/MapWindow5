using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Identifier.Controls
{
    public class ShapeEventArgs: EventArgs
    {
        public ShapeEventArgs(int layerHandle, int shapeIndex)
        {
            LayerHandle = layerHandle;
            ShapeIndex = shapeIndex;
        }

        public int LayerHandle { get; private set; }
        public int ShapeIndex { get; private set; }
    }
}
