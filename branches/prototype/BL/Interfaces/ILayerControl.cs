using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.BO;

namespace BL.Interfaces
{
    public interface ILayerControl
    {
        void AddLayer(LayerCollection layerGroups);
    }
}
