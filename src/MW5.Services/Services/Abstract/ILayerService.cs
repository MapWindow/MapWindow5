namespace MW5.Services.Services.Abstract
{
    public interface ILayerService
    {
        bool AddLayer(LayerType layerType);
        bool RemoveSelectedLayer();
        bool AddLayersFromFilename(string filename);
        void ToggleVectorLayerEditing();
        bool SaveLayerChanges(int layerHandle);
        void CreateLayer();
    }
}
