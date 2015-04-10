using System;
using System.Drawing;

namespace MW5.Shared
{
    public static class ColorHelper
    {
        public static Color UintToColor(uint val)
        {
            int r, g, b;

            GetRgb((int)val, out r, out g, out b);

            return Color.FromArgb(255, r, g, b);
        }

        public static Color IntToColor(int val)
        {
            int r, g, b;

            GetRgb(val, out r, out g, out b);

            return Color.FromArgb(255, r, g, b);
        }

        public static void GetRgb(int color, out int r, out int g, out int b)
        {
            if (color < 0)
                color = 0;

            r = color & 0xFF;
            g = (color & 0xFF00) / 256;	//shift right 8 bits
            b = (color & 0xFF0000) / 65536; //shift right 16 bits
        }

        public static int ColorToInt(Color c)
        {
            int retval = c.B << 16;
            retval += c.G << 8;
            return retval + c.R;
        }

        public static UInt32 ColorToUInt(Color c)
        {
            int retval = c.B << 16;
            retval += c.G << 8;
            return Convert.ToUInt32(retval + c.R);
        }

        public static int ColorToaInt(Color c)
        {
            int retval = c.B << 16;
            retval += c.G << 8;
            return retval + c.R;
        }

        public static uint ToUInt(this Color? color)
        {
            uint result = 16777215;
            if (color != null)
            {
                result = ColorToUInt(color.Value);
            }
            return result;
        }
    }
}
