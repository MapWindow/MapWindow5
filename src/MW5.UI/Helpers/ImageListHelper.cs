using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.UI.Helpers
{
    public static class ImageListHelper
    {
        public static ImageList Create(Bitmap[] icons, int size)
        {
            var list = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };

            foreach (var icon in icons)
            {
                var bmp = new Bitmap(icon, new Size(size, size));
                list.Images.Add(bmp);
            }

            return list;
        }
    }
}
