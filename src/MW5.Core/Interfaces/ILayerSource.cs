using MW5.Core.Concrete;

namespace MW5.Core.Interfaces
{
 public interface ILayerSource : ISerializableComWrapper, IDatasource
    {
        IEnvelope Envelope { get; }

        SpatialReference SpatialReference { get; }

        bool IsEmpty { get; }

        //Labels Labels { get; set; }
    }
}