// -------------------------------------------------------------------------------------------
// <copyright file="LayoutRectangle.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// A control that draws a standard colored rectangle to the print layout
    /// </summary>
    [DataContract]
    public class LayoutRectangle : LayoutElement
    {
        private float _borderWidth;
        private Color _color;

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
            _borderWidth = 1.0f;
            _color = Color.Black;
        }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(1.0f)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_borderwidth")]
        public float BorderWidth
        {
            get { return _borderWidth; }
            set 
            { 
                _borderWidth = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(typeof(Color), "0x000000")]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_color")]
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
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

            var pen = new Pen(_color, _borderWidth);

            g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
        }
    }
}