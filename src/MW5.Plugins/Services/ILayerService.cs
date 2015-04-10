using MW5.Plugins.Enums;

namespace MW5.Plugins.Services
{
    public interface ILayerService
    {
        bool AddDatabaseLayer(string connection, string layerName);
        bool AddLayer(DataSourceType layerType);
        bool RemoveSelectedLayer();
        bool RemoveLayer(string filename);
        bool AddLayersFromFilename(string filename);
        void ZoomToSelected();
        void ClearSelection();
        int LastLayerHandle { get; }
        void BeginBatch();
        void EndBatch();
        void SaveStyle();
        void LoadStyle();
    }
}
