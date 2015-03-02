namespace MW5.Api.Legend
{
    using System.Drawing;

    /// <summary>
    /// The layer element, holding position and size of elements
    /// </summary>
    internal class LayerElement
    {
        internal LayerElement(LayerElementType type, int top, int left, int width, int height)
        {
            this.Text = string.Empty;
            this.Index = -1;
            this.ElementType = type;
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
        }

        internal LayerElement(LayerElementType type, Rectangle rect, string text, int index)
        {
            this.Text = string.Empty;
            this.Index = -1;
            this.ElementType = type;
            this.Top = rect.Top;
            this.Left = rect.Left;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.Index = index;
        }

        internal LayerElement(LayerElementType type, Rectangle rect)
            : this(type, rect, string.Empty, -1)
        {
        }

        internal LayerElement(LayerElementType type, Rectangle rect, int index)
            : this(type, rect, string.Empty, index)
        {
        }

        internal LayerElement(LayerElementType type, Rectangle rect, string text)
            : this(type, rect, text, -1)
        {
        }

        internal LayerElementType ElementType { get; set; }

        internal int Height { get; set; }

        internal int Index { get; set; } // of category or field

        internal int Left { get; set; }

        internal string Text { get; set; } // associated text (name or caption)
        // dimensions for easy click text
        internal int Top { get; set; }

        internal int Width { get; set; }
    }
}