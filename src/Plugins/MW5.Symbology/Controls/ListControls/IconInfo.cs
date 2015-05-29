using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    internal class IconInfo
    {
        public readonly Bitmap Image;
        public readonly string Filename;

        internal IconInfo(Bitmap image, string filename)
        {
            Image = image;
            Filename = filename;
        }
    };
}
