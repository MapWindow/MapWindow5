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
using System.Linq;
using System.Windows.Forms;
using MW5.UI;
using MW5.UI.Controls;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    public partial class ColorSchemeForm : MapWindowForm
    {
        private readonly CheckBox[] _checkboxes;
        private readonly Office2007ColorPicker[] _colopickers;
        private  ColorBlend _blend;
        private bool _noEvents;

        /// <summary>
        /// Initializes a new instance of the frmColorScheme class
        /// </summary>
        public ColorSchemeForm(ColorBlend blend)
        {
            InitializeComponent();
            _blend = blend;

            _checkboxes = new CheckBox[7];
            _colopickers = new Office2007ColorPicker[7];

            Initialize();

            Blend2Gui(blend);
            RefreshControls();
        }

        private void Initialize()
        {
            var updowns = new NumericUpDown[7];

            for (int i = 0; i < 7; i++)
            {
                _checkboxes[i] = new CheckBox { Parent = this, Left = 25 };
                _checkboxes[i].Top = 20 + i * (_checkboxes[i].Height + 13);
                _checkboxes[i].Text = "Color " + (i + 1);
                _checkboxes[i].Width = 65;
                _checkboxes[i].TextAlign = ContentAlignment.MiddleLeft;
                _checkboxes[i].CheckedChanged += DoUpdate;

                _colopickers[i] = new Office2007ColorPicker
                {
                    Parent = this,
                    Left = 90,
                    Top = 20 + i * (_checkboxes[i].Height + 13),
                    Width = 70
                };
                _colopickers[i].SelectedColorChanged += DoUpdate;

                updowns[i] = new NumericUpDown
                {
                    Parent = this,
                    Left = 180,
                    Top = 20 + i * (_checkboxes[i].Height + 13),
                    Width = 50,
                    Enabled = false,
                    Visible = false
                };
            }
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

            _blend = Gui2Blend();

            DrawColorBlend(_blend);

            RefreshControls();
        }

        /// <summary>
        /// Rereshes the state of the controls
        /// </summary>
        private void RefreshControls()
        {
            foreach (CheckBox t in _checkboxes)
            {
                t.Enabled = true;
            }

            // updating the state of colopickers counting the active breaks
            int count = 0;
            for (int i = 0; i < _checkboxes.Length; i++)
            {
                _colopickers[i].Enabled = _checkboxes[i].Checked;
                if (_checkboxes[i].Checked)
                    count++;
            }
            
            if (count != 2) return;

            // if there are only 2 active breaks present, it won't be possible to turn them off
            foreach (CheckBox t in _checkboxes)
            {
                if (t.Checked)
                {
                    t.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Sets the values of controls according to color breaks
        /// </summary>
        /// <param name="blend">Color blend to take properties from</param>
        private void Blend2Gui(ColorBlend blend)
        {
            if (blend == null) return;

            _noEvents = true;
            for (int i = 0; i < _colopickers.Length; i++)
            {
                _colopickers[i].Enabled = false;
                _checkboxes[i].Enabled = false;
            }

            for (int i = 0; i < blend.Colors.Length; i++)
            {
                _colopickers[i].Color = blend.Colors[i];
                _checkboxes[i].Checked = true;

                _colopickers[i].Enabled = true;
                _checkboxes[i].Enabled = true;
            }

            if (blend.Colors.Length < _checkboxes.Length)
            {
                _checkboxes[blend.Colors.Length].Enabled = true;
            }

            // drawing the gradient
            DrawColorBlend(blend);

            _noEvents = false;
        }

        /// <summary>
        /// Creates color blend based upon options selected in the GUI
        /// </summary>
        private ColorBlend Gui2Blend()
        {
            int count = _checkboxes.Count(t => t.Checked);

            var blend = new ColorBlend(count);
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
        /// Draws current color blend
        /// </summary>
        private void DrawColorBlend(ColorBlend blend)
        {
            if (lblPreview.Image != null)
                lblPreview.Image.Dispose();

            if (blend == null) return;

            var bmp = new Bitmap(lblPreview.ClientRectangle.Width, lblPreview.ClientRectangle.Height);

            var lgb = new LinearGradientBrush(lblPreview.ClientRectangle, Color.Transparent,
                Color.Transparent, 90.0f)
            {
                InterpolationColors = blend
            };

            var g = Graphics.FromImage(bmp);
            g.FillRectangle(lgb, lblPreview.ClientRectangle);
            lgb.Dispose();
            lblPreview.Image = bmp;
        }

        private void ColorSchemeForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}
