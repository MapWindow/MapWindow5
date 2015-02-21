using System;
using AxMapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class Layer: ILayer
    {
        private readonly int _layerHandle;
        private readonly AxMap _map;

        public Layer(AxMap map, int layerHandle)
        {
            _map = map;
            _layerHandle = layerHandle;

            var position = _map.get_LayerPosition(_layerHandle);
            if (position == -1)
            {
                throw new IndexOutOfRangeException("Invalid layer handle.");
            }
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
            get { return _map.get_LayerFilename(_layerHandle); }
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

        public IFeatureSet VectorSource
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

        public VectorLayer VectorLayer
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

        public string SerializeLayer()
        {
            return _map.SerializeLayer(_layerHandle);
        }

        public bool DeserializeLayer(string state)
        {
            return _map.DeserializeLayer(_layerHandle, state);
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