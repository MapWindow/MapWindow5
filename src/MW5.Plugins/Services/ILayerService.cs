namespace MW5.Plugins.Services
{
    public interface ILayerService
    {
        bool AddLayer(DataSourceType layerType);
        bool RemoveSelectedLayer();
        bool AddLayersFromFilename(string filename);
        void ToggleVectorLayerEditing();
        bool SaveLayerChanges(int layerHandle);
        void CreateLayer();
        void ZoomToSelected();
        void ClearSelection();
    }
}
