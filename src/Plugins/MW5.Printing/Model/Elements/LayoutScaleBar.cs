// -------------------------------------------------------------------------------------------
// <copyright file="LayoutScaleBar.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.Serialization;
using MW5.Api.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// A scale bar control that can be linked to a map and provide a dynamic scale bar for the print layout
    /// </summary>
    [DataContract]
    public class LayoutScaleBar : LayoutElement
    {
        private bool _breakBeforeZero;
        private Color _color;
        private LayoutControl _layoutControl;
        private LayoutMap _layoutMap;
        private int _numBreaks;
        private TextRenderingHint _oldTextHint;
        private Matrix _oldTransform;
        private bool _showScale;
        private TextRenderingHint _textHint;
        private LengthUnits _unit;

        /// <summary>
        /// Constructor
        /// </summary>
        public LayoutScaleBar()
        {
            Name = "Scale Bar";
            _font = new Font("Arial", 10);
            _color = Color.Black;
            _unit = LengthUnits.Kilometers;
            _numBreaks = 4;
            _textHint = TextRenderingHint.AntiAliasGridFit;
            _showScale = true;
            ResizeStyle = ResizeStyle.HandledInternally;
        }

        /// <summary>
        /// Gets or sets a property indicating is break should be present before the 0
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [CategoryEx(@"cat_scale")]
        [DisplayNameEx(@"prop_breakzero")]
        public bool BreakBeforeZero
        {
            get { return _breakBeforeZero; }
            set
            {
                _breakBeforeZero = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [CategoryEx(@"cat_symbol")]
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
        /// Gets or sets the font used to draw this text
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
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
        /// Gets or sets a layout control
        /// </summary>
        [Browsable(false)]
        public LayoutControl LayoutControl
        {
            get { return _layoutControl; }
            set
            {
                _layoutControl = value;
                _layoutControl.ElementsChanged += LayoutControlElementsChanged;
            }
        }

        /// <summary>
        /// Gets or sets the Map control that the scale bar uses for measurement decisions
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_map")]
        [Editor(typeof(LayoutMapEditor), typeof(UITypeEditor))]
        public virtual LayoutMap Map
        {
            get { return _layoutMap; }
            set
            {
                _layoutMap = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the number of breaks the scale bar should have
        /// </summary>
        [Browsable(true)]
        [DefaultValue(4)]
        [CategoryEx(@"cat_scale")]
        [DisplayNameEx(@"prop_breakcount")]
        public int NumberOfBreaks
        {
            get { return _numBreaks; }
            set
            {
                _numBreaks = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets a property indicating is break should be present before the 0
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_scale")]
        [DisplayNameEx(@"prop_showscale")]
        public bool ShowScale
        {
            get { return _showScale; }
            set
            {
                _showScale = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the hinting used to draw the text
        /// </summary>
        [Browsable(true)]
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
            get { return ElementType.Scale; }
        }

        /// <summary>
        /// Gets or sets the unit to use for the scale bar
        /// </summary>
        [Browsable(true)]
        [DefaultValue(LengthUnits.Kilometers)]
        [CategoryEx(@"cat_scale")]
        [DisplayNameEx(@"prop_unit")]
        public LengthUnits Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the unit text to display after the scale bar
        /// </summary>
        [Browsable(false)]
        public string UnitText
        {
            get { return Unit.GetAbbreviatedName(); }
            set { }
        }

        /// <summary>
        /// Drawing code
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            if (_layoutMap == null || _layoutMap.Scale == 0) return;

            var activeFont = Font; // printing ? Util.ScaleFont(Font, ZoomableLayoutControl.LogicToScreenDpi) : Font;

            double geoBreakWidth = GetGeoBreakWidth(g, activeFont);
            if (NumericHelper.Equal(geoBreakWidth, 0.0))
            {
                // TODO: write message about invalid scale
                return;
            }

            int breakWidth = GetBreakScreenWidth(geoBreakWidth);

            var fontSize = MeasureString(g, geoBreakWidth, activeFont);
            float leftStart = fontSize.Width / 2F;

            StartDrawing(g, x, y);

            try
            {
                Brush scaleBrush = new SolidBrush(_color);
                var scalePen = new Pen(scaleBrush);

                float yCenter = fontSize.Height * 1.6f;
                float yTop = fontSize.Height * 1.1f;

                int startBreak = _breakBeforeZero ? -1 : 0;

                // horizontal line
                g.DrawLine(scalePen, leftStart, yCenter, leftStart + (breakWidth * _numBreaks), yCenter);

                // displaying scale at bottom left
                if (ShowScale)
                {
                    var width = MeasureString(g, geoBreakWidth * startBreak, activeFont).Width / 2;
                    g.DrawString("1 : " + Map.Scale, activeFont, scaleBrush, leftStart - width, fontSize.Height * 2.5F);
                }

                // vertical marks
                for (int i = startBreak; i <= _numBreaks + startBreak; i++)
                {
                    g.DrawLine(scalePen, leftStart, yTop, leftStart, fontSize.Height + yTop);

                    var width = MeasureString(g, geoBreakWidth * i, activeFont).Width / 2f;
                    string s = Math.Abs(geoBreakWidth * i).ToString(CultureInfo.InvariantCulture);
                    g.DrawString(s, activeFont, scaleBrush, leftStart - width, 0);

                    leftStart = leftStart + breakWidth;
                }

                // units
                g.DrawString(UnitText, activeFont, scaleBrush, leftStart - breakWidth + (fontSize.Height / 2f), yTop);
            }
            finally
            {
                StopDrawing(g);
            }
        }

        /// <summary>
        /// Gets the width of the break in screen units.
        /// </summary>
        /// <returns></returns>
        private int GetBreakScreenWidth(double geoBreakWidth)
        {
            return Convert.ToInt32(geoBreakWidth / _layoutMap.Scale * _unit.GetConversionFactor() * 100.0);
        }

        /// <summary>
        /// Calculates the width of a break in geographic units
        /// </summary>
        /// <returns></returns>
        private double GetGeoBreakWidth(Graphics g, Font activeFont)
        {
            float unitLegnth = g.MeasureString(UnitText, activeFont).Width * 2;
            double geoBreakWidth = (Size.Width - unitLegnth) / 100.0 / _unit.GetConversionFactor() * _layoutMap.Scale /
                                   _numBreaks;
            double n = Math.Pow(10, Math.Floor(Math.Log10(geoBreakWidth)));
            return Math.Floor(geoBreakWidth / n) * n;
        }

        /// <summary>
        /// Updates the scale bar if the map is deleted
        /// </summary>
        private void LayoutControlElementsChanged(object sender, EventArgs e)
        {
            if (!_layoutControl.LayoutElements.Contains(_layoutMap))
            {
                Map = null;
            }
        }

        private SizeF MeasureString(Graphics g, double value, Font activeFont)
        {
            return g.MeasureString(value.ToString(CultureInfo.InvariantCulture), activeFont);
        }

        private void StartDrawing(Graphics g, int x, int y)
        {
            _oldTransform = g.Transform.Clone();
            _oldTextHint = g.TextRenderingHint;

            var rect = new RectangleF(x - 1, y - 1, Rectangle.Width + 2, Rectangle.Height + 2);
            g.SetClip(rect);

            g.TranslateTransform(x, y);
            g.TextRenderingHint = _textHint;
        }

        private void StopDrawing(Graphics g)
        {
            g.Transform = _oldTransform;
            g.TextRenderingHint = _oldTextHint;
            g.ResetClip();
        }
    }
}