// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    [ToolboxItem(true)]
    internal partial class ListControl : UserControl
    {
        Bitmap _backbuffer = null;
        Graphics _graphics = null;
        Size _cellSize = new Size(32, 32);
        int _itemCount = 0;
        int _rowCount = 0;
        int _colCount = 0;
        bool _gridVisible = true;
        Color _gridColor = Color.Black;
        string _fontFamily = string.Empty;
        int _selectedIndex = -1;
        bool _resizeNeeded = true;  // the control's layout should be recalculated in the next OnPaint event
        bool _redrawNeeded = true;  // the control's items should be redrawn in the next OnPaint event

        /// <summary>
        /// Creates a new instance of the char control
        /// </summary>
        public ListControl()
        {
            InitializeComponent();
            
            base.BackColor = Color.Transparent;
            Font fnt = new Font("Arial", _cellSize.Height * 0.8f);
            Font = fnt;
        }

        /// <summary>
        /// Gets or sets the number of items displayed in the control
        /// </summary>
        public int Locked 
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;
                OnResize(null);
            }
        }

        /// <summary>
        /// Gets or sets the number of items displayed in the control
        /// </summary>
        public int ItemCount
        {
            get { return _itemCount;}
            set
            {
                _itemCount = value;
                _resizeNeeded = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Toggles the visibility of the grid lines
        /// </summary>
        public bool GridVisible
        {
            get { return _gridVisible; }
            set
            {
                _gridVisible = value;
                _redrawNeeded = true;
                Invalidate();
            }
        }

        /// <summary>
        /// The color of grid lines
        /// </summary>
        public Color GridColor
        {
            get { return _gridColor; }
            set
            {
                _gridColor = value;
                _redrawNeeded = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets width and height of the cell (used with square cells)
        /// </summary>
        //public int CellSize
        //{
        //    get { return _cellSize.Width; }
        //    set
        //    {
        //        _cellSize.Width = value;
        //        _cellSize.Height = value;
        //        _resizeNeeded = true;
        //    }
        //}

        /// <summary>
        /// Gets or sets the width of the cell
        /// </summary>
        public int CellWidth
        {
            get { return _cellSize.Width; }
            set
            {
                _cellSize.Width = value;
                _resizeNeeded = true;
            }
        }

        /// <summary>
        /// Gets or sets the height of the cell
        /// </summary>
        public int CellHeight
        {
            get { return _cellSize.Height; }
            set
            {
                _cellSize.Height = value;
                _resizeNeeded = true;
            }
        }

        /// <summary>
        /// Gets and sets the index of selected item
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value >= 0 && value < _itemCount)
                {
                    _selectedIndex = value;
                    _redrawNeeded = true;
                    Invalidate();
                }
            }
        }

        protected void Redraw()
        {
            _redrawNeeded = true;
            Invalidate();
        }

        public void RefreshLayout()
        {
            _resizeNeeded = true;
            Invalidate();
        }

        #region Layout
        /// <summary>
        /// Recreates the backbuffer of the control, adjusts scroll bar
        /// </summary>
        protected override void OnResize(System.EventArgs e)
        {
            //if (Width > 0 && Height > 0)
            //{
            //    RecalcLayout();
                
            //    if (_rowCount > 0 && _colCount > 0)
            //    {
            //        _backbuffer = new Bitmap(_cellSize.Width * _colCount + 1, _cellSize.Height * _rowCount + 1);
            //    }
            //    else
            //    {
            //        // create a bitmap to draw the back color
            //        _backbuffer = new Bitmap(Width, Height);
            //    }
                
            //    _graphics = Graphics.FromImage(_backbuffer);
            //    _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //    _graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //    vScrollBar1.Top = 0;
            //    vScrollBar1.Height = Height;
            //    vScrollBar1.Left = Width - vScrollBar1.Width;
            //    vScrollBar1.LargeChange = Height;
            //    vScrollBar1.SmallChange = _cellSize.Height;
            //    vScrollBar1.Minimum = 0;
            //    vScrollBar1.Maximum = _backbuffer.Height; //- Height + vScrollBar1.LargeChange;

            //    DrawGrid();
            //}
            _resizeNeeded = true;
            Invalidate();
        }

        /// <summary>
        /// Recalculates the size of the grid
        /// </summary>
        private void RecalcLayout()
        {
            _rowCount = 0;
            
            // try to show the items without scrollbar
            _colCount = (Width) / (int)_cellSize.Width;
            if (_colCount == 0)
            {
                // not enough place to show a single icon, scrollbar isn't needed
                vScrollBar1.Visible = false;
                return;
            }

            _rowCount = (int)Math.Ceiling((float)_itemCount / (float)_colCount);
            if (_rowCount * _cellSize.Height <= Height)
            {
                // all the items are visible
                vScrollBar1.Visible = false;
            }
            else
            {
                // scrollbar is needed
                _colCount = (Width - vScrollBar1.Width) / (int)_cellSize.Width;
                if (_colCount == 0)
                {
                    vScrollBar1.Visible = false;
                    return;
                }
                else
                {
                    _rowCount = (int)Math.Ceiling((float)_itemCount / (float)_colCount);
                    vScrollBar1.Visible = true;
                }
            }
        }
        #endregion

        #region Drawing
        /// <summary>
        /// Swap the buffers
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_resizeNeeded)
            {
                if (Width > 0 && Height > 0)
                {
                    RecalcLayout();

                    if (_rowCount > 0 && _colCount > 0)
                    {
                        _backbuffer = new Bitmap(_cellSize.Width * _colCount + 1, _cellSize.Height * _rowCount + 1);
                    }
                    else
                    {
                        // create a bitmap to draw the back color
                        _backbuffer = new Bitmap(Width, Height);
                    }

                    _graphics = Graphics.FromImage(_backbuffer);
                    _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    _graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    vScrollBar1.Top = 0;
                    vScrollBar1.Height = Height;
                    vScrollBar1.Left = Width - vScrollBar1.Width;
                    vScrollBar1.LargeChange = Height;
                    vScrollBar1.SmallChange = _cellSize.Height;
                    vScrollBar1.Minimum = 0;
                    vScrollBar1.Maximum = _backbuffer.Height; //- Height + vScrollBar1.LargeChange;

                    _resizeNeeded = false;
                    _redrawNeeded = true;
                }
            }

            if (_redrawNeeded)
            {
                DrawGrid();
                _redrawNeeded = false;
            }

            //base.OnPaint(e);
            if (_backbuffer != null)
            {
                if (vScrollBar1.Visible)
                {
                    int position = vScrollBar1.Value - vScrollBar1.Minimum;
                    Rectangle sourceRect = new Rectangle(0, position, _backbuffer.Width, _backbuffer.Height - position);
                    e.Graphics.DrawImage(_backbuffer, 0, 0, sourceRect, GraphicsUnit.Pixel);
                    e.Graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
                    vScrollBar1.Top = 0;
                    vScrollBar1.Left = Width - vScrollBar1.Width;
                    vScrollBar1.Height = Height;
                    vScrollBar1.Refresh();
                }
                else
                {
                    e.Graphics.DrawImage(_backbuffer, 0, 0);
                }
            }
        }

        /// <summary>
        /// Draws the grid for items
        /// </summary>
        private void DrawGrid()
        {
            _graphics.Clear(base.BackColor);
            
            if (_gridVisible && _itemCount > 0)
            {
                for (int col = 0; col <= _colCount; col++)
                {
                    _graphics.DrawLine(new Pen(_gridColor), new PointF(col * _cellSize.Width, 0), new PointF(col * _cellSize.Width, _rowCount * _cellSize.Height));
                }
                for (int row = 0; row <= _rowCount; row++)
                {
                    _graphics.DrawLine(new Pen(_gridColor), new PointF(0, row * _cellSize.Height), new PointF(_colCount * _cellSize.Width, row * _cellSize.Height));
                }
            }
            DrawItems();
        }

        /// <summary>
        /// Draws items
        /// </summary>
        private void DrawItems()
        {
            for (int i = 0; i < _itemCount; i++)
            {
                int row = i / _colCount;
                int col = i % _colCount;

                RectangleF rect = new RectangleF();
                rect.X = (float)(col * _cellSize.Width);
                rect.Y = (float)(row * _cellSize.Height);
                rect.Width = _cellSize.Width;
                rect.Height = _cellSize.Height;

                bool selected = i == _selectedIndex;
                FireOnDrawItem(_graphics, rect, i, selected);

                if (selected)
                {
                    Color clr = Color.FromArgb(100, Color.CornflowerBlue);
                    _graphics.FillRectangle(new SolidBrush(clr), rect);
                    _graphics.DrawRectangle(new Pen(Color.CornflowerBlue), rect.X, rect.Y, rect.Width, rect.Height);
                }
            }
        }
        #endregion

        #region Interaction
        /// <summary>
        /// Update th control when scroll is moved
        /// </summary>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
            Invalidate();
        }
        
        /// <summary>
        /// Sets the active element of the control
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            float column = (float)(e.X - ClientRectangle.X) / (float)_cellSize.Width;
            float row = (float)(e.Y - ClientRectangle.Y + vScrollBar1.Value) / (float)_cellSize.Height;
            if (column <= 0 || column > _colCount || row <= 0 || row >= _rowCount)
            {
                return;
            }
            else
            {
                int index = _selectedIndex;
                _selectedIndex = (int)row * _colCount + (int)column;
                if (_selectedIndex != index)
                {
                    FireSelectionChanged();
                }
            }
            _redrawNeeded = true;
            Invalidate();
        }

        /// <summary>
        /// Implements scrolling with mouse wheel
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (vScrollBar1.Visible == true)
            {
                int StepSize;
                int MaxSize = vScrollBar1.Maximum - Height;

                StepSize = vScrollBar1.SmallChange;
                if (e.Delta >= 0)
                    StepSize *= -1;

                if (vScrollBar1.Value + StepSize < 0)
                {
                    vScrollBar1.Value = 0;

                }
                else if (vScrollBar1.Value + StepSize > MaxSize)
                {
                    vScrollBar1.Value = MaxSize + 1;
                }
                else
                {
                    vScrollBar1.Value += StepSize;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Moves the selected index by direction keys
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool selectionChanged = true;
            if (e.KeyData == Keys.Left && _selectedIndex > 0)
            {
                _selectedIndex--;
            }
            else if (e.KeyData == Keys.Right && _selectedIndex < _itemCount - 1)
            {
                _selectedIndex++;
            }
            else if (e.KeyData == Keys.Up && _selectedIndex >= _colCount)
            {
                _selectedIndex -= _colCount;
            }
            else if (e.KeyData == Keys.Down && _selectedIndex + _colCount < _itemCount)
            {
                _selectedIndex += _colCount;
            }
            else
            {
                selectionChanged = false;
            }

            if (selectionChanged)
            {
                // ensure the item visibility
                int row = (_selectedIndex + 1) / _colCount;
                int y1 = row * _cellSize.Height;
                int y2 = (row + 1) * _cellSize.Height;
                if (y1 < vScrollBar1.Value)
                {
                    vScrollBar1.Value = y1;
                }
                if (y2 > vScrollBar1.Value + Height)
                {
                    vScrollBar1.Value = y2 - Height + 1;
                }

                _redrawNeeded = true;
                Invalidate();

                FireSelectionChanged();
            }
            e.Handled = true;
        }

        /// <summary>
        /// Prevents the default behavior of direction keys (changing focus)
        /// </summary>
        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            return true;
        }
        #endregion

        #region Events
        /// <summary>
        /// Handler for the event when a selected item was changed
        /// </summary>
        public delegate void SelectionChangedDel();
        public event SelectionChangedDel SelectionChanged;

        protected internal void FireSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged();
        }

        /// <summary>
        ///  Handler for the event when the following item should be drawn
        /// </summary>
        public delegate void OnDrawItemDelegate(Graphics graphics, RectangleF rect, int itemIndex, bool selected);
        public event OnDrawItemDelegate OnDrawItem;

        protected internal void FireOnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            if (OnDrawItem != null)
                OnDrawItem(graphics, rect, itemIndex, selected);
        }

        #endregion
    }
}
