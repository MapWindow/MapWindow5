using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface ILayerSource : ISerializableComWrapper, IDatasource
    {
        /// <summary>
        /// Gets bounding box of the layer.
        /// </summary>
        IEnvelope Envelope { get; }

        /// <summary>
        /// Gets projection of the layer.
        /// </summary>
        ISpatialReference Projection { get; }

        /// <summary>
        /// Assigns projection to the layer.
        /// </summary>
        void AssignProjection(ISpatialReference proj);

        /// <summary>
        /// Gets a value indicating whether this layer is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        string SizeInfo { get; }
    }
}