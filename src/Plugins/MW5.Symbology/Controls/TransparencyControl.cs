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
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls
{
    [ToolboxItem(false)]
    public partial class TransparencyControl : UserControl
    {
        // The backbuffer 
        private Bitmap _backBuffer;
        
        // The color of the band
        private Color _color;

        // The rectangle to update while dragging
        private Rectangle _updateRectangle;

        // Control is locked while drawing
        private bool _locked = false;

        private Color _colorOutline = Color.FromKnownColor(KnownColor.ControlDark);
        private Color _colorSelection = Color.FromKnownColor(KnownColor.Blue);
        private Color _colorHandle = Color.LightGray;

        // the position of handle (value of transparency)
        byte _value = 255;

        private const int BAND_HEIGHT = 10;
        private const int BAND_OFFSET = 8;
        private const int HANDLE_WIDTH = 10;
        private const int HANDLE_HEIGHT = 16;

        /// <summary>
        /// Holds the information about one of the handles
        /// </summary>
        private class TranspHandle
        {
            internal bool Selected = false;                     // is it selected
            internal RectangleF Rectangle = new RectangleF();   // position on screen after drawing
            internal int Position = 0;                          // in pixels
        }

        // Controls handle
        TranspHandle _handle = null;

        // Are we drag the handle ?
        private bool _draggingIsPerformed = false;
        
        // position from which the drawgging was started
        private int _draggingStart = 0;

        #region Events
        // Handler for the event when when user changes max visible scale
        public delegate void ValueChangedDeleg(object sender, byte value);

        // Fires when user changes the state of the control
        public event ValueChangedDeleg ValueChanged;

        /// <summary>
        /// Sends event to any listeners
        /// </summary>
        protected internal void FireValueChanged(object sender, byte value)
        {
            if (ValueChanged != null)
                ValueChanged(this, value);
        }
        #endregion

        // Creates a new instance of the TransparencyControl class
        public TransparencyControl()
        {
            _updateRectangle = new Rectangle();
            _handle = new TranspHandle();
            
            InitializeComponent();

            this.SizeChanged += TransparencyControl_SizeChanged;
        }

        void TransparencyControl_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Left = this.Width - textBox1.Width - 10;

        }

        /// <summary>
        /// Handles resizing of the control
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Width > 0 && this.Height > 0)
            {
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                    _backBuffer = null;
                }
                _backBuffer = new Bitmap(this.Width, this.Height);
                _updateRectangle = new Rectangle(0, 0, this.ClientRectangle.Width - textBox1.Width, BAND_HEIGHT + HANDLE_HEIGHT + 3);
                _handle.Position = PositionFromValue(_value);
            }
        }

        #region Properties
        /// <summary>
        /// Color of the band fill
        /// </summary>
        public Color BandColor
        {
            get { return _color; }
            set
            {
                _color = value;
                this.Invalidate_(true);
            }
        }

        /// <summary>
        /// The transparency value
        /// </summary>
        public byte Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    _handle.Position = PositionFromValue(_value);
                    textBox1.Text = _value.ToString();
                    this.Invalidate_(true);
                }
            }
        }
        #endregion

        #region Drawing
        /// <summary>
        /// The Control is being redrawn
        /// </summary>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics gResult = e.Graphics;

            if (!_locked)
            {
                _locked = true;
                Graphics g = Graphics.FromImage(_backBuffer);
                g.Clear(Color.Transparent);

                Rectangle rect;

                int w = PositionFromValue(_value) - BAND_OFFSET;
                if (w > 0)
                {
                    rect = new Rectangle(BAND_OFFSET, 0, w, BAND_HEIGHT);
                    Color clr1 = Color.FromArgb(0, _color);
                    Color clr2 = Color.FromArgb(_value, _color);
                    Brush brush = new LinearGradientBrush(rect, clr1, clr2, LinearGradientMode.Horizontal);
                    g.FillRectangle(brush, rect);
                }

                rect = new Rectangle(BAND_OFFSET, 0, BandWidth, BAND_HEIGHT);
                Pen pen = new Pen(Color.Gray);
                g.DrawRectangle(pen, rect);

                DrawHandle(g);
               
                _locked = false;
            }

            // drawing the buffer
            gResult.DrawImage(_backBuffer, 0, 0);

            if (_draggingIsPerformed)
            {
                gResult.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            }
        }

        /// <summary>
        /// Draws the top handle
        /// </summary>
        /// <param name="g">Graphics object to draw upon</param>
        private void DrawHandle(Graphics g)
        {
            PointF[] points = new PointF[5];

            RectangleF r = new RectangleF();
            r.X = 0;
            r.Y = 0;
            r.Width = HANDLE_WIDTH;
            r.Height = HANDLE_HEIGHT;
           
            points[0].X = r.Width/2; points[0].Y = 0.0f;
            points[1].X = r.Width; points[1].Y = r.Height/3;
            points[2].X = r.Width; points[2].Y = r.Height;
            points[3].X = 0; points[3].Y = r.Height;
            points[4].X = 0; points[4].Y = r.Height/3;

            float x = PositionFromValue(_value) - HANDLE_WIDTH/2;

            Matrix mtx = new Matrix();
            mtx.Translate(x, BAND_HEIGHT + 2);
            g.Transform = mtx;

            Color color = _handle.Selected ? Color.FromKnownColor(KnownColor.ControlDarkDark) : Color.FromKnownColor(KnownColor.ControlDark);
            Color colorFill = _handle.Selected ? Color.FromKnownColor(KnownColor.Control) : Color.FromKnownColor(KnownColor.ControlLight);

            float width = _handle.Selected ? 1.0f : 1.0f;
            g.FillPolygon(new SolidBrush(colorFill), points);
            g.DrawPolygon(new Pen(color, width), points);
            g.ResetTransform();

            r.Offset(x, BAND_HEIGHT + 2);
            _handle.Rectangle = r;
        }
        #endregion
        
        #region Position
        /// <summary>
        /// Returns position of the handle based upon the value
        /// </summary>
        private int PositionFromValue(byte value)
        {
            float width = BandWidth;
            float position = (float)BAND_OFFSET + (float)value / 255.0f * width;
            return (int)position;
        }


        public int BandWidth
        {
            get { return this.ClientRectangle.Width - textBox1.Width - 2*BAND_OFFSET - 10; }
        }

        /// <summary>
        /// Returns the value of transparency based upon position of the handle
        /// </summary>
        private byte ValueFromPosition(int position)
        {
            int bandWidth = BandWidth;
            if (position < BAND_OFFSET) position = BAND_OFFSET;
            if (position > bandWidth + BAND_OFFSET) position = bandWidth + BAND_OFFSET;
            return (byte)((float)(position - BAND_OFFSET) / (float)(bandWidth) * 255.0f);
        }
        #endregion

        #region Dragging
        /// <summary>
        /// Start the dragging operation in case user has clicked a handle
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                RectangleF rect = _handle.Rectangle;

                if (e.X >= rect.X && e.X <= rect.X + rect.Width &&
                    e.Y >= rect.Y && e.Y <= rect.Y + rect.Height)
                {
                    _draggingIsPerformed = true;
                    _draggingStart = e.X;
                }
            }
        }

        /// <summary>
        /// Hightlights the handles
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                // changing position
                if (_draggingIsPerformed)
                {
                    if (_draggingStart != e.X)
                    {
                        _value = ValueFromPosition(_handle.Position + e.X - _draggingStart);
                        textBox1.Text = _value.ToString();
                        this.Invalidate_(true);
                    }
                }
                else
                {
                    // just highligting the handle
                    RectangleF rect = _handle.Rectangle;
                    bool newState = (e.X >= rect.X && e.X <= rect.X + rect.Width &&
                                     e.Y >= rect.Y && e.Y <= rect.Y + rect.Height);

                    if (newState != _handle.Selected)
                    {
                        _handle.Selected = newState;
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        DrawHandle(g);
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
                byte val = ValueFromPosition(_handle.Position + e.X - _draggingStart);
                _value = val;
                textBox1.Text = _value.ToString();
                _handle.Position = PositionFromValue(_value);
                this.Invalidate_(true);
                FireValueChanged(this, val);
            }
        }
        #endregion

        /// <summary>
        /// Invalidates control in case it's not locked
        /// </summary>
        private void Invalidate_(bool UpdateRectangleOnly)
        {
            if (UpdateRectangleOnly)
            {
                this.Invalidate(_updateRectangle);
            }
            else
            {
                this.Invalidate();
                
            }
        }

        /// <summary>
        /// Sets the max scale from the user input after Enter button was pressed
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1_Validated(null, null);
            }
        }

        /// <summary>
        /// Sets the scale from the user input
        /// </summary>
        private void textBox1_Validated(object sender, EventArgs e)
        {
            byte val;
            if (byte.TryParse(textBox1.Text, out val))
            {
                if (val != _value)
                {
                    _value = val;
                    _handle.Position = PositionFromValue(_value);
                    this.Invalidate_(true);
                    FireValueChanged(this, val);
                }
            }
            else
            {
                // reverting to the previous scale
                textBox1.Text = _value.ToString();
            }
        }
    }
}
