using MapWinGIS;

namespace MW5.Api.Static
{
    public static class GdalUtils
    {
        private static Utils _utils = new Utils();

        public static string GdalInfo(string srcFilename, string bstrOptions)
        {
            return _utils.GDALInfo(srcFilename, bstrOptions);
        }

        public static bool GdalWarp(string bstrSrcFilename, string bstrDstFilename, string bstrOptions)
        {
            return _utils.GDALWarp(bstrSrcFilename, bstrDstFilename, bstrOptions);
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
