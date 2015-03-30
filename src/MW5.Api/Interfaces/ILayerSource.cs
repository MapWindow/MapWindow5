namespace MW5.Api.Interfaces
{
 public interface ILayerSource : ISerializableComWrapper, IDatasource
    {
        IEnvelope Envelope { get; }

        ISpatialReference Projection { get; }

        bool IsEmpty { get; }

        LayerType LayerType { get; }
        
        //Labels Labels { get; set; }
    }
}