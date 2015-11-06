// -------------------------------------------------------------------------------------------
// <copyright file="LayoutTable.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Table;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Handles visualization of table data
    /// </summary>
    [DataContract]
    public class LayoutTable : LayoutElement
    {
        private TableData _data;
        private TextRenderingHint _textHint;
        private SolidBrush _brush;
        private StringFormat _format;
        private SolidBrush _headerBrush;
        private Pen _pen;
        private Color _color;
        private bool _displayHeader = true;
        private int _horizontalPadding = 3;
        private int _minRowHeight;

        public LayoutTable()
        {
            SetDefaults();
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
        {
            Name = "Table";
            _data = new TableData();
            _font2 = new Font("Arial", 12f);
            _font = new Font("Arial", 10f);
            _displayHeader = true;

            _format = new StringFormat { LineAlignment = StringAlignment.Center };
            _textHint = TextRenderingHint.AntiAliasGridFit;
            _brush = new SolidBrush(Color.Black);
            _headerBrush = new SolidBrush(Color.Transparent);
            _pen = new Pen(Color.Black);
            _color = Color.Transparent;
        }

        [Browsable(false)]
        [DataMember]
        public TableData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [Browsable(true)]
        [DataMember]
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

        [Browsable(true)]
        [CategoryEx(@"cat_symbol")]
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        /// <summary>
        /// This gets called to instruct the element to draw itself in the appropriate spot of the graphics object
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            g.TextRenderingHint = _textHint;

            UpdateWidth(g, export);

            if (Data.RowCount <= 0) return;

            float width = CalcWidth();

            // top vertical line
            g.DrawLine(_pen, x, y, x + width, y);

            float top = y;
            DrawRows(g, x, ref top);

            DrawColumns(g, x, y, top);

            if (!printing && !export)
            {
                _size = new SizeF(width, top - y);
            }
        }

        /// <summary>
        /// Calculates the width of the table in scrren coordinates.
        /// </summary>
        private float CalcWidth()
        {
            float width = Data.Columns.Sum(item => item.ActualWidth);
            if (SizeF.Width < width)
            {
                width = SizeF.Width;
            }

            return width;
        }

        /// <summary>
        /// Draws the columns.
        /// </summary>
        private void DrawColumns(Graphics g, int x, int y, float top)
        {
            float left = x;
            g.DrawLine(_pen, left, y, left, top);

            foreach (var cmn in Data.Columns)
            {
                left += cmn.ActualWidth;
                g.DrawLine(_pen, left, y, left, top);
            }
        }

        /// <summary>
        /// Calculates the maximum height of the row.
        /// </summary>
        private float CalcMaxRowHeight(Graphics g, RowData row, int rowIndex)
        {
            float maxHeight = 0f;
            for (int i = 0; i < row.Count; i++)
            {
                int maxWidth = (int)_data.Columns[i].ActualWidth - _horizontalPadding * 2;
                float height = g.MeasureString(row[i], GetFont(rowIndex), maxWidth).Height;

                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }

            if (maxHeight < MinRowHeight)
            {
                maxHeight = MinRowHeight;
            }

            return maxHeight;
        }

        /// <summary>
        /// Draws the rows and cell data.
        /// </summary>
        private void DrawRows(Graphics g, int x, ref float top)
        {
            for (int j = 0; j < Data.RowCount; j++)
            {
                var row = Data[j];
                bool skip = j == 0 || j == Data.RowCount - 1;

                float maxHeight = CalcMaxRowHeight(g, row, j);

                _headerBrush.Color = FillColor;

                DrawRowData(g, row, skip, maxHeight, top, j, x);

                top += maxHeight;

                DrawRowBottomLine(g, row, x, skip, top, maxHeight, j);
            }
        }

        /// <summary>
        /// Draws the content of cells
        /// </summary>
        private void DrawRowData(Graphics g, RowData row, bool skip, float maxHeight, float top, int rowIndex, float left)
        {
            for (int i = 0; i < row.Count; i++)
            {
                var cmn = _data.Columns[i];
                _format.Alignment = cmn.Alignment;

                float cmnWidth = cmn.ActualWidth;
                float adjTop = (cmn.HalfCellOffset && !skip) ? top + maxHeight / 2 : top;

                if (cmn.HalfCellOffset && !skip && rowIndex == 1)
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

                if (rowIndex == 0)
                {
                    var rectTemp = new RectangleF(left, adjTop, cmnWidth, maxHeight);
                    g.FillRectangle(_headerBrush, rectTemp);
                }

                var format = rowIndex == 0 ? GdiPlusHelper.CenterFormat : _format;
                g.DrawString(row[i], GetFont(rowIndex), _brush, rectText, format);

                left += cmnWidth;
            }
        }

        /// <summary>
        /// Draws the bottom line of each row.
        /// </summary>
        private void DrawRowBottomLine(Graphics g, RowData row, float dx, bool skip, float top, float maxHeight, int rowIndex)
        {
            for (int i = 0; i < row.Count; i++)
            {
                float cmnWidth = _data.Columns[i].ActualWidth;

                float adjTop = (_data.Columns[i].HalfCellOffset && !skip) ? top + maxHeight / 2 : top;

                if (_data.Columns[i].HalfCellOffset && !skip && rowIndex == 1)
                {
                    adjTop = top + maxHeight / 4;
                }

                g.DrawLine(_pen, dx, adjTop, dx + cmnWidth, adjTop); // drawing bottom line
                dx += cmnWidth;
            }
        }

        private Font GetFont(int rowIndex)
        {
            return (rowIndex == 0 && DisplayHeader) ? _font2 : _font;
        }

        private float GetScreenWidth(bool exporting)
        {
            // TODO: consider extracting
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