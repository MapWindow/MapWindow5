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
using System.IO;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Symbology
{
    public partial class PointsForm : MapWindowForm
    {
        private static int _tabIndex;

        private readonly IMuteLegend _legend;
        private readonly IGeometryStyle _style;
        private bool _noEvents;
        private string _initState;

        #region Initialization

        /// <summary>
        /// Creates a new instance of PointsForm class
        /// </summary>
        public PointsForm(IMuteLegend legend, ILegendLayer layer, IGeometryStyle options, bool applyDisabled)
        {
            InitializeComponent();
            
            if (options == null || legend == null)
            {
                throw new Exception("PointsForm: Unexpected null parameter");
            }

            _legend = legend;

            // setting values to the controls
            _style = options;
            _initState = _style.Serialize();
            _noEvents = true;

            btnApply.Visible = !applyDisabled;

            clpFillColor.SelectedColorChanged += clpFillColor_SelectedColorChanged;
            cboIconCollection.SelectedIndexChanged += CboIconCollectionSelectedIndexChanged;
            cboFillType.SelectedIndexChanged += cboFillType_SelectedIndexChanged;

            icbPointShape.ComboStyle = ImageComboStyle.PointShape;
            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;
            icbHatchStyle.ComboStyle = ImageComboStyle.HatchStyle;

            pnlFillPicture.Parent = groupBox3;    // options
            pnlFillPicture.Top = pnlFillHatch.Top;
            pnlFillPicture.Left = pnlFillHatch.Left;

            pnlFillGradient.Parent = groupBox3;    // options
            pnlFillGradient.Top = pnlFillHatch.Top;
            pnlFillGradient.Left = pnlFillHatch.Left;

            cboFillType.Items.Clear();
            cboFillType.Items.Add("Solid");
            cboFillType.Items.Add("Hatch");
            cboFillType.Items.Add("Gradient");

            cboGradientType.Items.Clear();
            cboGradientType.Items.Add("Linear");
            cboGradientType.Items.Add("Retangular");
            cboGradientType.Items.Add("Circle");

            var marker = _style.Marker;

            // character control
            cboFontName.SelectedIndexChanged += cboFontName_SelectedIndexChanged;
            RefreshFontList(null, null);
            characterControl1.SelectedCharacterCode = (byte)marker.FontCharacter;

            // icon control
            RefreshIconCombo();

            chkScaleIcons.Checked = marker.IconScaleX != 1.0 || marker.IconScaleY != 1.0;

            //if (layer != null)
            //{
                //SymbologySettings settings = Globals.get_LayerSettings(m_layer.Handle);
                //if (settings != null)
                //{
                //    iconControl1.SelectedIndex = settings.IconIndex;
                //    chkScaleIcons.Checked = settings.ScaleIcons;
                //    string name = settings.IconCollection.ToLower();
                //    for (int i = 0; i < cboIconCollection.Items.Count; i++)
                //    {
                //        if (cboIconCollection.Items[i].ToString().ToLower() == name)
                //        {
                //            cboIconCollection.SelectedIndex = i;
                //            break;
                //        }
                //    }
                //}
            //}

            Options2Gui();
            _noEvents = false;

            // -----------------------------------------------------
            // adding event handlers
            // -----------------------------------------------------
            udRotation.ValueChanged += Gui2Options;
            udPointNumSides.ValueChanged += Gui2Options;
            udSideRatio.ValueChanged += Gui2Options;
            udSize.ValueChanged += Gui2Options;
            chkShowAllFonts.CheckedChanged += RefreshFontList;

            // line
            chkOutlineVisible.CheckedChanged += Gui2Options;
            icbLineType.SelectedIndexChanged += Gui2Options;
            icbLineWidth.SelectedIndexChanged += Gui2Options;
            clpOutline.SelectedColorChanged += clpOutline_SelectedColorChanged;
            
            chkFillVisible.CheckedChanged += Gui2Options;
            
            iconControl1.SelectionChanged += IconControl1SelectionChanged;
            chkScaleIcons.CheckedChanged += Gui2Options;

            // character
            characterControl1.SelectionChanged += characterControl1_SelectionChanged;
            symbolControl1.SelectionChanged += SymbolControl1SelectionChanged;

            // hatch
            icbHatchStyle.SelectedIndexChanged += Gui2Options;
            chkFillBgTransparent.CheckedChanged += Gui2Options;
            clpHatchBack.SelectedColorChanged += Gui2Options;

            // gradient
            clpGradient2.SelectedColorChanged += Gui2Options;
            udGradientRotation.ValueChanged += Gui2Options;
            cboGradientType.SelectedIndexChanged += Gui2Options;

            DrawPreview();

            tabControl1.SelectedIndex = _tabIndex;
        }
        #endregion

        #region ChangingFill

        /// <summary>
        /// Toggles fill type oprions
        /// </summary>
        void cboFillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFillGradient.Visible = false;
            pnlFillHatch.Visible = false;
            pnlFillPicture.Visible = false;
            lblNoOptions.Visible = false;

            var fill = _style.Fill;
            if (cboFillType.SelectedIndex == (int)FillType.Hatch)
            {
                pnlFillHatch.Visible = true;
                fill.Type = FillType.Hatch;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Gradient)
            {
                pnlFillGradient.Visible = true;
                fill.Type = FillType.Gradient;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Picture)
            {
                pnlFillPicture.Visible = true;
                fill.Type = FillType.Picture;
            }
            else
            {
                lblNoOptions.Visible = true;
                fill.Type = FillType.Solid;
            }

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            DrawPreview();
        }
        #endregion

        #region Icons
        /// <summary>
        /// Fills the image combo with the names of icons collectins (folders) 
        /// </summary>
        private void RefreshIconCombo()
        {
            cboIconCollection.Items.Clear();
            
            string path = Globals.GetIconsPath();
            if (!Directory.Exists(path))
            {
                cboIconCollection.Enabled = false;
                chkScaleIcons.Enabled = false;
                return;
            }

            string[] directories = Directory.GetDirectories(path);
            if (directories.Length <= 0)
            {
                // TODO: report error 
                return;
            }

            for (int i = 0; i < directories.Length; i++)
            {
                string[] files = Directory.GetFiles(directories[i]);
                    
                foreach(var file in files)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext == ".png")          //ext == ".bmp" || 
                    {
                        string name = directories[i].Substring(path.Length);
                        cboIconCollection.Items.Add(name);
                        break;
                    }
                }
                    
            }
            if (cboIconCollection.Items.Count <= 0)
            {
                cboIconCollection.Enabled = false;
                return;
            }
            
            foreach(var item in cboIconCollection.Items)
            {
                if (item.ToString().ToLower() == "standard")
                {
                    cboIconCollection.SelectedItem = item;
                    break;
                }
            }
            if (cboIconCollection.SelectedItem == null)
            {
                cboIconCollection.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Updates the preview with newly selected icon
        /// </summary>
        private void IconControl1SelectionChanged()
        {
            string filename = iconControl1.SelectedName;
            if (string.IsNullOrWhiteSpace(filename))
                return;
            
            var bmp = new Bitmap(filename);
            var clrTransparent = Color.White;

            var img = BitmapSource.Open(filename, true);
            {
                //img.LoadBuffer(50);

                img.TransparentColorFrom =  clrTransparent;
                img.TransparentColorTo =  clrTransparent;
                img.UseTransparentColor = true;

                var marker = _style.Marker;
                marker.Type = MarkerType.Bitmap;
                marker.Icon = img;

                UpdatePrictureScale();

                DrawPreview();
            }
            
            if (!_noEvents)
                btnApply.Enabled = true;
        }

        private void UpdatePrictureScale()
        {
            var marker = _style.Marker;
            if (chkScaleIcons.Checked && marker.Icon != null)
            {
                var img = marker.Icon;
                int size = Math.Max(img.Width, img.Height);
                if (img.Width > img.Height)
                {
                    marker.IconScaleX = (double)udSize.Value / size;
                    marker.IconScaleY = marker.IconScaleX;
                }
                else
                {
                    marker.IconScaleY = (double)udSize.Value / size;
                    marker.IconScaleX = marker.IconScaleY;
                }
            }
            else
            {
                marker.IconScaleX = marker.IconScaleY = 1.0;
            }
        }

        /// <summary>
        /// Building new list of icons from the changed path
        /// </summary>
        private void CboIconCollectionSelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Globals.GetIconsPath();
            path += cboIconCollection.Text;

            if (Directory.Exists(path))
            {
                iconControl1.CellWidth = 32;
                iconControl1.CellHeight = 32;

                // let's try to determine real size by first file
                try
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (string name in files)
                    {
                        string ext = Path.GetExtension(name);
                        if (ext == ".png")          //ext == ".bmp" || 
                        {
                            Bitmap bmp = new Bitmap(name);
                            if (bmp.Width <= 16 || bmp.Height <= 16)
                            {
                                // do nothing - use 32
                            }
                            else if (bmp.Width < 48 && bmp.Height < 48)
                            {
                                iconControl1.CellWidth = bmp.Height < bmp.Width ? bmp.Height + 16 : bmp.Width + 16;
                                iconControl1.CellHeight = iconControl1.CellWidth;
                            }
                            else
                            {
                                iconControl1.CellWidth = 48 + 16;
                                iconControl1.CellHeight = iconControl1.CellWidth;
                            }
                            break;
                        }
                    }
                }
                catch {}
            }
            
            
            iconControl1.FilePath = path;
            //lblCopyright.Text = "";

            //string filename = path + @"\copyright.txt";
            //if (File.Exists(filename))
            //{
            //    StreamReader reader = null;
            //    try
            //    {
            //        reader = new StreamReader(filename);
            //        lblCopyright.Text = reader.ReadLine();
            //    }
            //    finally
            //    {
            //        if (reader != null)
            //            reader.Close();
            //    }
            //}
        }
        #endregion

        #region FontCharacters
        /// <summary>
        /// Refreshes the list of fonts
        /// </summary>
        private void RefreshFontList(object sender, EventArgs e)
        {
            cboFontName.Items.Clear();
            if (!chkShowAllFonts.Checked)
            {
                foreach (FontFamily family in FontFamily.Families)
                {
                    string name = family.Name.ToLower();

                    if (name == "webdings" ||
                        name == "wingdings" ||
                        name == "wingdings 2" ||
                        name == "wingdings 3" ||
                        name == "times new roman")
                    {
                        cboFontName.Items.Add(family.Name);
                    }
                }
            }
            else
            {
                foreach (FontFamily family in FontFamily.Families)
                {
                    cboFontName.Items.Add(family.Name);
                }
            }

            string fontName = _style.Marker.FontName.ToLower();
            for (int i = 0; i < cboFontName.Items.Count; i++)
            {
                if (cboFontName.Items[i].ToString().ToLower() == fontName)
                {
                    cboFontName.SelectedIndex = i;
                    break;
                }
            }
            if (cboFontName.SelectedIndex == -1)
            {
                cboFontName.SelectedItem = "Arial";
            }
        }

        /// <summary>
        /// Changing the font in the font control
        /// </summary>
        private void cboFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
            characterControl1.SetFontName(cboFontName.Text);
            _style.Marker.FontName = cboFontName.Text;
            DrawPreview();
        }

        /// <summary>
        /// Updates the preview with the newly selected character
        /// </summary>
        void characterControl1_SelectionChanged()
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
            _style.Marker.Type = MarkerType.FontCharacter;
            _style.Marker.FontCharacter = Convert.ToChar(characterControl1.SelectedCharacterCode);
            DrawPreview();
        }
        #endregion

        #region Drawing
        /// <summary>
        /// Draws preview based on the chosen options
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents)
            {
                return;
            }

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            var rect = pctPreview.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);
            
            _style.DrawPoint(g, 0.0f, 0.0f, rect.Width, rect.Height,  BackColor);
            
            pctPreview.Image = bmp;
        }
        #endregion

        /// <summary>
        /// Changes the chosen point symbol
        /// </summary>
        private void SymbolControl1SelectionChanged()
        {
            var symbol = (VectorMarker)symbolControl1.SelectedIndex;
            _style.Marker.SetVectorMarker(symbol);
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            Options2Gui();
            DrawPreview();
        }

        #region Properties
        /// <summary>
        /// Sets the values entered by user to the class
        /// </summary>
        private void Gui2Options(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            var fill = _style.Fill;
            var marker = _style.Marker;

            marker.Size = (float)udSize.Value;

            UpdatePrictureScale();

            marker.Rotation = (double)udRotation.Value;

            fill.Color =  clpFillColor.Color;

            marker.VectorMarker = (VectorMarkerType)icbPointShape.SelectedIndex;
            marker.VectorSideCount = (int)udPointNumSides.Value;
            marker.VectorMarkerSideRatio = (float)udSideRatio.Value / 10;
        
            _style.Line.DashStyle = (DashStyle)icbLineType.SelectedIndex;
            _style.Line.Width = (float)icbLineWidth.SelectedIndex + 1;
            _style.Line.Visible = chkOutlineVisible.Checked;
            fill.Visible = chkFillVisible.Checked;
            fill.Type = (FillType)cboFillType.SelectedIndex;

            // hatch
            fill.HatchStyle = (HatchStyle)icbHatchStyle.SelectedIndex;
            fill.BgTransparent = chkFillBgTransparent.Checked;
            fill.BgColor =  clpHatchBack.Color;

            // gradient
            fill.GradientType = (GradientType)cboGradientType.SelectedIndex;
            fill.Color2 =  clpGradient2.Color;
            fill.Rotation = (double)udGradientRotation.Value;

            fill.AlphaTransparency = transparencyControl1.Value;
            _style.Line.AlphaTransparency = transparencyControl1.Value;

            if (!_noEvents)
                btnApply.Enabled = true;

            DrawPreview();
        }

        /// <summary>
        /// Loads the values of the class instance to the controls
        /// </summary>
        private void Options2Gui()
        {
            _noEvents = true;

            var marker = _style.Marker;
            udSize.SetValue(marker.Size);
            udRotation.SetValue(marker.Rotation);
            clpFillColor.Color =  _style.Fill.Color;

            // point
            icbPointShape.SelectedIndex = (int)marker.Type;
            udPointNumSides.SetValue(marker.VectorSideCount);
            udSideRatio.SetValue(marker.VectorMarkerSideRatio * 10.0);
            
            // options
            icbLineType.SelectedIndex = (int)_style.Line.DashStyle;
            icbLineWidth.SelectedIndex = (int)_style.Line.Width - 1;
            cboFillType.SelectedIndex = (int)_style.Fill.Type;
            chkOutlineVisible.Checked = _style.Line.Visible;
            clpOutline.Color =  _style.Line.Color;
            chkFillVisible.Checked = _style.Fill.Visible;
            
            // hatch
            icbHatchStyle.SelectedIndex = (int)_style.Fill.HatchStyle;
            chkFillBgTransparent.Checked = _style.Fill.BgTransparent;
            clpHatchBack.Color =  _style.Fill.BgColor;

            // gradient
            cboGradientType.SelectedIndex = (int)_style.Fill.GradientType;
            clpGradient2.Color =  _style.Fill.Color2;
            udGradientRotation.Value = (decimal)_style.Fill.Rotation;

            transparencyControl1.Value = _style.Fill.AlphaTransparency;

            _noEvents = false;
        }
        #endregion

        #region Colors
        /// <summary>
        /// Updates all the controls with the selected fill color
        /// </summary>
        private void clpFillColor_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.Fill.Color =  clpFillColor.Color;
            symbolControl1.ForeColor = clpFillColor.Color;
            characterControl1.ForeColor = clpFillColor.Color;
            icbPointShape.Color1 = clpFillColor.Color;
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
            DrawPreview();
        }

        /// <summary>
        ///  Updates all the control with the selected outline color
        /// </summary>
        void clpOutline_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.Line.Color =  clpOutline.Color;
            
            // TODO: implement
            //symbolControl1.ForeColor = clpFillColor.Color;
            //characterControl1.ForeColor = clpFillColor.Color;
            //icbPointShape.Color1 = clpFillColor.Color;

            if (!_noEvents)
                btnApply.Enabled = true;
            DrawPreview();
        }
        #endregion

        /// <summary>
        /// Saves the selected page
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            _tabIndex = tabControl1.SelectedIndex;

            SymbologySettings settings = null; //Globals.get_LayerSettings(_layer.Handle, _mapWin);

            if (settings != null)
            {
                settings.IconCollection = cboIconCollection.Text;
                settings.ScaleIcons = chkScaleIcons.Checked;
                settings.IconIndex = iconControl1.SelectedIndex;
                //Globals.SaveLayerSettings(_layer.Handle, settings, _mapWin);
            }

            if (_style.Serialize() != _initState)
            {
                //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }
        }

        /// <summary>
        /// Changes the transparency
        /// </summary>
        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Gui2Options(null, null);
        }

        /// <summary>
        /// Saves options and redraws map without closing the form
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
            _legend.Redraw(LegendRedraw.LegendAndMap);
            btnApply.Enabled = false;
            _initState = _style.Serialize();
        }

        /// <summary>
        /// Reverts changes and closes the form
        /// </summary>
        private void frmPoints_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                _tabIndex = tabControl1.SelectedIndex;
                _style.Deserialize(_initState);
            }
        }
    }
}
