using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Shared;

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

        public static bool CompareByValue(this ColorBlend blend1, ColorBlend blend2)
        {
            if (blend1 == null || blend2 == null)
            {
                return false;
            }

            if (blend1.Colors.Count() != blend2.Colors.Count() ||
                blend1.Positions.Count() != blend2.Positions.Count())
            {
                return false;
            }

            for (int i = 0; i < blend1.Colors.Count(); i++)
            {
                if (blend1.Colors[i] != blend2.Colors[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < blend1.Positions.Count(); i++)
            {
                if (!NumericHelper.Equal(blend1.Positions[i], blend2.Positions[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
