using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Plugins.Symbology.Views.Abstract
{
    public interface IRasterColorSchemeView
    {
        double BandMinValue { get; set; }
        double BandMaxValue { get; set; }
        int SelectedPredefinedColorScheme { get; }
        int ActiveBandIndex { get; }

        RasterRendering Rendering { get; }

        RasterColorScheme ColorScheme { get; set; }
    }
}
