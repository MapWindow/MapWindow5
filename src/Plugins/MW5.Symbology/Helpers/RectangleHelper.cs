using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class RectangleHelper
    {
        public static Rectangle CloneWithOffset(this Rectangle r, int dx, int dy)
        {
            return new Rectangle(r.X + dx, r.Y + dy, r.Width, r.Height);
        }
    }
}
