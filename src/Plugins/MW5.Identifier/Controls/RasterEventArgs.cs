using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Identifier.Controls
{
    public class RasterEventArgs : EventArgs
    {
        public RasterEventArgs(int layerHandle, int rasterX, int rasterY)
        {
            LayerHandle = layerHandle;
            RasterX = rasterX;
            RasterY = rasterY;
        }

        public int LayerHandle { get; private set; }
        public int RasterX { get; private set; }
        public int RasterY { get; private set; }
    }
}
