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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Utilities
{
    /// <summary>
    /// A class which provide GUI for modifying list of color schemes
    /// </summary>
    public partial class ColorSchemesForm : MapWindowForm
    {
        private readonly List<ColorBlend> _schemes;
        private readonly ColorSchemeCollection _colorSchemes;
        private readonly bool _noEvents;
        
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the frmColorSchemes class
        /// </summary>
        internal ColorSchemesForm(ColorSchemeCollection colorSchemes)
        {
            if (colorSchemes == null) throw new ArgumentNullException("colorSchemes");
            InitializeComponent();
            
            _colorSchemes = colorSchemes;
            _schemes = colorSchemes.List;

            if (_colorSchemes == null)
            {
                throw new Exception("frmColorSchemes: no reference to the color schemes was provided.");
            }

            // adding schemes
            listBox1.Items.Clear();

            int index = (colorSchemes.Type == ColorSchemeType.Default) ? 1 : 0;
            for (int i = index; i < _schemes.Count; i++)
            {
                ColorBlend blend = _schemes[i] as ColorBlend;
                if (blend != null)
                    listBox1.Items.Add(blend);
            }
            
            if (listBox1.Items.Count == 0)
            {
                // adding color scheme, as there can be none in the list
                ColorBlend blend = new ColorBlend(2);
                blend.Colors[0] = Color.White; blend.Positions[0] = 0.0f;
                blend.Colors[1] = Color.Black;  blend.Positions[1] = 1.0f;
                 
                listBox1.Items.Add(blend);
            }
            _noEvents = true;

            // choosing the first color scheme for editing
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                DrawColorBlend(listBox1.SelectedItem as ColorBlend);
            }

            RefreshControls();
            _noEvents = false;
        }
        #endregion

        /// <summary>
        /// Displaying the chosen color on the left
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            var blend = (listBox1.SelectedItem as ColorBlend);
            if (blend != null)
            {
                DrawColorBlend(blend);
            }
            RefreshControls();
        }

        /// <summary>
        ///  Returns a copy of the color blend object
        /// </summary>
        private ColorBlend CloneColorBlend(ColorBlend blend)
        {
            if (blend == null)
            {
                return null;
            }

            var newBlend = new ColorBlend(blend.Colors.Length);
            for (int i = 0; i < blend.Colors.Length; i++)
            {
                newBlend.Colors[i] = blend.Colors[i];
                newBlend.Positions[i] = blend.Positions[i];
            }
            return newBlend;
        }

        /// <summary>
        /// Sets the state of buttons depeding on list size and selected index
        /// </summary>
        private void RefreshControls()
        {
            btnRemove.Enabled = (listBox1.Items.Count > 1); // the last color scheme can't be removed
            btnMoveUp.Enabled = (listBox1.SelectedIndex > 0);
            btnMoveDown.Enabled = (listBox1.SelectedIndex >= -1 && listBox1.SelectedIndex < listBox1.Items.Count - 1);
        }

        #region Drawing
        /// <summary>
        /// Draws the item of the listbox, color scheme in this case
        /// </summary>
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ColorBlend blend = (ColorBlend)listBox1.Items[e.Index];
            
            if (blend != null)
            {
                if (this.Enabled)
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
                else
                    e.DrawBackground();


                Rectangle r = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, e.Bounds.Width - 10, e.Bounds.Height - 4);
                LinearGradientBrush lgb = new LinearGradientBrush(r, Color.Transparent, Color.Transparent, 0.0f);

                lgb.InterpolationColors = blend;
                e.Graphics.FillRectangle(lgb, r);
                lgb.Dispose();

                // drawing selection
                if (((e.State & DrawItemState.Selected) != 0) && ((e.State & DrawItemState.ComboBoxEdit) == 0))
                {
                    Pen pen = new Pen(Color.Black);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawRectangle(pen, 0, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
                }
            }
        }

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
        #endregion

        #region Buttons
        /// <summary>
        /// Removes the selected color scheme
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SymbologyPlugin.Msg.Ask("Do you want to delete the selected color scheme?"))
            {
                if (listBox1.Items.Count > 1)
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                    {
                        int index = listBox1.SelectedIndex;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        listBox1.SelectedIndex = index;
                    }
                    else
                    {
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                }
            }
            RefreshControls();
        }

        /// <summary>
        /// Opens forms for editing the selected color scheme
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ColorBlend blend = (listBox1.SelectedItem as ColorBlend);
            if (blend == null) return;
            blend = CloneColorBlend(blend);
            
            ColorSchemeForm form = new ColorSchemeForm(blend);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items[listBox1.SelectedIndex] = form.Blend;
                listBox1.Refresh();
            }
            form.Dispose();
            RefreshControls();
        }

        /// <summary>
        /// Adds the new color scheme to the list, and opens editing form to start it's editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ColorBlend blend = new ColorBlend(2);
            blend.Colors[0] = Color.White;
            blend.Colors[1] = Color.Black;

            blend.Positions[0] = 0.0f;
            blend.Positions[1] = 1.0f;

            ColorSchemeForm form = new ColorSchemeForm(blend);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(form.Blend);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                DrawColorBlend(listBox1.SelectedItem as ColorBlend);
            }
            form.Dispose();
            
            RefreshControls();
        }

        /// <summary>
        /// Moves the selected scheme to the beginning of the list
        /// </summary>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            if (listBox1.SelectedIndex == 0) return;

            int index = listBox1.SelectedIndex;
            object obj = listBox1.SelectedItem;
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.Items.Insert(index - 1, obj);
            listBox1.SelectedIndex = index - 1;
            RefreshControls();
        }

        /// <summary>
        /// Moves the selected scheme to the bottom of the list
        /// </summary>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1) return;

            int index = listBox1.SelectedIndex;
            object obj = listBox1.SelectedItem;
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.Items.Insert(index + 1, obj);
            listBox1.SelectedIndex = index + 1;
            RefreshControls();
        }

        /// <summary>
        /// Serializes the list of color schemes to XML file
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ColorBlend blend = (ColorBlend)_schemes[0];
            Color clr = blend.Colors[0];
            _schemes.Clear();

            // dummy color scheme for shapefile
            if (_colorSchemes.Type == ColorSchemeType.Default)
            {
                blend = new ColorBlend(2);
                blend.Colors[0] = clr; blend.Positions[0] = 0.0f;
                blend.Colors[1] = clr; blend.Positions[1] = 1.0f;
                _schemes.Add(blend);
            }

            //int index = (_colorSchemes.Type == ColorSchemeType.Layer) ? 1 : 0;
            int index = 0;
            for (int i = index; i < listBox1.Items.Count; i++)
            {
                blend = (ColorBlend)listBox1.Items[i];
                if (blend != null)
                {
                    _schemes.Add(blend);
                }
            }

            // saving schemes
            //_colorSchemes.save Serialize2Xml();
        }
        #endregion

    }
}
