using System;
using System.ComponentModel;

namespace MW5.Plugins.Events
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
