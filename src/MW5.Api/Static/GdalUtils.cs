using System;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Static
{
    public static class GdalUtils
    {
        private static readonly Utils _utils = new Utils();

        public static string GdalInfo(string srcFilename, string bstrOptions)
        {
            return _utils.GDALInfo(srcFilename, bstrOptions);
        }

        public static bool GdalWarp(string srcFilename, string dstFilename, ISpatialReference newProjection)
        {
            string options = string.Format("-t_srs \"{0}\"", newProjection.ExportToProj4());
            return _utils.GDALWarp(srcFilename, dstFilename, options);
        }

        public static bool GdalWarp(string srcFilename, string dstFilename, string options)
        {
            bool result = _utils.GDALWarp(srcFilename, dstFilename, options);

            if (result)
            {
                Logger.Current.Info("Raster datasource was reprojected: " + dstFilename);
            }
            else
            {
                string s = string.Format("Failed to reprojected raster datasource {0}\r\nOptions: {1}", srcFilename, options);
                s += Environment.NewLine + "Details are likely reported in preceding GDAL messages.";
                Logger.Current.Warn(s);
            }

            return result;
        }

        public static bool GdalBuildVrt(string bstrDstFilename, string bstrOptions)
        {
            return _utils.GDALBuildVrt(bstrDstFilename, bstrOptions);
        }

        public static bool GdalAddOverviews(string bstrSrcFilename, string bstrOptions, string bstrLevels)
        {
            return _utils.GDALAddOverviews(bstrSrcFilename, bstrOptions, bstrLevels);
        }

        public static bool GdalRasterize(string bstrSrcFilename, string bstrDstFilename, string bstrOptions)
        {
            return _utils.GDALRasterize(bstrSrcFilename, bstrDstFilename, bstrOptions);
        }

        public static string OgrInfo(string bstrSrcFilename, string bstrOptions, string bstrLayers)
        {
            return _utils.OGRInfo(bstrSrcFilename, bstrOptions, bstrLayers);
        }

        public static bool Ogr2Ogr(string bstrSrcFilename, string bstrDstFilename, string bstrOptions)
        {
            return _utils.OGR2OGR(bstrSrcFilename, bstrDstFilename, bstrOptions);
        }
    }
}
