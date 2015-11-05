// -------------------------------------------------------------------------------------------
// <copyright file="LayoutRectangle.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using System.Runtime.Serialization;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// A control that draws a standard colored rectangle to the print layout
    /// </summary>
    [DataContract]
    public class LayoutRectangle : LayoutElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutRectangle"/> class.
        /// </summary>
        public LayoutRectangle()
        {
            SetDefaults();
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
        {
            Name = "Rectangle";
            ResizeStyle = ResizeStyle.HandledInternally;
        }

        public override ElementType Type
        {
            get { return ElementType.Rectangle; }
        }

        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            var r = printing
                        ? new RectangleF { X = 0, Y = 0, Width = Rectangle.Width, Height = Rectangle.Height }
                        : Rectangle;
            g.DrawRectangle(Pens.Black, r.X, r.Y, r.Width, r.Height);
        }
    }
}