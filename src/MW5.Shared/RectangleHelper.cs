using System;
using System.Drawing;

namespace MW5.Shared
{
    public static class RectangleHelper
    {
        public static Rectangle CloneWithOffset(this Rectangle r, int dx, int dy)
        {
            return new Rectangle(r.X + dx, r.Y + dy, r.Width, r.Height);
        }

        public static Rectangle FloatRectangleToInt(this RectangleF r)
        {
            return new Rectangle(Convert.ToInt32(r.X), Convert.ToInt32(r.Y), Convert.ToInt32(r.Width), Convert.ToInt32(r.Height));
        }
    }
}
