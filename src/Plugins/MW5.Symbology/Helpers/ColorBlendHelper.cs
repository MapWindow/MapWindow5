using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class ColorBlendHelper
    {
        /// <summary>
        /// Converts color blend to MapWinGis color scheme
        /// </summary>
        public static ColorRamp ToColorScheme(this ColorBlend blend)
        {
            if (blend == null)
            {
                return null;
            }

            if (blend.Positions.Length == 0 || (blend.Positions.Length != blend.Colors.Length))
            {
                return null;
            }

            var scheme = new ColorRamp();
            for (int i = 0; i < blend.Positions.Length; i++)
            {
                scheme.Add(new ColorInterval(blend.Positions[i], blend.Colors[i]));
            }
            return scheme;
        }
    }
}
