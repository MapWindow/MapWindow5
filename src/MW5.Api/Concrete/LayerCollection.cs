﻿using System;
using System.Collections;
using System.Collections.Generic;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Api.Legend;

namespace MW5.Api.Concrete
{
    public class LayerCollection : BaseLayerCollection<ILayer>
    {
        public LayerCollection(AxMap axMap)
            : base(axMap)
        {
        }

        public override ILayer ItemByHandle(int layerHandle)
        {
            return new Layer(_axMap, layerHandle);
        }

        public override ILayer this[int position]
        {
            get
            {
                if (position >= 0 && position < Count)
                {
                    var layerHandle = _axMap.get_LayerHandle(position);
                    if (layerHandle != -1)
                    {
                        return new Layer(_axMap, layerHandle);
                    }
                }
                return null;
            }
        }
    }
}