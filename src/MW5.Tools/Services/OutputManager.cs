using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Services;
using MW5.Services.Concrete;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    public class OutputManager
    {
        private readonly ILayerService _layerService;

        public OutputManager(ILayerService layerService)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            _layerService = layerService;
        }

        public bool Save(IDatasource ds, OutputLayerInfo outputInfo)
        {
            ds.Callback = null;

            if (outputInfo.MemoryLayer)
            {
                return HandleMemoryOutput(ds, outputInfo);
            }

            return HandleDiskOutput(ds, outputInfo);
        }

        private bool HandleDiskOutput(IDatasource ds, OutputLayerInfo outputInfo)
        {
            string filename = outputInfo.Filename;

            if (File.Exists(filename) && !outputInfo.Overwrite)
            {
                return HandleOverwriteFailure();
            }

            bool result = SaveDatasource(ds, filename);

            ds.Dispose();

            if (!result)
            {
                return false;
            }

            outputInfo.DatasourcePointer = new DatasourcePointer(filename);

            if (outputInfo.AddToMap)
            {
                return _layerService.AddLayersFromFilename(filename);
            }

            return true;
        }

        private bool HandleMemoryOutput(IDatasource ds, OutputLayerInfo outputInfo)
        {
            if (!ds.IsVector)
            {
                throw new ApplicationException("Memory layers can only be used for vector datasources.");
            }

            if (!outputInfo.AddToMap)
            {
                throw new ApplicationException("Memory layer option can only be used with add to map option.");
            }

            bool result = _layerService.AddDatasource(ds, outputInfo.Name);
            if (result)
            {
                outputInfo.DatasourcePointer = new DatasourcePointer(_layerService.LastLayerHandle, outputInfo.Name);
            }

            return result;
        }

        private bool HandleOverwriteFailure()
        {
            // TODO: implement
            return false;
        }

        private bool SaveDatasource(IDatasource ds, string filename)
        {
            if (!GeoSource.Remove(filename))
            {
                return HandleOverwriteFailure();
            }

            if (LayerSourceHelper.Save(ds, filename))
            {
                Logger.Current.Info("Layer ({0}) is created.", filename);
                return true;
            }

            Logger.Current.Error("Failed to save datasource: " + ds.LastError);
            return false;
        }
    }
}
