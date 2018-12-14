namespace MW5.Plugins.Services
{
    public interface ILayerEditingService
    {
        void ToggleVectorLayerEditing();
        bool SaveLayerChanges(int layerHandle);
        void CreateLayer();
        void ToggleSnapToActiveLayer();
        void ToggleSnapToAllLayers();
        void ToggleSnapToSegments();
        void ToggleSnapToVertices();
    }
}
