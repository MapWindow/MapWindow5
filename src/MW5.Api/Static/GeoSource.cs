using System;
using System.Diagnostics;
using System.IO;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Static
{
    public static class GeoSource
    {
        private static readonly FileManager _manager;

        static GeoSource()
        {
            _manager = new FileManager();
        }

        private static IDatasource TryOpenAsDatabaseLayer(string filename)
        {
            // the expected format is: "OgrConnection|<connection>|<query_or_layer_name>"
                        
            if (filename == null || !filename.ToLower().StartsWith("ogrconnection"))
            {
                return null;
            }

            var parts = filename.Split('|');
            if (parts.Length == 3)
            {
                var source = _manager.OpenFromDatabase(parts[1], parts[2]);
                return LayerSourceHelper.Convert(source);
            }

            return null;
        }

        public static IDatasource Open(string filename, OpenStrategy openStrategy = OpenStrategy.AutoDetect)
        {
            var result = TryOpenAsDatabaseLayer(filename);
            if (result != null)
            {
                return result;
            }

            var source = _manager.Open(filename, (tkFileOpenStrategy)openStrategy, null);
            return LayerSourceHelper.Convert(source);
        }

        public static IFeatureSet OpenShapefile(string filename)
        {
            var sf = _manager.OpenShapefile(filename);
            if (sf != null)
            {
                return new FeatureSet(sf);
            }
            return null;
        }

        public static IImageSource OpenRaster(string filename, OpenStrategy strategy)
        {
            var img = _manager.OpenRaster(filename, (tkFileOpenStrategy)strategy);
            if (img != null)
            {
                return BitmapSource.Wrap(img);
            }
            return null;
        }

        public static bool ClearGdalOverviews(string filename)
        {
            return _manager.ClearGdalOverviews(filename);
        }

        public static bool BuildGdalOverviews(string filename)
        {
            return _manager.BuildGdalOverviews(filename);
        }

        public static bool RemoveProxyForGrid(string filename)
        {
            return _manager.RemoveProxyForGrid(filename);
        }

        public static VectorLayer OpenFromDatabase(string connectionString, string layerNameOrQuery)
        {
            var layer = _manager.OpenFromDatabase(connectionString, layerNameOrQuery);
            return layer != null ? new VectorLayer(layer) : null;
        }

        public static VectorLayer OpenVectorLayer(string filename, GeometryType preferedGeometryType = GeometryType.None, bool forUpdate = false)
        {
            var shpType = GeometryHelper.GeometryType2ShpType(preferedGeometryType);
            var layer = _manager.OpenVectorLayer(filename, shpType, forUpdate);
            return layer != null ? new VectorLayer(layer) : null;
        }

        public static IVectorDatasource OpenVectorDatasource(string filename)
        {
            var ds = _manager.OpenVectorDatasource(filename);
            return ds != null ? new VectorDatasource(ds) : null;
        }

        public static bool get_IsSupported(string filename)
        {
            return _manager.IsSupported[filename];
        }

        public static bool get_IsRgbImage(string filename)
        {
            return _manager.IsRgbImage[filename];
        }

        public static bool get_IsGrid(string filename)
        {
            return _manager.IsGrid[filename];
        }

        public static bool get_IsVectorLayer(string filename)
        {
            return _manager.IsVectorLayer[filename];
        }

        public static OpenStrategy GetOpenStrategy(string filename)
        {
            return (OpenStrategy)_manager.OpenStrategy[filename];
        }

        public static bool get_CanOpenAs(string filename, OpenStrategy strategy)
        {
            return _manager.CanOpenAs[filename, (tkFileOpenStrategy)strategy];
        }

        public static bool get_IsSupportedBy(string filename, SupportType supportType)
        {
            return _manager.IsSupportedBy[filename, (tkSupportType)supportType];
        }

        public static string LastError
        {
            get { return _manager.ErrorMsg[_manager.LastErrorCode]; }
        }

        public static OpenStrategy LastOpenStrategy
        {
            get { return (OpenStrategy)_manager.LastOpenStrategy; }
        }

        public static string LastOpenFilename
        {
            get { return _manager.LastOpenFilename; }
        }

        public static bool LastOpenIsSuccess
        {
            get { return _manager.LastOpenIsSuccess; }
        }

        public static bool get_HasGdalOverviews(string filename)
        {
            return _manager.HasGdalOverviews[filename];
        }

        public static bool get_HasValidProxyForGrid(string filename)
        {
            return _manager.HasValidProxyForGrid[filename];
        }

        public static string FileFilter
        {
            get { return _manager.CdlgFilter; }
        }

        public static string RasterFilter
        {
            get { return _manager.CdlgRasterFilter; }
        }

        public static string VectorFilter
        {
            get { return _manager.CdlgVectorFilter; }
        }

        public static string SupportedGdalFormats
        {
            get { return _manager.SupportedGdalFormats; }
        }

        public static bool Remove(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            if (!File.Exists(filename))
            {
                return true;
            }

            if (filename.ToLower().EndsWith(".shp"))
            {
                string[] exts = {".shp", ".shx", ".dbf", ".prj", ".lbl", ".chart", ".mwd", ".mwx", ".shp.mwsymb", ".mwsr"};
                filename = PathHelper.GetFullPathWithoutExtension(filename);
                foreach (var ext in exts)
                {
                    string path = filename + ext;
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Info("Failed to remove file: {}", ex, path);
                    }
                }
                return true;
            }

            throw new InvalidOperationException("Unsupported file type.");
        }
    }
}
