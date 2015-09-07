using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Enums;

namespace MW5.Services.Views
{
    public class SelectLayerModel
    {
        private readonly IEnumerable<LayerItem> _layers;
        private readonly DataSourceType _layerType;

        public SelectLayerModel(IEnumerable<LayerItem> layers, DataSourceType layerType)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            _layers = layers.ToList();
            _layerType = layerType;
        }

        public IEnumerable<LayerItem> Layers
        {
            get { return _layers; }
        }

        public DataSourceType LayerType
        {
            get { return _layerType;  }
        }
    }
}
