using System;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    public interface ICreatePyramidsView: IView<IRasterSource>
    {
        event Action ButtonClicked;
        TiffCompression Compression { get; }
        RasterOverviewSampling Sampling { get; }
        bool DontShowAgain { get; }
    }
}
