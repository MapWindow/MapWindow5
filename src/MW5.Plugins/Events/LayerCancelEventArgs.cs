﻿using MW5.Api.Interfaces;
using System;
using System.ComponentModel;

namespace MW5.Plugins.Events
{
    public class LayerCancelEventArgs: CancelEventArgs, ICancellableEvent
    {
        public LayerCancelEventArgs(int layerHandle)
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
