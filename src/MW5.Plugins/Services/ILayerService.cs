// -------------------------------------------------------------------------------------------
// <copyright file="ILayerService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Services
{
    public interface ILayerService
    {
        int LastLayerHandle { get; }

        bool AddDatabaseLayer(string connection, string layerName, GeometryType multiGeometryType = GeometryType.None, ZValueType zValue = ZValueType.None);

        bool AddDatasource(IDatasource ds, string layerName = "");

        bool AddLayer(DataSourceType layerType);

        bool AddLayerIdentity(LayerIdentity identity);

        bool AddLayersFromFilename(string filename);

        bool AddLayersFromFilename(string filename, string layerName);

        void BeginBatch();

        void ClearSelection();

        void EndBatch();

        void LoadStyle();

        bool RemoveLayer(int layerHandle);

        bool RemoveLayer(LayerIdentity identity);

        bool RemoveSelectedLayer();

        void SaveStyle();

        void ZoomToSelected();
    }
}