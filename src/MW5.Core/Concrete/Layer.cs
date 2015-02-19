using System;
using AxMapWinGIS;
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

        // object get_GetObject(int layerHandle);
        // Image get_Image(int layerHandle);
        // string get_LayerDescription(int layerHandle);
        // bool get_LayerDynamicVisibility(int layerHandle);
        // string get_LayerFilename(int layerHandle);
        // int get_LayerHandle(int layerPosition);
        // string get_LayerKey(int layerHandle);
        // Labels get_LayerLabels(int layerHandle);
        // double get_LayerMaxVisibleScale(int layerHandle);
        // int get_LayerMaxVisibleZoom(int layerHandle);
        // double get_LayerMinVisibleScale(int layerHandle);
        // int get_LayerMinVisibleZoom(int layerHandle);
        // string get_LayerName(int layerHandle);
        // int get_LayerPosition(int layerHandle);
        // bool get_LayerSkipOnSaving(int layerHandle);
        // bool get_LayerVisible(int layerHandle);
        // bool get_LayerVisibleAtCurrentScale(int layerHandle);
        // OgrLayer get_OgrLayer(int layerHandle);
        // Shapefile get_Shapefile(int layerHandle);

        // void set_Image(int layerHandle, Image param0);
        // void set_LayerDescription(int layerHandle, string param0);
        // void set_LayerDynamicVisibility(int layerHandle, bool param0);
        // void set_LayerKey(int layerHandle, string param0);
        // void set_LayerLabels(int layerHandle, Labels param0);
        // void set_LayerMaxVisibleScale(int layerHandle, double param0);
        // void set_LayerMaxVisibleZoom(int layerHandle, int param0);
        // void set_LayerMinVisibleScale(int layerHandle, double param0);
        // void set_LayerMinVisibleZoom(int layerHandle, int param0);
        // void set_LayerName(int layerHandle, string param0);
        // void set_LayerSkipOnSaving(int layerHandle, bool param0);
        // void set_LayerVisible(int layerHandle, bool param0);
        // void set_Shapefile(int layerHandle, Shapefile param0);

        // bool RemoveLayerOptions(int layerHandle, string optionsName);
        // void ReSourceLayer(int layerHandle, string newSrcPath);
        // bool SaveLayerOptions(int layerHandle, string optionsName, bool overwrite, string description);
        // string SerializeLayer(int layerHandle);

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