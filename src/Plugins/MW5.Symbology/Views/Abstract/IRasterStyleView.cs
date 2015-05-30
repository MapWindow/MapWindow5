using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Controls;

namespace MW5.Plugins.Symbology.Views.Abstract
{
    public interface IRasterStyleView: IComplexView<ILegendLayer>
    {
        void UiToModel();
        RasterRenderingPresenter RenderingPresenter { get; }
        void ClearColorAdjustments();
    }
}
