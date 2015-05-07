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
            if (combo == null) return;      // TODO: should be display anything for BMPs?

            combo.Items.Clear();

            if (withNone)
            {
                combo.Items.Add("<none>");
            }

            for (int i = 1; i <= raster.Bands.Count; i++)
            {
                string bandName = raster.GetBandFullName(i);
                combo.Items.Add(bandName);
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }
    }
}
