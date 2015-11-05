// -------------------------------------------------------------------------------------------
// <copyright file="LayoutText.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.Serialization;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Text element.
    /// </summary>
    [DataContract]
    public class LayoutText : LayoutElement
    {
        private Color _color;
        private ContentAlignment _contentAlignment;
        private string _text;
        private TextRenderingHint _textHint = TextRenderingHint.SystemDefault;

        /// <summary>
        /// Constructor
        /// </summary>
        public LayoutText()
        {
            SetDefaults();
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
        {
            Name = "Text";
            _font = new Font("Arial", 10);
            _color = Color.Black;
            _text = "Enter text";
            _textHint = TextRenderingHint.AntiAliasGridFit;
            _contentAlignment = ContentAlignment.TopLeft;
            ResizeStyle = ResizeStyle.HandledInternally;
        }

        /// <summary>
        /// Gets or sets the color of the text
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DataMember]
        [DisplayNameEx(@"prop_color")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the content alignment
        /// </summary>
        [Browsable(true)]
        [DataMember]
        [DefaultValue(ContentAlignment.TopLeft)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_align")]
        public ContentAlignment ContentAlignment
        {
            get { return _contentAlignment; }
            set
            {
                _contentAlignment = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the font used to draw this text
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DataMember]
        [DisplayNameEx(@"prop_font")]
        public Font Font
        {
            get { return _font; }
            set
            {
                _font = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the text thats drawn in the graphics object
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DataMember]
        [DisplayNameEx(@"prop_text")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", typeof(UITypeEditor))]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the hinting used to draw the text
        /// </summary>
        [Browsable(true)]
        [DataMember]
        [DefaultValue(TextRenderingHint.AntiAliasGridFit)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_alias")]
        public TextRenderingHint TextHint
        {
            get { return _textHint; }
            set
            {
                _textHint = value;
                RefreshElement();
            }
        }

        public override ElementType Type
        {
            get { return ElementType.Label; }
        }

        /// <summary>
        /// This gets called to instruct the element to draw itself in the appropriate spot of the graphics object
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            var oldHint = g.TextRenderingHint;
            g.TextRenderingHint = _textHint;

            using (Brush colorBrush = new SolidBrush(_color))
            {
                using (var sf = GdiPlusHelper.GetStringFormat(_contentAlignment))
                {
                    var r = new RectangleF { X = x, Y = y, Width = Rectangle.Width, Height = Rectangle.Height };
                    g.DrawString(_text, _font, colorBrush, r, sf);
                }
            }

            g.TextRenderingHint = oldHint;
        }
    }
}