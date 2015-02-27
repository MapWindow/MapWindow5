namespace MW5.Api.Interfaces
{
 public interface ILayerSource : ISerializableComWrapper, IDatasource
    {
        IEnvelope Envelope { get; }

        ISpatialReference SpatialReference { get; }

        bool IsEmpty { get; }

        //Labels Labels { get; set; }
    }
}