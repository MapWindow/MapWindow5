using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Controls.ImageCombo;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class ChartHelper
    {
        internal static void UpdateChartFieds(ColorSchemeCombo combo, IFeatureSet fs )
        {
            var schemes = combo.ColorSchemes;

            if (schemes != null && combo.SelectedIndex >= 0)
            {
                var blend = schemes[combo.SelectedIndex];

                var scheme = blend.ToColorScheme();
                if (scheme != null)
                {
                    int fieldCount = fs.Diagrams.Fields.Count;

                    for (int i = 0; i < fieldCount; i++)
                    {
                        var field = fs.Diagrams.Fields[i];
                        double value = i / (double)(fieldCount - 1);
                        field.Color = scheme.GetGraduatedColor(value);
                    }
                }
            }
        }
    }
}
