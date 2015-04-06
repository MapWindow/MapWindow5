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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls
{
    // Event delegate definitions

    // Handler for the event when when user changes max visible scale
    public delegate void MaxVisibleScaleChanged(double newScale);
    // Handler for the event when when user changes min visible scale
    public delegate void MinVisibleScaleChanged(double newScale);
    // Handler for the event when when user toggles dynamic visibility
    public delegate void DynamicVisibilityStateChanged(bool newState);
    // Handler for the event when any change occured in the control
    public delegate void StateChanged();

    /// <summary>
    /// A control to set dynamic visiblity, the range of scales for which the layer will be visible.
    /// </summary>
    [ToolboxItem(false)]
    public partial class ScaleControl : UserControl
    {
        #region Member variables
        // The handle selected by user
        internal enum HandleType
        {
            Top = 0,
            Bottom = 1,
            None = 2
        }

        /// <summary>
        /// Holds the information about one of the handles
        /// </summary>
        private class ScaleHandle
        {
            internal bool Selected = false;                     // is it selected
            internal RectangleF Rectangle = new RectangleF();   // position on screen after drawing
            internal int Position = 0;                          // in pixels
            internal HandleType Type = HandleType.None;         // 
            internal double Scale = 0.0;                        // the current scale
        }

        // the width of the region to draw color
        private const int BAND_WIDTH = 15;
        // The max scale to show
        private const int MAX_SCALE = 1000000000;
        // The min scale to show
        private const int MIN_SCALE = 1;
        // offset from the left border of the control to the band
        private const int BAND_OFFSET_X = 40;
        // offset from the band to the top and bottom borders of the control
        private const int BAND_OFFSET_Y = 23;
        // The width of both handlers
        private const float HANDLE_WIDTH = 36.0f;
        // The height of both handlers
        private const float HANDLE_HEIGHT = 12.0f;
       
        // Colors in use
        private Color _colorFill1 = Color.Green;
        private Color _colorFill2 = Color.DarkGray;
        private Color _colorOutline = Color.FromKnownColor(KnownColor.ControlDark);
        private Color _colorSelection = Color.FromKnownColor(KnownColor.Blue);
        private Color _colorHandle = Color.LightGray;

        ScaleHandle _topHandle = new ScaleHandle();
        ScaleHandle _bottomHandle = new ScaleHandle();

        // One of the handles is being dragged currently
        private bool _draggingIsPerformed = false;

        // The handle that is being dragged
        private ScaleHandle _draggedHandle = null;

        // The initial position of the handle being dragged
        private int _draggingInitY = 0;

        // The backbuffer 
        private Bitmap _backBuffer;

        // The current scale of the map
        private double _currentScale;

        // The rectangle to update while dragging
        private Rectangle _updateRectangle;

        // whether control can process paint events
        private bool _locked = false;

        // whether the result of painting should be rendered immediately
        //private bool _sync = false;

        private Font _font = new Font("Microsoft Sans Serif", 8.25f);

        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the ScaleControl class
        /// </summary>
        public ScaleControl()
        {
            _updateRectangle = new Rectangle();
            
            // initialization of handles must be before initialization of the control, i.e. resizing
            _topHandle.Type = HandleType.Top;
            _topHandle.Scale = MAX_SCALE;

            _bottomHandle.Type = HandleType.Bottom;
            _bottomHandle.Scale = MIN_SCALE;

            _currentScale = -1.0;

            InitializeComponent();

            Scale2TextBox(_bottomHandle);
            Scale2TextBox(_topHandle);
        }
        #endregion

        #region Events
        // Fires when user changes the max visible scale by dragging the top handle
        public event MaxVisibleScaleChanged MaxVisibleScaleChanged;
        // Fires when user changes the min visible scale by dragging the bottom handle
        public event MinVisibleScaleChanged MinVisibleScaleChanged;
        // Fires when changes the state of dynamic visiblity
        public event DynamicVisibilityStateChanged DynamicVisibilityStateChanged;
        // Fires when user changes the state of the control
        public event StateChanged StateChanged;
        
        /// <summary>
        /// Sends event to any listeners
        /// </summary>
        protected internal void FireMaxVisibleScaleChanged(double newScale)
        {
            if (MaxVisibleScaleChanged != null)
                MaxVisibleScaleChanged(newScale);

            if (StateChanged != null)
                StateChanged();
        }

        /// <summary>
        /// Sends event to any listeners
        /// </summary>
        protected internal void FireMinVisibleScaleChanged(double newScale)
        {
            if (MinVisibleScaleChanged != null)
                MinVisibleScaleChanged(newScale);

            if (StateChanged != null)
                StateChanged();
        }

        /// <summary>
        /// Sends event to any listeners
        /// </summary>
        protected internal void FireDynamicVisibilityStateChanged(bool newState)
        {
            var handler = DynamicVisibilityStateChanged;
            if (handler != null)
            {
                handler(newState);
            }

            var handler2 = StateChanged;
            if (handler2 != null)
            {
                handler2();
            }
        }
        #endregion

        #region Properties
        
        /// <summary>
        /// Whether control will be processing paint events
        /// </summary>
        public bool Locked
        {
            get { return _locked;}
            set 
            { 
                _locked = value;
                if (!_locked)
                {
                    Invalidate();
                }
            }
        }
        
        /// <summary>
        /// Color of the band fill
        /// </summary>
        public Color FillColor
        {
            get { return _colorFill1; }
            set 
            { 
                _colorFill1 = value;
                Invalidate_(true);
            }
        }

        /// <summary>
        /// Second color of the band fill, in case gradient is used
        /// </summary>
        public Color FillColor2
        {
            get { return _colorFill2; }
            set 
            { 
                _colorFill2 = value;
                Invalidate_(true);
              }
        }

        /// <summary>
        /// The color of outline
        /// </summary>
        public Color OutlineColor
        {
            get { return _colorOutline; }
            set 
            { 
                _colorOutline = value;
                Invalidate_(false);
            }
        }

        /// <summary>
        /// The color of outline
        /// </summary>
        public Color SelectionColor
        {
            get { return _colorSelection; }
            set
            {
                _colorSelection = value;
                Invalidate_(false);
            }
        }

        /// <summary>
        /// Gets or sets the maximum visible scale
        /// </summary>
        public double MaximumScale
        {
            get { return _topHandle.Scale; }
            set 
            {
                SetScale(_topHandle, value);
                FireMaxVisibleScaleChanged(value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum visible scale
        /// </summary>
        public double MinimimScale
        {
            get { return _bottomHandle.Scale; }
            set
            {
                SetScale(_bottomHandle, value);
                FireMinVisibleScaleChanged(value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum visible scale
        /// </summary>
        public bool UseDynamicVisibility
        {
            get { return chkEnabled.Checked; }
            set 
            {
                chkEnabled.Checked = value;
                FireDynamicVisibilityStateChanged(value);
            }
        }

        /// <summary>
        /// Get or sets the current scale of the map
        /// </summary>
        public double CurrentScale
        {
            get { return _currentScale; }
            set { _currentScale = value; }
        }
        #endregion

        #region Dragging
        /// <summary>
        /// Start the dragging operation in case user has clicked a handle
        /// </summary>
        /// <param name="e"></param>
        protected override void  OnMouseDown(MouseEventArgs e)
        {
            ScaleHandle handle;
            
            for (int i = 0; i < 2; i++)
            {
                handle = (i == 0) ? _topHandle : _bottomHandle;
                RectangleF rect = handle.Rectangle;
                
                if (e.X >= rect.X && e.X <= rect.X + rect.Width &&
                    e.Y >= rect.Y && e.Y <= rect.Y + rect.Height)
                {
                    _draggingIsPerformed = true;
                    _draggedHandle = (i == 0) ? _topHandle : _bottomHandle;
                    _draggingInitY = e.Y;
                }
            }
        }

        /// <summary>
        /// Hightlights the handles
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (chkEnabled.Checked)
            {
                // changing position
                if (_draggingIsPerformed)
                {
                    double scale = Position2Scale(e.Y);     // the bounds are checked here, input scale is corrected to the acceptable value
                    // therefore we shall use it to set position further through back conversion
                    if (scale != _draggedHandle.Scale)
                    {
                        SetScale(_draggedHandle, scale);
                    }

                    // adjusting bottom handle
                    if (_draggedHandle.Type == HandleType.Top && _bottomHandle.Position < _draggedHandle.Position)
                    {
                        SetScale(_bottomHandle, scale);
                    }

                    // adjusting top handle
                    if (_draggedHandle.Type == HandleType.Bottom && _topHandle.Position > _draggedHandle.Position)
                    {
                        SetScale(_topHandle, scale);
                    }

                    Invalidate_(true);
                }
                else
                {
                    // just highligting the handle
                    ScaleHandle handle;
                    for (int i = 0; i < 2; i++)
                    {
                        handle = (i == 0) ? _topHandle : _bottomHandle;
                        RectangleF rect = handle.Rectangle;
                        bool newState = (e.X >= rect.X && e.X <= rect.X + rect.Width &&
                                         e.Y >= rect.Y && e.Y <= rect.Y + rect.Height);

                        if (newState != handle.Selected)
                        {
                            handle.Selected = newState;
                            Graphics g = Graphics.FromHwnd(Handle);
                            DrawHandle(g, handle);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Finishes the draging operation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_draggingIsPerformed)
            {
                _draggingIsPerformed = false;
                if (_draggedHandle == _topHandle)
                {
                    MaximumScale = Position2Scale(_topHandle.Position);
                }
                else if(_draggedHandle == _bottomHandle)
                {
                    MinimimScale = Position2Scale(_bottomHandle.Position);
                }
            }
        }
        #endregion

        #region Scale to position conversions
        /// <summary>
        /// Sets the correct position of handles while resizing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _bottomHandle.Position = Scale2Position(_bottomHandle.Scale);
            _topHandle.Position = Scale2Position(_topHandle.Scale);
        }

        /// <summary>
        /// Creating back buffer for drawing
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (Width > 0 && Height > 0)
            {
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                    _backBuffer = null;
                }
                _backBuffer = new Bitmap(Width, Height);
                _updateRectangle = new Rectangle(BAND_OFFSET_X, BAND_OFFSET_Y - (int)HANDLE_HEIGHT, BAND_WIDTH + (int)HANDLE_WIDTH + 5 + 1, Height - 2 * BAND_OFFSET_Y + 2 * (int)HANDLE_HEIGHT + 1);
                //_updateRectangle = new Rectangle(BAND_OFFSET_X + BAND_WIDTH + 5, BAND_OFFSET_Y - (int)HANDLE_HEIGHT, (int)HANDLE_WIDTH + 1, Height - 2 * BAND_OFFSET_Y + 2*(int)HANDLE_HEIGHT +1);
            }
        }

        /// <summary>
        /// Converts given scale to the vertical position in pixels
        /// </summary>
        private int Scale2Position(double scale)
        {
            scale = (scale > MAX_SCALE) ? MAX_SCALE : scale;
            scale = (scale < MIN_SCALE) ? MIN_SCALE : scale;
            double step = (Height - BAND_OFFSET_Y * 2) / 9.0;
            int position = Convert.ToInt32((9.0 - Math.Log10(scale)) * step + (double)BAND_OFFSET_Y);
            return position;
        }

        /// <summary>
        /// Converts given scale to the position
        /// </summary>
        /// <param name="Position">Vertical position in pixels to convert</param>
        private double Position2Scale(int position)
        {
            position = (position < BAND_OFFSET_Y) ? BAND_OFFSET_Y : position;
            position = (position > Height - BAND_OFFSET_Y) ? Height - BAND_OFFSET_Y : position;
            
            float step = (Height - BAND_OFFSET_Y * 2) / 9.0f;
            position -= BAND_OFFSET_Y;

            double scale = Math.Pow(10.0, (double)(9.0 - position / step));
            return scale;
        }

        /// <summary>
        /// Sets the scale for top or bottom handle
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="scale"></param>
        private void SetScale(ScaleHandle handle, double scale)
        {
            scale = (scale > MAX_SCALE) ? MAX_SCALE : scale;
            scale = (scale < MIN_SCALE) ? MIN_SCALE : scale;
            handle.Position = Scale2Position(scale);
            handle.Scale = scale;
            Scale2TextBox(handle);
        }

        /// <summary>
        /// Shows current scale at the textbox
        /// </summary>
        /// <param name="handle"></param>
        private void Scale2TextBox(ScaleHandle handle)
        {
            if (handle.Type == HandleType.Top)
            {
                txtMaxScale.Text = String.Format("{0:F1}", _topHandle.Scale);
                txtMaxScale.Refresh();
            }
            if (handle.Type == HandleType.Bottom)
            {
                txtMinScale.Text = String.Format("{0:F1}", _bottomHandle.Scale);
                txtMinScale.Refresh();
            }
        }
        #endregion

        #region Drawing
        /// <summary>
        /// The Control is being redrawn
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gResult = e.Graphics;
            
            if (!_locked)
            {
                _locked = true;
                Graphics g = Graphics.FromImage(_backBuffer);
                g.Clear(Color.Transparent);

                // drawing color band (all in case it's disabled or a half of it)
                int positionY = (chkEnabled.Checked) ? _topHandle.Position : BAND_OFFSET_Y;
                int dy = (chkEnabled.Checked) ? _bottomHandle.Position - _topHandle.Position : Height - 2 * BAND_OFFSET_Y;

                Rectangle rect = new Rectangle(BAND_OFFSET_X, positionY, BAND_WIDTH, dy);
                if (dy > 0)
                {
                    Brush brush;
                    if (_colorFill1 != _colorFill2)
                    {
                        Color clr1 = chkEnabled.Checked ? _colorFill1 : Color.FromArgb(120, _colorFill1);
                        brush = new LinearGradientBrush(rect, clr1, clr1, LinearGradientMode.Horizontal);
                    }
                    else
                    {
                        Color clr = chkEnabled.Checked ? _colorFill1 : Color.FromArgb(120, _colorFill1);
                        brush = new SolidBrush(clr);
                    }
                    g.FillRectangle(brush, rect);
                }

                rect = new Rectangle(BAND_OFFSET_X, BAND_OFFSET_Y, BAND_WIDTH, Height - 2 * BAND_OFFSET_Y);
                Pen pen = new Pen(_colorOutline);
                g.DrawRectangle(pen, rect);

                // -------------------------------------------------
                // drawing the scale
                // -------------------------------------------------
                float step = (Height - BAND_OFFSET_Y * 2) / 9.0f;

                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                var color = UseDynamicVisibility ? Color.Black : Color.Gray;
                var textBrush = new SolidBrush(color); 

                for (int i = 0; i < 10; i++)
                {
                    float y = BAND_OFFSET_Y + step * i;
                    g.DrawLine(pen, (float)BAND_OFFSET_X - 5, y, BAND_OFFSET_X, y);
                    g.DrawLine(pen, (float)(BAND_OFFSET_X + BAND_WIDTH), y, BAND_OFFSET_X + BAND_WIDTH + 5, y);

                    string s = "1×e" + (9 - i);
                    SizeF size = g.MeasureString(s, _font );
                    size.Width += 2;
                    PointF pos = new PointF(BAND_OFFSET_X - 5.0f - size.Width, y - size.Height / 2.0f);
                    RectangleF r = new RectangleF(pos, size);
                    g.DrawString(s, _font, textBrush, r);
                }

                if (chkEnabled.Checked)
                {
                    if (_topHandle.Selected)
                    {
                        DrawHandle(g, _bottomHandle);
                        DrawHandle(g, _topHandle);
                    }
                    else
                    {
                        DrawHandle(g, _topHandle);
                        DrawHandle(g, _bottomHandle);
                    }
                }

                // drawing current scale
                if (_currentScale != -1.0)
                {
                    int position = Scale2Position(_currentScale);
                    Pen p = new Pen(Color.Red);   //_colorSelection
                    g.DrawRectangle(p, BAND_OFFSET_X - 3, position - 1, BAND_WIDTH + 6, 2);
                    g.FillRectangle(new SolidBrush(Color.Red), BAND_OFFSET_X - 3, position - 1, BAND_WIDTH + 6, 2);
                }

                g.Flush();

                _locked = false;
            }

            gResult.DrawImage(_backBuffer, 0, 0);

            if (_draggingIsPerformed)
            {
                gResult.Flush(FlushIntention.Sync);
            }
        }

        /// <summary>
        /// Draws the top handle
        /// </summary>
        /// <param name="g">Graphics object to draw upon</param>
        /// <param name="handle">A handle to draw.</param>
        private void DrawHandle(Graphics g, ScaleHandle handle)
        {
            // -------------------------------------------------
            // drawing top handle
            // -------------------------------------------------
            PointF[] points = new PointF[4];

            RectangleF r = new RectangleF();
            r.X = BAND_OFFSET_X + BAND_WIDTH + 5;
            r.Y = handle.Position;
            r.Width = HANDLE_WIDTH;
            r.Height = HANDLE_HEIGHT;

            if (handle.Type == HandleType.Top)
            {
                points[0].X = 0.0f; points[0].Y = r.Height;
                points[1].X = r.Width / 3.0f; points[1].Y = 0.0f;
                points[2].X = r.Width; points[2].Y = 0.0f;
                points[3].X = r.Width; points[3].Y = r.Height;
                r.Y -= (int)r.Height;
            }
            else
            {
                points[0].X = 0.0f; points[0].Y = 0.0f;
                points[1].X = r.Width; points[1].Y = 0.0f;
                points[2].X = r.Width; points[2].Y = r.Height;
                points[3].X = 1.0f / 3.0f * r.Width; points[3].Y = r.Height;
            }

            Matrix mtx = new Matrix();
            mtx.Translate(BAND_OFFSET_X + BAND_WIDTH + 5, r.Y);
            g.Transform = mtx;

            Color color = handle.Selected ? _colorSelection : _colorOutline;
            Color colorFill = handle.Selected ? Color.FromKnownColor(KnownColor.Control) : Color.FromKnownColor(KnownColor.ControlLight);

            float width = handle.Selected ? 1.0f : 1.0f;
            g.FillPolygon(new SolidBrush(colorFill), points);
            g.DrawPolygon(new Pen(color, width), points);
            g.ResetTransform();

            // storing the rectangle
            handle.Rectangle = r;
        }
        #endregion

        #region Event handlers for the control
        /// <summary>
        /// Sets max visible scale equal to the current scale
        /// </summary>
        private void btnSetMax_Click(object sender, EventArgs e)
        {
            SetScale(_topHandle, _currentScale);
            Invalidate_(true);
            FireMaxVisibleScaleChanged(_currentScale);
        }

        /// <summary>
        /// Sets the min visible scale equal to the current
        /// </summary>
        private void btnSetMin_Click(object sender, EventArgs e)
        {
            SetScale(_bottomHandle, _currentScale);
            Invalidate_(true);
            FireMinVisibleScaleChanged(_currentScale);
         }

        /// <summary>
        /// Toogles the dynamic visiblity for the layer
        /// </summary>
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = chkEnabled.Checked;
            Invalidate_(false);
            Application.DoEvents();
            FireDynamicVisibilityStateChanged(chkEnabled.Checked);
        }
        
        /// <summary>
        /// Sets the max scale from the user input after Enter button was pressed
        /// </summary>
        private void txtMaxScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMaxScale_Validated(null, null);
            }
        }

        /// <summary>
        /// Sets the scale from the user input
        /// </summary>
        private void txtMaxScale_Validated(object sender, EventArgs e)
        {
            double val;
            if (double.TryParse(txtMaxScale.Text, out val))
            {
                SetScale(_topHandle, val);
                Invalidate_(true);
                FireMaxVisibleScaleChanged(val);
            }
            else
            {
                // reverting to the previous scale
                Scale2TextBox(_topHandle);
            }
        }

        /// <summary>
        /// Sets the min scale from the user input
        /// </summary>
        private void txtMinScale_Validated(object sender, EventArgs e)
        {
            double val;
            if (double.TryParse(txtMinScale.Text, out val))
            {
                SetScale(_bottomHandle, val);
                Invalidate_(true);
                FireMinVisibleScaleChanged(val);
            }
            else
            {
                // reverting to the previous scale
                Scale2TextBox(_bottomHandle);
            }
        }
        
        /// <summary>
        /// Sets the min scale from the user input after Enter button was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMinScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMinScale_Validated(null, null);
            }
        }
        #endregion

        /// <summary>
        /// Invalidates control in case it's not locked
        /// </summary>
        private void Invalidate_(bool updateRectangleOnly)
        {
            if (updateRectangleOnly)
            {
                Invalidate(_updateRectangle);
            }
            else
            {
                Invalidate();
            }
        }
    }
}
