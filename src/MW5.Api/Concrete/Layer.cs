using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;

namespace MW5.Api.Concrete
{
    public class Layer: ILayer
    {
        protected readonly int LayerHandle;
        protected readonly AxMap Map;
        protected readonly MapControl MapControl;

        public Layer(MapControl map, int layerHandle)
        {
            MapControl = map;
            Map = map.GetInternal() ;
            LayerHandle = layerHandle;

            var position = Map.get_LayerPosition(LayerHandle);
            if (position == -1)
            {
                throw new IndexOutOfRangeException("Invalid layer handle.");
            }
        }

        internal AxMap AxMap
        {
            get { return Map; }
        }

        public int Handle
        {
            get { return LayerHandle; }
        }

      
        public string Name
        {
            get { return Map.get_LayerName(LayerHandle); }

            set { Map.set_LayerName(LayerHandle, value); }
        }
      
        public LayerType LayerType
        {
            get
            {
                if (Map.get_OgrLayer(LayerHandle) != null)
                {
                    return LayerType.VectorLayer;
                }
                
                if (Map.get_Shapefile(LayerHandle) != null)
                {
                    return LayerType.Shapefile;
                }

                if (Map.get_Image(LayerHandle) != null)
                {
                    return LayerType.Image;
                }

                return LayerType.Invalid;
            }
        }

      
        public bool Visible
        {
            get { return Map.get_LayerVisible(LayerHandle); }
            set { Map.set_LayerVisible(LayerHandle, value); }
        }

      
        public bool DynamicVisibility
        {
            get { return Map.get_LayerDynamicVisibility(LayerHandle); }
            set { Map.set_LayerDynamicVisibility(LayerHandle, value); }
        }

      
        public int MinVisibleZoom
        {
            get { return Map.get_LayerMinVisibleZoom(LayerHandle); }
            set { Map.set_LayerMinVisibleZoom(LayerHandle, value); }
        }

      
        public int MaxVisibleZoom
        {
            get { return Map.get_LayerMaxVisibleZoom(LayerHandle); }
            set { Map.set_LayerMaxVisibleZoom(LayerHandle, value); }
        }

      
        public string Filename
        {
            get
            {
                return Map.get_LayerFilename(LayerHandle);
            }
        }

        public bool IsRaster
        {
            get { return LayerType == LayerType.Grid || LayerType == LayerType.Image; }
        }

        public LayerIdentity Identity
        {
            get
            {
                if (LayerType == LayerType.VectorLayer)
                {
                    var ogr = VectorSource;
                    return new LayerIdentity(ogr.ConnectionString, ogr.SourceQuery);
                }
                
                return new LayerIdentity(Filename);
            }
        }
      
        public int Position
        {
            get { return Map.get_LayerPosition(LayerHandle); }
        }

      
        public string Tag
        {
            get { return Map.get_LayerKey(LayerHandle); }
            set { Map.set_LayerKey(LayerHandle, value); }
        }

      
        public double MinVisibleScale
        {
            get { return Map.get_LayerMinVisibleScale(LayerHandle); }
            set { Map.set_LayerMinVisibleScale(LayerHandle, value); }
        }

      
        public double MaxVisibleScale
        {
            get { return Map.get_LayerMaxVisibleScale(LayerHandle); }
            set { Map.set_LayerMaxVisibleScale(LayerHandle, value); }
        }

      
        public string Description
        {
            get { return Map.get_LayerDescription(LayerHandle); }
            set { Map.set_LayerDescription(LayerHandle, value); }
        }

        public bool LayerVisibleAtCurrentScale
        {
            get { return Map.get_LayerVisibleAtCurrentScale(LayerHandle); }
        }

        public bool IsVector
        {
            get { return LayerType == LayerType.Shapefile || LayerType == LayerType.VectorLayer; }
        }

        public IFeatureSet FeatureSet
        {
            get
            {
                var sf = Map.get_Shapefile(LayerHandle);
                return sf != null ? new FeatureSet(sf) : null;
            }
        }
      
        public IImageSource ImageSource
        {
            get
            {
                var img = Map.get_Image(LayerHandle);
                return img != null ? BitmapSource.Wrap(img) : null;
            }
        }

        public IRasterSource Raster
        {
            get { return ImageSource as IRasterSource; }
        }

        public ILayerSource LayerSource
        {
            get
            {
                return LayerSourceHelper.ConvertToLayer(Map.get_GetObject(LayerHandle));
            }
        }

        public VectorLayer VectorSource
        {
            get
            {
                var ogr = Map.get_OgrLayer(LayerHandle);
                return ogr != null ? new VectorLayer(ogr) : null;
            }
        }
      
        public ILabelsLayer Labels
        {
            get
            {
                var labels = Map.get_LayerLabels(LayerHandle);
                return labels != null ? new LabelsLayer(labels) : null;
            }
        }

        public bool RemoveOptions(string optionsName)
        {
            return Map.RemoveLayerOptions(LayerHandle, optionsName);
        }

        public bool SaveOptions(string optionsName, bool overwrite, string description)
        {
            return Map.SaveLayerOptions(LayerHandle, optionsName, overwrite, description);
        }

        public bool LoadOptions(string optionsName, ref string description)
        {
            return Map.LoadLayerOptions(LayerHandle, optionsName, ref description);
        }

        public string Serialize()
        {
            return Map.SerializeLayer(LayerHandle);
        }

        public bool Deserialize(string state)
        {
            return Map.DeserializeLayer(LayerHandle, state);
        }

        /// <summary>
        /// Changes selection of the shapefile adding new shapes using the specified mode
        /// </summary>
        public void UpdateSelection(IEnumerable<int> indices, SelectionOperation mode)
        {
            var fs = FeatureSet;

            if (fs == null || indices == null)
            {
                return;
            }

            if (mode == SelectionOperation.New)
            {
                fs.ClearSelection();
            }

            var sf = fs.GetInternal();

            switch (mode)
            {
                case SelectionOperation.New:
                    foreach (var item in indices)
                    {
                        sf.ShapeSelected[item] = true;
                    }
                    break;
                case SelectionOperation.Add:
                    foreach (var item in indices)
                    {
                        sf.ShapeSelected[item] = true;
                    }

                    break;
                case SelectionOperation.Exclude:
                    foreach (var item in indices)
                    {
                        sf.ShapeSelected[item] = false;
                    }

                    break;
                case SelectionOperation.Invert:
                    foreach (var item in indices)
                    {
                        sf.ShapeSelected[item] = !sf.ShapeSelected[item];
                    }
                    break;
            }

            MapControl.FireSelectionChanged(MapControl, new SelectionChangedEventArgs(Handle, true));
        }

        public ISpatialReference Projection
        {
            get
            {
                var layerSource = LayerSourceHelper.ConvertToLayer(Map.get_GetObject(LayerHandle));
                if (layerSource != null)
                {
                    return layerSource.Projection;
                }
                return null;
            }
        }

        public IEnvelope Envelope
        {
            get
            {
                var box = Map.get_layerExtents(LayerHandle);
                return box != null ? new Envelope(box) : null;
            }
        }

        #region Deprecated

        // bool get_ShapeLayerDrawFill(int layerHandle);
        // bool get_ShapeLayerDrawLine(int layerHandle);
        // bool get_ShapeLayerDrawPoint(int layerHandle);
        // Color get_ShapeLayerFillColor(int layerHandle);
        // tkFillStipple get_ShapeLayerFillStipple(int layerHandle);
        // float get_ShapeLayerFillTransparency(int layerHandle);
        // Color get_ShapeLayerLineColor(int layerHandle);
        // tkLineStipple get_ShapeLayerLineStipple(int layerHandle);
        // float get_ShapeLayerLineWidth(int layerHandle);
        // Color get_ShapeLayerPointColor(int layerHandle);
        // float get_ShapeLayerPointSize(int layerHandle);
        // tkPointType get_ShapeLayerPointType(int layerHandle);
        // Color get_ShapeLayerStippleColor(int layerHandle);
        // bool get_ShapeLayerStippleTransparent(int layerHandle);

        #endregion
    }
}