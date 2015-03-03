namespace MW5.Services.Abstract
{
    public interface ILayerService
    {
        void AddLayer(LayerType layerType);
        bool RemoveSelectedLayer();
    }
}
