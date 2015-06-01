using System.Drawing;

namespace MW5.Api.Legend
{
    /// <summary>
    /// The layer element, holding position and size of elements
    /// </summary>
    internal class LayerElement
    {
        public LayerElement(LayerElementType type, int layerHandle, Rectangle bounds)
            : this(type, layerHandle, bounds, -1)
        {
        }

        public LayerElement(LayerElementType type, int layerHandle,  Rectangle bounds, int index)
        {
            ElementType = type;
            LayerHandle = layerHandle;
            Index = index;

            Bounds = bounds;
        }

        public LayerElementType ElementType { get; set; }
        public int LayerHandle { get; set; }
        public int Index { get; set; }          // of category or field

        public Rectangle Bounds { get; set; }

        public int Left
        {
            get { return Bounds.X; }
        }

        public int Top
        {
            get { return Bounds.Y; }
        }

        public int Width
        {
            get { return Bounds.Width; }
        }

        public int Height
        {
            get { return Bounds.Height; }
        }

        public bool PointWithin(Point pnt)
        {
            return pnt.X >= Left && pnt.Y >= Top && pnt.X <= Left + Width && pnt.Y <= Top + Height;
        }
    }
}