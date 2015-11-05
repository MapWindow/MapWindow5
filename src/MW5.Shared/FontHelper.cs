using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared
{
    public static class FontHelper
    {
        /// <summary>
        /// Scales font size acording to chosen factor
        /// </summary>
        public static Font ScaleFont(Font font, float scaleFactor)
        {
            if (font != null && font.FontFamily != null)
            {
                var newFont = new Font(font.FontFamily, font.Size * scaleFactor, font.Style);
                return newFont;
            }
            return null;
        }
    }
}
