using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Static
{
    public static class MapConfig
    {
        private static readonly GlobalSettings _settings = new GlobalSettings();

        static MapConfig()
        {
            _settings.ApplicationCallback = new Callback();
        }

        internal static void Init()
        {
            // intentionally blank; just need to call any member to execute static constructor
        }

        public static void ResetGdalError()
        {
            _settings.ResetGdalError();
        }

        public static bool TestBingApiKey(string key)
        {
            return _settings.TestBingApiKey(key);
        }

        public static void SetHereMapsApiKey(string appId, string appCode)
        {
            _settings.SetHereMapsApiKey(appId, appCode);
        }

        public static GdalError GdalLastErrorNo
        {
            get { return (GdalError)_settings.GdalLastErrorNo; }
        }

        public static GdalErrorType GdalLastErrorType
        {
            get { return (GdalErrorType)_settings.GdalLastErrorType; }
        }

        public static string GdalLastErrorMsg
        {
            get { return _settings.GdalLastErrorMsg; }
        }

        public static string GdalReprojectionErrorMsg
        {
            get { return _settings.GdalReprojectionErrorMsg; }
        }

        public static string get_LocalizedString(LocalizedStrings s)
        {
            return _settings.LocalizedString[(tkLocalizedStrings)s];
        }

        public static void set_LocalizedString(LocalizedStrings s, string value)
        {
            _settings.LocalizedString[(tkLocalizedStrings)s] = value;
        }

        public static bool ZoomToFirstLayer
        {
            get { return _settings.ZoomToFirstLayer; }
            set { _settings.ZoomToFirstLayer = value; }
        }

        public static CollisionMode LabelsCollisionMode
        {
            get { return (CollisionMode)_settings.LabelsCollisionMode; }
            set { _settings.LabelsCollisionMode = (tkCollisionMode) value; }
        }

        public static GridProxyFormat GridProxyFormat
        {
            get { return (GridProxyFormat)_settings.GridProxyFormat; }
            set { _settings.GridProxyFormat = (tkGridProxyFormat)value; }
        }

        public static double MaxGridSizeMb
        {
            get { return _settings.MaxDirectGridSizeMb; }
            set { _settings.MaxDirectGridSizeMb = value; }
        }

        public static GridProxyMode GridProxyMode
        {
            get { return (GridProxyMode)_settings.GridProxyMode; }
            set { _settings.GridProxyMode = (tkGridProxyMode)value; }
        }

        public static int MaxUniqueValuesCountForGridScheme
        {
            get { return _settings.MaxUniqueValuesCountForGridScheme; }
            set { _settings.MaxUniqueValuesCountForGridScheme = value; }
        }

        public static bool RandomColorSchemeForGrids
        {
            get { return _settings.RandomColorSchemeForGrids; }
            set { _settings.RandomColorSchemeForGrids = value; }
        }

        public static PredefinedColors DefaultColorSchemeForGrids
        {
            get { return (PredefinedColors)_settings.DefaultColorSchemeForGrids; }
            set { _settings.DefaultColorSchemeForGrids = (PredefinedColorScheme)value; }
        }

        public static ValidationMode OutputValidationMode
        {
            get { return (ValidationMode)_settings.ShapeOutputValidationMode; }
            set { _settings.ShapeOutputValidationMode = (tkShapeValidationMode)value; }
        }

        public static ValidationMode InputValidationMode
        {
            get { return (ValidationMode)_settings.ShapeInputValidationMode; }
            set { _settings.ShapeInputValidationMode = (tkShapeValidationMode)value; }
        }

        public static bool SaveGridColorSchemeToFile
        {
            get { return _settings.SaveGridColorSchemeToFile; }
            set { _settings.SaveGridColorSchemeToFile = value; }
        }

        public static int MinOverviewWidth
        {
            get { return _settings.MinOverviewWidth; }
            set { _settings.MinOverviewWidth = value; }
        }

        public static RasterOverviewCreation RasterOverviewCreation
        {
            get { return (RasterOverviewCreation)_settings.RasterOverviewCreation; }
            set { _settings.RasterOverviewCreation = (tkRasterOverviewCreation)value; }
        }

        public static TiffCompression TiffCompression
        {
            get { return (TiffCompression)_settings.TiffCompression; }
            set { _settings.TiffCompression = (tkTiffCompression)value; }
        }

        public static GdalResamplingMethod RasterOverviewResampling
        {
            get { return (GdalResamplingMethod)_settings.RasterOverviewResampling; }
            set { _settings.RasterOverviewResampling = (tkGDALResamplingMethod)value; }
        }

        public static int TilesThreadPoolSize
        {
            get { return _settings.TilesThreadPoolSize; }
            set { _settings.TilesThreadPoolSize = value; }
        }

        public static bool LoadSymbologyOnAddLayer
        {
            get { return _settings.LoadSymbologyOnAddLayer; }
            set { _settings.LoadSymbologyOnAddLayer = value; }
        }

        public static InterpolationType ImageUpsamplingMode
        {
            get { return (InterpolationType)_settings.ImageUpsamplingMode; }
            set { _settings.ImageUpsamplingMode = (tkInterpolationMode)value; }
        }

        public static InterpolationType ImageDownsamplingMode
        {
            get { return (InterpolationType)_settings.ImageDownsamplingMode; }
            set { _settings.ImageDownsamplingMode = (tkInterpolationMode)value; }
        }

        public static OgrEncoding OgrEncoding
        {
            get { return (OgrEncoding)_settings.OgrStringEncoding; }
            set { _settings.OgrStringEncoding = (tkOgrEncoding)value; }
        }

        public static bool ReprojectLayersOnAdding
        {
            get { return _settings.ReprojectLayersOnAdding; }
            set { _settings.ReprojectLayersOnAdding = value; }
        }

        public static int HotTrackingMaxCount
        {
            get { return _settings.HotTrackingMaxShapeCount; }
            set { _settings.HotTrackingMaxShapeCount = value; }
        }

        public static bool AllowLayersWithoutProjections
        {
            get { return _settings.AllowLayersWithoutProjections; }
            set { _settings.AllowLayersWithoutProjections = value; }
        }

        public static bool AllowProjectionMismatch
        {
            get { return _settings.AllowProjectionMismatch; }
            set { _settings.AllowProjectionMismatch = value; }
        }

        public static double MouseTolerance
        {
            get { return _settings.MouseTolerance; }
            set { _settings.MouseTolerance = value; }
        }

        public static int MaxReprojectionCount
        {
            get { return _settings.MaxReprojectionShapeCount; }
            set { _settings.MaxReprojectionShapeCount = value; }
        }

        public static PixelOffsetMode PixelOffsetMode
        {
            get { return (PixelOffsetMode)_settings.PixelOffsetMode; }
            set { _settings.PixelOffsetMode = (tkPixelOffsetMode)value; }
        }

        public static bool AutoChooseRenderingHintForLabels
        {
            get { return _settings.AutoChooseRenderingHintForLabels; }
            set { _settings.AutoChooseRenderingHintForLabels = value; }
        }

        public static string GdalVersion
        {
            get { return _settings.GdalVersion; }
        }

        public static bool OgrLayerForceUpdateMode
        {
            get { return _settings.OgrLayerForceUpdateMode; }
            set { _settings.OgrLayerForceUpdateMode = value; }
        }

        public static bool ForceHideLabels
        {
            get { return _settings.ForceHideLabels; }
            set { _settings.ForceHideLabels = value; }
        }

        public static string GdalPluginPath
        {
            get { return _settings.GdalPluginPath; }
            set { _settings.GdalPluginPath = value; }
        }

        public static string GdalDataPath
        {
            get { return _settings.GdalDataPath; }
            set { _settings.GdalDataPath = value; }
        }

        public static string BingApiKey
        {
            get { return _settings.BingApiKey; }
            set { _settings.BingApiKey = value; }
        }

        public static string get_ComUsageReport(bool unreleasedOnly)
        {
            return new Utils().ComUsageReport[unreleasedOnly];
        }

        public static TiffCompression CompressOverviews
        {
            get { return (TiffCompression)_settings.CompressOverviews; }
            set { _settings.CompressOverviews = (tkTiffCompression)value; }
        }

        public static bool GridFavorGreyscale
        {
            get { return _settings.GridFavorGreyscale;  }
            set { _settings.GridFavorGreyscale = value; }
        }

        public static bool GridUseHistogram
        {
            get { return _settings.GridUseHistogram; }
            set { _settings.GridUseHistogram = value; }
        }

        #region Not implemented
        /*
        public static double MinPolygonArea
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static double MinAreaToPerimeterRatio
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static double ClipperGcsMultiplicationFactor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static bool ShapefileFastMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static bool ShapefileFastUnion
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public static tkSmoothingMode LabelsSmoothingMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static tkCompositingQuality LabelsCompositingQuality
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public static int TilesMinZoomOnProjectionMismatch
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
         
        public static tkGeometryEngine GeometryEngine
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public static int OgrLayerMaxFeatureCount
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
         
        public static bool AutoChooseOgrLoadingMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
         * 
         * */
        #endregion
    }
}
