// -------------------------------------------------------------------------------------------
// <copyright file="LegendElement.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;

namespace MW5.Api.Legend
{
    /// <summary>
    /// The layer element, holding position and size of elements
    /// </summary>
    public class LegendElement
    {
        public LegendElement(LayerElementType type, Rectangle bounds)
            : this(type, bounds, -1)
        {
        }

        public LegendElement(LayerElementType type, Rectangle bounds, int index)
        {
            Type = type;
            Index = index;
            Bounds = bounds;
        }

        public Rectangle Bounds { get; private set; }

        public int GroupIndex { get; internal set; }

        /// <summary>
        /// Depending on type gets the index of category, field, etc.
        /// </summary>
        public int Index { get; internal set; }

        public int LayerHandle { get; internal set; }

        public LayerElementType Type { get; internal set; }

        internal bool OutsideControls
        {
            get
            {
                switch (Type)
                {
                    case LayerElementType.CheckBox:
                    case LayerElementType.CategoryCheckbox:
                    case LayerElementType.ExpansionBox:
                        return false;
                }
                
                return true;
            }
        }

        internal int Height
        {
            get { return Bounds.Height; }
        }

        internal int Left
        {
            get { return Bounds.X; }
        }

        internal int Top
        {
            get { return Bounds.Y; }
        }

        internal int Width
        {
            get { return Bounds.Width; }
        }

        public bool PointWithin(Point pnt)
        {
            return pnt.X >= Left && pnt.Y >= Top && pnt.X <= Left + Width && pnt.Y <= Top + Height;
        }
    }
}