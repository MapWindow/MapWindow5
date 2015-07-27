using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        public static IDatasource OpenFromIdentity(LayerIdentity identity)
        {
            switch (identity.IdentityType)
            {
                case LayerIdentityType.File:
                    return Open(identity.Filename);
                case LayerIdentityType.OgrDatasource:
                    return OpenFromDatabase(identity.Connection, identity.Query);
                default:
                    throw new ArgumentOutOfRangeException();
            }
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

        private static IEnumerable<string> GetExtensionList(string filename)
        {
            if (filename.ToLower().EndsWith(".shp"))
            {
                var arr = new[] { ".shp", ".shx", ".dbf", ".prj", ".lbl", ".chart", ".mwd", ".mwx", ".shp.mwsymb", ".mwsr" };
                return arr.ToList();
            }
            
            // TODO: add specific provisions for multifile formats apart from ESRI shapefile

            var list = new List<string>() { ".prj", ".xml", ".wld" };

            string ext = Path.GetExtension(filename);

            if (!string.IsNullOrWhiteSpace(ext))
            {
                list.Add(ext);
                list.Add(ext + ".ovr");
                list.Add(ext + ".aux.xml");

                if (ext.Length > 0)
                {
                    // for projection format like: tif => tfw
                    ext = ext.Substring(0, 1) + ext.Substring(ext.Length - 1, 1) + "w";
                    list.Add(ext);
                }

                return list;
            }
          
            return new List<string>();
        }

        /// <summary>
        /// Removes the specified shapefile, including all linked files like .dbf, .prj
        /// </summary>
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

            var list = GetExtensionList(filename).ToList();
            if (!list.Any())
            {
                Logger.Current.Warn("Failed to read file extension: " + filename);
                return false;
            }

            filename = PathHelper.GetFullPathWithoutExtension(filename);
            
            bool result = true;
            foreach (var path in list.Select(ext => filename + ext))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    Logger.Current.Info("Failed to remove file: {0}", ex, path);
                    result = false;
                }
            }

            return result;
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
    }
}
