using MW5.Core.Concrete;

namespace MW5.Core.Interfaces
{
    // at least to prevent adding types that are not suppported
    public interface ILayerSource : ISerializableComWrapper
    {
        IEnvelope Envelope { get; }

        string Filename { get; }

        SpatialReference SpatialReference { get; }

        bool IsEmpty { get; }

        void Close();

        string OpenDialogFilter { get; }

        //Labels Labels { get; set; }
    }

    
}