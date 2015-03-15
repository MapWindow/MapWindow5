using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Concrete
{
    public class LayerRemoveEventArgs: CancelEventArgs
    {
        public LayerRemoveEventArgs(int layerHandle)
        {
            LayerHandle = layerHandle;
            if (layerHandle == -1)
            {
                throw new ApplicationException("Invalid layer handle.");
            }
        }

        public int LayerHandle { get; private set; }
    }
}
