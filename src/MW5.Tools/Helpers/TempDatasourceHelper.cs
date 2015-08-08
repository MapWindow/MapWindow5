using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Model;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Savs datasource into temporary file, reopens it as in-memory layer and remove the temp file.
    /// </summary>
    /// <remarks>Deprecated.</remarks>
    internal static class TempDatasourceHelper
    {
        private static bool SaveToTempDatasource(ITempFileService tempFileService, IDatasource ds)
        {
            // We can't the resulting shapefile directly, because it was created by background thread
            // therefore is located in another apartment. This will cause creation of proxies and marshalling
            // for COM, which in turn no always supported by implementation of particular classes in MapWinGIS.
            // Therefore the best option we have is to save into temp file, open it, read into memory, delete the source.
            string filename = tempFileService.GetTempFilename(".shp");
            bool saved = SaveDatasource(ds, filename);
            ds.Dispose();

            if (!saved)
            {
                Logger.Current.Warn("Failed to save datasource to temp file.");
                return false;
            }

            return true;
        }

        private static bool AddTempDataSource(IAppContext context, ILayerService layerService, string filename, OutputLayerInfo outputInfo)
        {
            var fs = FeatureSet.OpenAsInMemoryDatasource(filename);
            if (fs != null)
            {
                // output info name
                if (layerService.AddDatasource(fs))
                {
                    var layer = context.Layers.ItemByHandle(layerService.LastLayerHandle);
                    layer.Name = outputInfo.Name;

                    GeoSource.Remove(filename);
                    return true;
                }
            }

            return false;
        }

        private static bool SaveDatasource(IDatasource ds, string filename)
        {
            if (!GeoSource.Remove(filename))
            {
                return false;
            }

            if (LayerSourceHelper.Save(ds, filename))
            {
                Logger.Current.Info("Layer ({0}) is created.", filename);
                return true;
            }

            Logger.Current.Error("Failed to save datasource: " + ds.LastError, null);
            return false;
        }
    }
}
