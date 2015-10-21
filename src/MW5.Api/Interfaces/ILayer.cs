using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface ILayer: IDynamicVisibilityTarget
    {
        int Handle { get; }
        string Name { get; set; }
        LayerType LayerType { get; }
        bool Visible { get; set; }
        string Filename { get; }
        int Position { get; }
        string Tag { get; set; }
        string Description { get; set; }
        bool LayerVisibleAtCurrentScale { get; }
        bool IsVector { get; }
        bool IsRaster { get; }
        LayerIdentity Identity { get; }

        WmsSource WmsSource { get; }
        IFeatureSet FeatureSet { get ; }
        IImageSource ImageSource { get; }
        IRasterSource Raster { get; }
        ILayerSource LayerSource { get; }
        VectorLayer VectorSource { get; }
        ILabelsLayer Labels { get; }

        bool RemoveOptions(string optionsName);
        bool SaveOptions(string optionsName, bool overwrite, string description);
        bool LoadOptions(string optionsName, ref string description);

        string Serialize();
        bool Deserialize(string state);

        void UpdateSelection(IEnumerable<int> indices, SelectionOperation mode);

        ISpatialReference Projection { get; }
        IEnvelope Envelope { get; }

        string SizeInfo { get; }

        #region Not implemented

        // bool SkipOnSaving { get; set; }
        // void ReSourceLayer(int layerHandle, string newSrcPath);

        #endregion
    }
}
