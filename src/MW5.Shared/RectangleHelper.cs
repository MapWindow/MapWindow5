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

        public static Rectangle Clone(this Rectangle r)
        {
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        public static RectangleF Clone(this RectangleF r)
        {
            return new RectangleF(r.X, r.Y, r.Width, r.Height);
        }

        public static RectangleF GetIntersection(Rectangle page, RectangleF r)
        {
            var result = new RectangleF();

            result.X = Math.Max(r.X, page.X);
            result.Y = Math.Max(r.Y, page.Y);
            result.Width = Math.Min(r.Right, page.Right) - result.X;
            result.Height = Math.Min(r.Bottom, page.Bottom) - result.Y;

            return result;
        }
    }
}
