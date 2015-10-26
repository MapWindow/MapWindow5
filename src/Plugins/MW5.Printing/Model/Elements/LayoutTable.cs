// -------------------------------------------------------------------------------------------
// <copyright file="LayoutTable.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Table;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Handles visualization of table data
    /// </summary>
    public class LayoutTable : LayoutElement
    {
        private const TextRenderingHint _textHint = TextRenderingHint.AntiAliasGridFit;
        private readonly SolidBrush _brush = new SolidBrush(Color.Black);
        private readonly TableData _data;

        private readonly StringFormat _format = new StringFormat
                                                    {
                                                        LineAlignment = StringAlignment.Center,
                                                        Alignment = StringAlignment.Far
                                                    };

        private readonly SolidBrush _headerBrush = new SolidBrush(Color.Transparent);
        private readonly Pen _pen = new Pen(Color.Black);
        private Color _color = Color.Transparent;

        private bool _displayHeader = true;
        private int _horizontalPadding = 3;
        private int _minRowHeight;

        internal LayoutTable()
        {
            Name = "Table";
            _data = new TableData();
            _font2 = new Font("Arial", 12f);
            _font = new Font("Arial", 10f);
            _displayHeader = true;
        }

        public LayoutTable(string data)
            : this()
        {
            _data = new TableData(data);
        }

        [Browsable(false)]
        public TableData Data
        {
            get { return _data; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_displayheader")]
        public bool DisplayHeader
        {
            get { return _displayHeader; }
            set
            {
                _displayHeader = value;
                RefreshElement();
            }
        }

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

        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_headerfont")]
        public Font HeaderFont
        {
            get { return _font2; }
            set
            {
                _font2 = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DefaultValue(4)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_horizontalpadding")]
        public int HorizontalPadding
        {
            get { return _horizontalPadding; }
            set
            {
                _horizontalPadding = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DefaultValue(3)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_minrowheight")]
        public int MinRowHeight
        {
            get { return _minRowHeight; }
            set
            {
                _minRowHeight = value;
                RefreshElement();
            }
        }

        public override ElementType Type
        {
            get { return ElementType.Table; }
        }

        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_header_fill_color")]
        protected Color FillColor
        {
            get { return _color; }
            set
            {
                _color = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Adjust columns width according to their data
        /// </summary>
        public void UpdateWidth(Graphics g, bool printing)
        {
            if (Data.Columns.Count == 0) return;

            for (int i = 0; i < Data.Columns.Count; i++)
            {
                Data.Columns[i].ActualWidth = TextWidth(g, i);
            }

            var sum = _data.Columns.Sum(cmn => cmn.ActualWidth);
            var width = GetScreenWidth(printing);
            float ratio = sum / width;

            foreach (var cmn in _data.Columns)
            {
                cmn.ActualWidth /= ratio;
            }
        }

        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            g.TextRenderingHint = _textHint;

            UpdateWidth(g, export);

            if (Data.RowCount <= 0) return;

            float width = Data.Columns.Sum(item => item.ActualWidth);
            if (Size.Width < width) width = Size.Width;

            // drawing rows
            float left;
            float top = y;

            for (int j = 0; j < Data.RowCount; j++)
            {
                var row = Data[j];
                bool skip = j == 0 || j == Data.RowCount - 1;

                float maxHeight = 0f;
                for (int i = 0; i < row.Count; i++)
                {
                    int maxWidth = (int)_data.Columns[i].ActualWidth - _horizontalPadding * 2;
                    float height = g.MeasureString(row[i], GetFont(j), maxWidth).Height;

                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                }

                if (maxHeight < MinRowHeight)
                {
                    maxHeight = MinRowHeight;
                }

                _headerBrush.Color = FillColor;
                left = x;

                for (int i = 0; i < row.Count; i++)
                {
                    var cmn = _data.Columns[i];
                    _format.Alignment = cmn.Alignment;

                    float cmnWidth = cmn.ActualWidth;
                    float adjTop = (cmn.HalfCellOffset && !skip) ? top + maxHeight / 2 : top;

                    if (cmn.HalfCellOffset && !skip && j == 1)
                    {
                        adjTop = top + maxHeight / 4;
                    }

                    var rectText = new RectangleF
                                       {
                                           X = left + _horizontalPadding,
                                           Y = adjTop,
                                           Width = cmnWidth - _horizontalPadding * 2,
                                           Height = maxHeight
                                       };
                    if (j == 0)
                    {
                        var rectTemp = new RectangleF(left, adjTop, cmnWidth, maxHeight);
                        g.FillRectangle(_headerBrush, rectTemp);
                    }

                    g.DrawString(row[i], GetFont(j), _brush, rectText, j == 0 ? GdiPlusHelper.CenterFormat : _format);
                    left += cmnWidth;
                }

                top += maxHeight;
                float dx = x;

                for (int i = 0; i < row.Count; i++)
                {
                    float cmnWidth = _data.Columns[i].ActualWidth;
                    float adjTop = (_data.Columns[i].HalfCellOffset && !skip) ? top + maxHeight / 2 : top;
                    if (_data.Columns[i].HalfCellOffset && !skip && j == 1) adjTop = top + maxHeight / 4;
                    g.DrawLine(_pen, dx, adjTop, dx + cmnWidth, adjTop); // drawing bottom line
                    dx += cmnWidth;
                }
            }
            g.DrawLine(_pen, x, y, x + width, y);

            // drawing columns
            left = x;
            g.DrawLine(_pen, left, y, left, top);
            foreach (var cmn in Data.Columns)
            {
                left += cmn.ActualWidth;
                g.DrawLine(_pen, left, y, left, top);
            }

            if (!printing && !export) _size = new SizeF(width, top - y);
        }

        private Font GetFont(int rowIndex)
        {
            return (rowIndex == 0 && DisplayHeader) ? _font2 : _font;
        }

        private float GetScreenWidth(bool exporting)
        {
            return exporting ? Width * 96 / 100 : Width;
        }

        /// <summary>
        /// Returns maximum text width for a column
        /// </summary>
        private float TextWidth(Graphics g, int columnIndex)
        {
            float maxWidth = 0;

            for (int i = 0; i < Data.RowCount; i++)
            {
                var row = Data[i];
                float width = g.MeasureString(row[columnIndex], GetFont(i)).Width + _horizontalPadding * 2;

                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }

            return maxWidth;
        }
    }
}