using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;

namespace MW5.Plugins.Symbology.Views.Abstract
{
    public interface IRasterColorSchemeView
    {
        double BandMinValue { get; }
        double BandMaxValue { get; }
        int SelectedPredefinedColorScheme { get; }
        int ActiveBandIndex { get; }

        RasterRendering Rendering { get; }

        RasterColorScheme ColorScheme { get; set; }
    }
}
