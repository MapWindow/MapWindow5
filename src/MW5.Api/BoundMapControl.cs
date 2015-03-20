using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;

namespace MW5.Api
{
    public class BoundMapControl : MapControl, IMap
    {
        private ILegendLayerCollection<ILayer> _layers;

        [Browsable(false)]
        public IMuteLegend Legend { get; set; }

        [Browsable(false)]
        public new ILegendLayerCollection<ILayer> Layers
        {
            get
            {
                if (Legend == null)
                {
                    throw new NullReferenceException(
                        "MapControl.Legend property should be set before acceccing layers collection.");
                }

                return _layers ?? (_layers = new LegendLayerCollection<ILayer>(_map, Legend));
            }
        }

        public ILayer GetLayer(int layerHandle)
        {
            return Layers.ItemByHandle(layerHandle);
        }

        public IFeatureSet GetFeatureSet(int layerHandle)
        {
            var layer = GetLayer(layerHandle);
            if (layer != null)
            {
                return layer.FeatureSet;
            }
            return null;
        }

        [Browsable(false)]
        public IFeatureSet SelectedFeatureSet
        {
            get
            {
                var layer = Layers.SelectedLayer;
                if (layer != null)
                {
                    return layer.FeatureSet;
                }
                return null;
            }
        }

        [Browsable(false)]
        public IImageSource SelectedImage
        {
            get
            {
                var layer = Layers.SelectedLayer;
                if (layer != null)
                {
                    return layer.ImageSource;
                }
                return null;
            }
        }

        [Browsable(false)]
        public IVectorLayer SelectedVectorLayer
        {
            get
            {
                var layer = Layers.SelectedLayer;
                if (layer != null)
                {
                    return layer.VectorLayer;
                }
                return null;
            }
        }
    }
}
