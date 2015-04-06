using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;

namespace MW5.Api
{
    public class BoundMapControl : MapControl, IMap
    {
        private ILegendLayerCollection<ILayer> _layers;
        private CustomCursor _customCursor = null;

        public BoundMapControl()
        {
            MapCursorChanged += BoundMapControl_MapCursorChanged;
        }

        void BoundMapControl_MapCursorChanged(object sender, EventArgs e)
        {
            if (MapCursor != MapCursor.None)
            {
                _customCursor = null;
                _map.MapCursor = MapWinGIS.tkCursor.crsrMapDefault;
            }
        }

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

                return _layers ?? (_layers = new LegendLayerCollection<ILayer>(this, Legend));
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

        public CustomCursor CustomCursor
        {
            get
            {
                return _customCursor;
            }
            set
            {
                _customCursor = value;
                if (value != null && value.Guid != default(Guid))
                {
                    if (_customCursor.Cursor == null)
                    {
                        _map.MapCursor = MapWinGIS.tkCursor.crsrArrow;
                    }
                    else
                    {
                        _map.UDCursorHandle = (int)_customCursor.Cursor.Handle;
                        _map.MapCursor = MapWinGIS.tkCursor.crsrUserDefined;
                    }
                    MapCursor = MapCursor.None;
                }
            }
        }

        [Browsable(false)]
        public IFeatureSet SelectedFeatureSet
        {
            get
            {
                var layer = Layers.Current;
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
                var layer = Layers.Current;
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
                var layer = Layers.Current;
                if (layer != null)
                {
                    return layer.VectorSource;
                }
                return null;
            }
        }
    }
}
