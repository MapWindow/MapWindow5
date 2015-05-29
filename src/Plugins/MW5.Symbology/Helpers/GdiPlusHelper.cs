using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class GdiPlusHelper
    {
        /// <summary>
        /// Gets transparent color for GDI+ icon.
        /// </summary>
        public  static Color GetTransparentColor(string imageFilename)
        {
            var bmp = new Bitmap(imageFilename);
            var clrTransparent = Color.White;

            for (int i = 0; i < bmp.Width; i++)
            {
                int j;
                for (j = 0; j < bmp.Height; j++)
                {
                    var clr = bmp.GetPixel(i, j);
                    if (clr.A == 0)
                    {
                        clrTransparent = clr;
                        break;
                    }
                }

                if (j != bmp.Width)
                {
                    break;
                }
            }

            return clrTransparent;
        }

        public static Size GetIconSize(string filename)
        {
            var size = default(Size);

            var bmp = new Bitmap(filename);

            if (bmp.Width <= 16 || bmp.Height <= 16)
            {
                // do nothing - use 32
            }
            else if (bmp.Width < 48 && bmp.Height < 48)
            {
                size.Width = bmp.Height < bmp.Width ? bmp.Height + 16 : bmp.Width + 16;
                size.Height = size.Width;
            }
            else
            {
                size.Width = 48 + 16;
                size.Height = size.Width;
            }

            return size;
        }
    }
}
