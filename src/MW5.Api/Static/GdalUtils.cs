// -------------------------------------------------------------------------------------------
// <copyright file="GdalUtils.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Shared.Log;

namespace MW5.Api.Static
{
    public class GdalUtils
    {
        private static readonly GdalUtils _staticUilts = new GdalUtils();
        private readonly Utils _utils = new Utils();

        public IGlobalListener Callback
        {
            get { return NativeCallback.UnWrap(_utils.GlobalCallback); }
            set
            {
                var callback = NativeCallback.Wrap(value);
                _utils.GlobalCallback = callback;

                // TODO: implement
                //_utils.StopExecution = callback;
            }
        }

        /// <summary>
        /// instance of MapWinGIS.Utils class. 
        /// Use whenever there is no need to share callback in multithreading scenario.
        /// </summary>
        public static GdalUtils Instance
        {
            get { return _staticUilts; }
        }

        public bool GdalAddOverviews(string bstrSrcFilename, string bstrOptions, string bstrLevels)
        {
            return _utils.GDALAddOverviews(bstrSrcFilename, bstrOptions, bstrLevels);
        }

        public bool GdalBuildVrt(string bstrDstFilename, string bstrOptions)
        {
            return _utils.GDALBuildVrt(bstrDstFilename, bstrOptions);
        }

        public string GdalInfo(string srcFilename, string bstrOptions)
        {
            return _utils.GDALInfo(srcFilename, bstrOptions);
        }

        public bool GdalRasterize(string bstrSrcFilename, string bstrDstFilename, string bstrOptions)
        {
            return _utils.GDALRasterize(bstrSrcFilename, bstrDstFilename, bstrOptions);
        }

        public bool Ogr2Ogr(string bstrSrcFilename, string bstrDstFilename, string bstrOptions)
        {
            return _utils.OGR2OGR(bstrSrcFilename, bstrDstFilename, bstrOptions);
        }

        public string OgrInfo(string bstrSrcFilename, string bstrOptions, string bstrLayers)
        {
            return _utils.OGRInfo(bstrSrcFilename, bstrOptions, bstrLayers);
        }

        public bool TranslateRaster(string srcFilename, string dstFilename, string bstrOptions)
        {
            return _utils.TranslateRaster(srcFilename, dstFilename, bstrOptions);
        }

        public bool WarpRaster(string srcFilename, string dstFilename, ISpatialReference newProjection)
        {
            string options = string.Format("-t_srs \"{0}\"", newProjection.ExportToProj4());
            return _utils.GDALWarp(srcFilename, dstFilename, options);
        }

        public bool WarpRaster(string srcFilename, string dstFilename, string options)
        {
            return _utils.GDALWarp(srcFilename, dstFilename, options);
        }
    }
}