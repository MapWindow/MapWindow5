// -------------------------------------------------------------------------------------------
// <copyright file="GdiPlusHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;

namespace MW5.Plugins.Printing.Helpers
{
    public static class GdiPlusHelper
    {
        private static StringFormat _centerLeftFormat;
        private static StringFormat _centerFormat;
        private static readonly Bitmap bmp = new Bitmap(1, 1);
        private static Graphics g;

        public static StringFormat CenterFormat
        {
            get
            {
                return _centerFormat ??
                       (_centerFormat =
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

        public static StringFormat CenterLeftFormat
        {
            get
            {
                return _centerLeftFormat ??
                       (_centerLeftFormat =
                        new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
            }
        }

        public static Graphics TempGraphics
        {
            get { return g ?? (g = Graphics.FromImage(bmp)); }
        }

        public static Graphics TempGraphicsDpi100
        {
            get
            {
                var b = new Bitmap(1, 1);
                b.SetResolution(100, 100);
                return Graphics.FromImage(b);
            }
        }

        public static StringFormat GetStringFormat(ContentAlignment alignment)
        {
            var sf = StringFormat.GenericDefault;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }
    }
}