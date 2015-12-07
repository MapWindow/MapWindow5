namespace MW5.Plugins.Services
{
    public interface ILayerEditingService
    {
        void ToggleVectorLayerEditing();
        bool SaveLayerChanges(int layerHandle);
        void CreateLayer();
    }
}
