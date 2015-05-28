using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class TextMeasurer
    {
        public static SizeF Measure(string text, Font font, bool gdiPlus)
        {
            if (gdiPlus)
            {
                using (var g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    return g.MeasureString(text, font);
                }
            }

            return TextRenderer.MeasureText(text, font);
        }

        public static SizeF Measure(string text, Font font, bool gdiPlus, int width)
        {
            if (gdiPlus)
            {
                using (var g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    return g.MeasureString(text, font, width);
                }
            }
            
            return TextRenderer.MeasureText(text, font, new Size(width, Int32.MaxValue));
        }
    }
}
