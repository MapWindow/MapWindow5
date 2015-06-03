using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class RasterComboBoxHelper
    {
        public static void AddRasterBands(this ComboBoxAdv combo, IRasterSource raster, bool withNone = false)
        {
            if (combo == null) return;

            combo.Items.Clear();

            if (withNone)
            {
                combo.Items.Add("<none>");
            }

            int bandCount = raster.Bands.Count;
            for (int i = 1; i <= bandCount; i++)
            {
                string bandName = raster.GetBandFullName(i);
                combo.Items.Add(bandName);
            }

            int index = raster.ActiveBandIndex;
            combo.SelectedIndex = index > 0 && index <= bandCount ? index - 1 : 0;
        }
    }
}
