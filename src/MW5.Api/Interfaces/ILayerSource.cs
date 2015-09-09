using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface ILayerSource : ISerializableComWrapper, IDatasource
    {
        IEnvelope Envelope { get; }

        ISpatialReference Projection { get; }

        bool IsEmpty { get; }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        string SizeInfo { get; }
    }
}