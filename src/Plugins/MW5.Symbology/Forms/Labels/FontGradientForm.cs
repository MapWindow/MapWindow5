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
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Controls;

namespace MW5.Plugins.Symbology.Forms.Labels
{
    public partial class FontGradientForm : Form
    {
        bool _fontGradient = true;
        ILabelStyle _labels = null;
        bool _noEvents = false;

        /// <summary>
        /// Initializes new instance of the FontGradientForm class
        /// </summary>
        /// <param name="labels">To set parameters for</param>
        public FontGradientForm(ILabelStyle labels, bool fontGradient)
        {
            InitializeComponent();

            _fontGradient = fontGradient;
            _labels = labels;
            
            _noEvents = true;
            icbFontGradient.ComboStyle = ImageComboStyle.LinearGradient;
            icbFontGradient.SelectedIndex = 0;

            this.Text = fontGradient ? "Font gradient" : "Frame gradient";
            _noEvents = false;

            Settings2GUI();
        }

        /// <summary>
        /// Setting values of labels to the control
        /// </summary>
        private void Settings2GUI()
        {
            _noEvents = true;
            
            
            int index = icbFontGradient.SelectedIndex;
            if (_fontGradient)
            {
                chkUseGradient.Checked = (_labels.FontGradientMode != LinearGradient.None);
                clpFont1.Color =  _labels.FontColor;
                clpFont2.Color =  _labels.FontColor2;
                icbFontGradient.Color1 =  _labels.FontColor;
                icbFontGradient.Color2 =  _labels.FontColor2;
                icbFontGradient.ComboStyle = ImageComboStyle.LinearGradient;
            }
            else
            {
                chkUseGradient.Checked = (_labels.FrameGradientMode != LinearGradient.None);
                clpFont1.Color =  _labels.FrameBackColor;
                clpFont2.Color =  _labels.FrameBackColor2;
                icbFontGradient.Color1 =  _labels.FrameBackColor;
                icbFontGradient.Color2 =  _labels.FrameBackColor2;
                icbFontGradient.ComboStyle = ImageComboStyle.LinearGradient;
            }
            icbFontGradient.SelectedIndex = index;

            RefreshControls();
            _noEvents = false;
        }

        /// <summary>
        /// Saveing values options to the charts class
        /// </summary>
        private void GUI2Settings(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            if (_fontGradient)
            {
                _labels.FontColor =  clpFont1.Color;
                _labels.FontColor2 =  clpFont2.Color;
                if (chkUseGradient.Checked)
                    _labels.FontGradientMode = (LinearGradient)icbFontGradient.SelectedIndex;
                else
                    _labels.FontGradientMode = LinearGradient.None;
            }
            else
            {
                _labels.FrameBackColor = clpFont1.Color;
                _labels.FrameBackColor2 =  clpFont2.Color;
                if (chkUseGradient.Checked)
                    _labels.FrameGradientMode = (LinearGradient)icbFontGradient.SelectedIndex;
                else
                    _labels.FrameGradientMode = LinearGradient.None;
            }


            Settings2GUI();
        }

        /// <summary>
        /// Updates the state of the controls
        /// </summary>
        private void RefreshControls()
        {
            clpFont1.Enabled = chkUseGradient.Checked;
            clpFont2.Enabled = chkUseGradient.Checked;
            icbFontGradient.Enabled = chkUseGradient.Checked;
        }

        /// <summary>
        /// Saves the chosen options
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            GUI2Settings(null, null);
        }

        /// <summary>
        /// Toggles the gradient
        /// </summary>
        private void chkUseGradient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGradient.Checked)
            {
                if (_fontGradient)
                    _labels.FontGradientMode = (LinearGradient)icbFontGradient.SelectedIndex;
                else
                    _labels.FontGradientMode = LinearGradient.None;
            }
            else
            {
                if (_fontGradient)
                    _labels.FrameGradientMode = (LinearGradient)icbFontGradient.SelectedIndex;
                else
                    _labels.FrameGradientMode = LinearGradient.None;
            }
            RefreshControls();
        }
    }
}
