namespace MW5.Services.Abstract
{
    public interface ILayerService
    {
        bool AddLayer(LayerType layerType);
        bool RemoveSelectedLayer();
        bool AddLayersFromFilename(string filename);
    }
}
