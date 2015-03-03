using System.Drawing;

namespace MW5.Api.Legend
{
    /// <summary>
    /// The layer element, holding position and size of elements
    /// </summary>
    internal class LayerElement
    {
        internal LayerElement(LayerElementType type, int top, int left, int width, int height)
        {
            Text = string.Empty;
            Index = -1;
            ElementType = type;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        internal LayerElement(LayerElementType type, Rectangle rect, string text, int index)
        {
            Text = string.Empty;
            Index = -1;
            ElementType = type;
            Top = rect.Top;
            Left = rect.Left;
            Width = rect.Width;
            Height = rect.Height;
            Index = index;
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