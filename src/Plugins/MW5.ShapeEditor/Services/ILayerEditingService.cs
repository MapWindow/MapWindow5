namespace MW5.Plugins.ShapeEditor.Services
{
    public interface ILayerEditingService
    {
        void ToggleVectorLayerEditing();
        bool SaveLayerChanges(int layerHandle);
        void CreateLayer();
    }
}
