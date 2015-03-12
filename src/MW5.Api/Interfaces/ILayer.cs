using MW5.Api.Concrete;

namespace MW5.Api.Interfaces
{
    public interface ILayer
    {
        int Handle { get; }
        string Name { get; }
        LayerType LayerType { get; }
        bool Visible { get; set; }
        bool DynamicVisibility { get; set; }
        int MinVisibleZoom { get; set; }
        int MaxVisibleZoom { get; set; }
        string Filename { get; }
        int Position { get; }
        string Tag { get; set; }
        double MinVisibleScale { get; set; }
        double MaxVisibleScale { get; set; }
        string Description { get; set; }
        bool LayerVisibleAtCurrentScale { get; }
        bool IsVector { get; }

        IFeatureSet FeatureSet { get ; }
        IImageSource ImageSource { get; }
        ILayerSource LayerSource { get; }
        VectorLayer VectorLayer { get; }
        ILabelsLayer Labels { get; }

        bool RemoveOptions(string optionsName);
        bool SaveOptions(string optionsName, bool overwrite, string description);
        bool LoadOptions(string optionsName, ref string description);

        string SerializeLayer();
        bool DeserializeLayer(string state);

        #region Not implemented

        // bool SkipOnSaving { get; set; }
        // void ReSourceLayer(int layerHandle, string newSrcPath);

        #endregion
    }
}
