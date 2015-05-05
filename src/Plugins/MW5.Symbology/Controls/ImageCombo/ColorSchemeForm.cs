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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.UI;
using MW5.UI.Controls;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    public partial class ColorSchemeForm : MapWindowForm
    {
        private CheckBox[] _checkboxes;
        private Office2007ColorPicker[] _colopickers;
        private NumericUpDown[] _updowns;
        private  ColorBlend _blend;
        private bool _noEvents;

        /// <summary>
        /// Initializes a new instance of the frmColorScheme class
        /// </summary>
        public ColorSchemeForm(ColorBlend blend)
        {
            InitializeComponent();
            _blend = blend;

            // initializing controls for editing the chosen color scheme
            _checkboxes = new CheckBox[7];
            _colopickers = new Office2007ColorPicker[7];
            _updowns = new NumericUpDown[7];

            for (int i = 0; i < 7; i++)
            {
                _checkboxes[i] = new CheckBox();
                _checkboxes[i].Parent = this;
                _checkboxes[i].Left = 25;
                _checkboxes[i].Top = 20 + i * (_checkboxes[i].Height + 13);
                _checkboxes[i].Text = "Color " + (i + 1).ToString();
                _checkboxes[i].Width = 65;
                _checkboxes[i].TextAlign = ContentAlignment.MiddleLeft;
                _checkboxes[i].CheckedChanged += new EventHandler(this.DoUpdate);

                _colopickers[i] = new Office2007ColorPicker();
                _colopickers[i].Parent = this;
                _colopickers[i].Left = 90;
                _colopickers[i].Top = 20 + i * (_checkboxes[i].Height + 13);
                _colopickers[i].Width = 70;
                _colopickers[i].SelectedColorChanged += new EventHandler(this.DoUpdate);

                _updowns[i] = new NumericUpDown();
                _updowns[i].Parent = this;
                _updowns[i].Left = 180;
                _updowns[i].Top = 20 + i * (_checkboxes[i].Height + 13);
                _updowns[i].Width = 50;
                _updowns[i].Enabled = false;
                _updowns[i].Visible = false;
                //_updowns[i].ValueChanged += new EventHandler(this.DoUpdate);
            }

            Blend2GUI(blend);
            RefreshControls();
        }

        public ColorBlend Blend
        {
            get { return _blend; }
        }

        /// <summary>
        ///  Performs the necessary updates in case edits were made to the color scheme
        /// </summary>
        private void DoUpdate(object sender, EventArgs e)
        {
            if (_noEvents) return;
            _blend = GUI2Blend();
            DrawColorBlend(_blend);
            RefreshControls();
        }

        /// <summary>
        /// Rereshes the state of the controls
        /// </summary>
        private void RefreshControls()
        {
            for (int i = 0; i < _checkboxes.Length; i++)
                _checkboxes[i].Enabled = true;

            // updating the state of colopickers counting the active breaks
            int count = 0;
            for (int i = 0; i < _checkboxes.Length; i++)
            {
                _colopickers[i].Enabled = _checkboxes[i].Checked;
                if (_checkboxes[i].Checked)
                    count++;
            }
            
            // if there are only 2 active breaks present, it won't be possible to turn off them
            if (count == 2)
            {
                for (int i = 0; i < _checkboxes.Length; i++)
                {
                    if (_checkboxes[i].Checked)
                        _checkboxes[i].Enabled = false;
                }
            }

            // comparing new blend with initial for chnages
            //bool changesMade = !BlendsAreEqual(_initBlend, _blend);
        }

        /// <summary>
        /// Sets the values of controls according to color breaks
        /// </summary>
        /// <param name="blend">Color blend to take properties from</param>
        private void Blend2GUI(ColorBlend blend)
        {
            if (blend == null) return;

            _noEvents = true;
            for (int i = 0; i < _colopickers.Length; i++)
            {
                _colopickers[i].Enabled = false;
                //_updowns[i].Enabled = false;
                _checkboxes[i].Enabled = false;
            }

            for (int i = 0; i < blend.Colors.Length; i++)
            {
                _colopickers[i].Color = blend.Colors[i];
                //_updowns[i].Value = (decimal)blend.Positions[i] * 100;
                _checkboxes[i].Checked = true;

                _colopickers[i].Enabled = true;
                //_updowns[i].Enabled = true;
                _checkboxes[i].Enabled = true;
            }
            if (blend.Colors.Length < _checkboxes.Length)
                _checkboxes[blend.Colors.Length].Enabled = true;

            // drawing the gradient
            DrawColorBlend(blend);

            _noEvents = false;
        }

        /// <summary>
        /// Creates color blend based upon options selected in the GUI
        /// </summary>
        private ColorBlend GUI2Blend()
        {
            // how many colors are enabled            
            int count = 0;
            for (int i = 0; i < _checkboxes.Length; i++)
            {
                if (_checkboxes[i].Checked)
                    count++;
            }

            ColorBlend blend = new ColorBlend(count);
            int blendCount = 0;
            for (int i = 0; i < _colopickers.Length; i++)
            {
                if (_checkboxes[i].Checked)
                {
                    blend.Colors[blendCount] = _colopickers[i].Color;
                    blend.Positions[blendCount] = (float)blendCount / (count - 1);
                    blendCount++;
                }
            }
            return blend;
        }

        /// <summary>
        /// Checks if the 2 color blends are equal
        /// </summary>
        /// <returns>True if the 2 blends are equal and false otherwise</returns>
        //bool BlendsAreEqual(ColorBlend blend1, ColorBlend blend2)
        //{
        //    if (blend1 == null || blend2 == null) return false;

        //    if (blend1.Colors.Length != blend2.Colors.Length ||
        //        blend1.Positions.Length != blend2.Positions.Length)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < blend1.Colors.Length; i++)
        //        if (blend1.Colors[i] != blend2.Colors[i]) return false;

        //    for (int i = 0; i < blend1.Positions.Length; i++)
        //        if (blend1.Positions[i] != blend2.Positions[i]) return false;

        //    return true;
        //}

        /// <summary>
        /// Draws current color blend
        /// </summary>
        /// <param name="blend"></param>
        private void DrawColorBlend(ColorBlend blend)
        {
            if (lblPreview.Image != null)
                lblPreview.Image.Dispose();

            if (blend == null) return;

            Bitmap bmp = new Bitmap(lblPreview.ClientRectangle.Width, lblPreview.ClientRectangle.Height);

            LinearGradientBrush lgb = new LinearGradientBrush(lblPreview.ClientRectangle, Color.Transparent, Color.Transparent, 90.0f);
            lgb.InterpolationColors = blend;

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(lgb, lblPreview.ClientRectangle);
            lgb.Dispose();
            lblPreview.Image = bmp;
        }
    }
}
