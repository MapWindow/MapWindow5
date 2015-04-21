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
        protected readonly int _layerHandle;
        protected readonly AxMap _map;
        protected readonly MapControl _mapControl;

        public Layer(MapControl map, int layerHandle)
        {
            _mapControl = map;
            _map = map.GetInternal() ;
            _layerHandle = layerHandle;

            var position = _map.get_LayerPosition(_layerHandle);
            if (position == -1)
            {
                throw new IndexOutOfRangeException("Invalid layer handle.");
            }
        }

        internal AxMap AxMap
        {
            get { return _map; }
        }

        public int Handle
        {
            get { return _layerHandle; }
        }

      
        public string Name
        {
            get { return _map.get_LayerName(_layerHandle); }

            set { _map.set_LayerName(_layerHandle, value); }
        }
      
        public LayerType LayerType
        {
            get
            {
                if (_map.get_OgrLayer(_layerHandle) != null)
                {
                    return LayerType.VectorLayer;
                }
                
                if (_map.get_Shapefile(_layerHandle) != null)
                {
                    return LayerType.Shapefile;
                }

                if (_map.get_Image(_layerHandle) != null)
                {
                    return LayerType.Image;
                }

                return LayerType.Invalid;
            }
        }

      
        public bool Visible
        {
            get { return _map.get_LayerVisible(_layerHandle); }
            set { _map.set_LayerVisible(_layerHandle, value); }
        }

      
        public bool DynamicVisibility
        {
            get { return _map.get_LayerDynamicVisibility(_layerHandle); }
            set { _map.set_LayerDynamicVisibility(_layerHandle, value); }
        }

      
        public int MinVisibleZoom
        {
            get { return _map.get_LayerMinVisibleZoom(_layerHandle); }
            set { _map.set_LayerMinVisibleZoom(_layerHandle, value); }
        }

      
        public int MaxVisibleZoom
        {
            get { return _map.get_LayerMaxVisibleZoom(_layerHandle); }
            set { _map.set_LayerMaxVisibleZoom(_layerHandle, value); }
        }

      
        public string Filename
        {
            get
            {
                return _map.get_LayerFilename(_layerHandle);
            }
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
            get { return _map.get_LayerPosition(_layerHandle); }
        }

      
        public string Tag
        {
            get { return _map.get_LayerKey(_layerHandle); }
            set { _map.set_LayerKey(_layerHandle, value); }
        }

      
        public double MinVisibleScale
        {
            get { return _map.get_LayerMinVisibleScale(_layerHandle); }
            set { _map.set_LayerMinVisibleScale(_layerHandle, value); }
        }

      
        public double MaxVisibleScale
        {
            get { return _map.get_LayerMaxVisibleScale(_layerHandle); }
            set { _map.set_LayerMaxVisibleScale(_layerHandle, value); }
        }

      
        public string Description
        {
            get { return _map.get_LayerDescription(_layerHandle); }
            set { _map.set_LayerDescription(_layerHandle, value); }
        }

        public bool LayerVisibleAtCurrentScale
        {
            get { return _map.get_LayerVisibleAtCurrentScale(_layerHandle); }
        }

        public bool IsVector
        {
            get { return LayerType == LayerType.Shapefile || LayerType == LayerType.VectorLayer; }
        }

        public IFeatureSet FeatureSet
        {
            get
            {
                var sf = _map.get_Shapefile(_layerHandle);
                return sf != null ? new FeatureSet(sf) : null;
            }
        }
      
        public IImageSource ImageSource
        {
            get
            {
                var img = _map.get_Image(_layerHandle);
                return img != null ? BitmapSource.Wrap(img) : null;
            }
        }

        public ILayerSource LayerSource
        {
            get
            {
                return LayerSourceHelper.ConvertToLayer(_map.get_GetObject(_layerHandle));
            }
        }

        public VectorLayer VectorSource
        {
            get
            {
                var ogr = _map.get_OgrLayer(_layerHandle);
                return ogr != null ? new VectorLayer(ogr) : null;
            }
        }
      
        public ILabelsLayer Labels
        {
            get
            {
                var labels = _map.get_LayerLabels(_layerHandle);
                return labels != null ? new LabelsLayer(labels) : null;
            }
        }

        public bool RemoveOptions(string optionsName)
        {
            return _map.RemoveLayerOptions(_layerHandle, optionsName);
        }

        public bool SaveOptions(string optionsName, bool overwrite, string description)
        {
            return _map.SaveLayerOptions(_layerHandle, optionsName, overwrite, description);
        }

        public bool LoadOptions(string optionsName, ref string description)
        {
            return _map.LoadLayerOptions(_layerHandle, optionsName, ref description);
        }

        public string Serialize()
        {
            return _map.SerializeLayer(_layerHandle);
        }

        public bool Deserialize(string state)
        {
            return _map.DeserializeLayer(_layerHandle, state);
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

            _mapControl.FireSelectionChagned(_mapControl, new SelectionChangedEventArgs(Handle, true));
        }

        public ISpatialReference Projection
        {
            get
            {
                var layerSource = LayerSourceHelper.ConvertToLayer(_map.get_GetObject(_layerHandle));
                if (layerSource != null)
                {
                    return layerSource.Projection;
                }
                return null;
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