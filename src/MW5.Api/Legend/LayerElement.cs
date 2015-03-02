using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    /// <summary>
    /// The layer element, holding position and size of elements
    /// </summary>
    internal class LayerElement
    {
        internal LayerElementType ElementType;
        internal int Index = -1;                // of category or field
        internal string Text = string.Empty;    // associated text (name or caption)
        
        // dimensions for easy click text
        internal int Top = 0;
        internal int Left = 0;
        internal int Width = 0;
        internal int Height = 0;

        internal LayerElement(LayerElementType type, int top, int left, int width, int height)
        {
            ElementType = type;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        internal LayerElement(LayerElementType type, Rectangle rect, string text, int index)
        {
            ElementType = type;
            Top = rect.Top;
            Left = rect.Left;
            Width = rect.Width;
            Height = rect.Height;
            Index = index;
        }

        internal LayerElement(LayerElementType type, Rectangle rect) : this(type, rect, string.Empty, -1) { }

        internal LayerElement(LayerElementType type, Rectangle rect, int index) : this(type, rect, string.Empty, index) { }

        internal LayerElement(LayerElementType type, Rectangle rect, string text) : this(type, rect, text, -1) { }
    }
}
