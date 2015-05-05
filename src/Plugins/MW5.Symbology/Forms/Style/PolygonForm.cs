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
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI;
using MW5.UI.Enums;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms.Style
{
    public partial class PolygonForm : MapWindowForm
    {
        private static int _tabPage;

        private readonly IGeometryStyle _options;
        private readonly SymbologyMetadata _metadata;
        private readonly IMuteLegend _legend;
        private string _initState;
        private bool _noEvents;

        #region Initialization
        
        /// <summary>
        /// Creates a new instance of PolygonsForm class
        /// </summary>
        public PolygonForm(IMuteLegend legend, ILegendLayer layer, IGeometryStyle options, bool applyDisabled)
        {
            InitializeComponent();

            if (options == null || layer == null)
            {
                throw new Exception("PolygonsForm: unexpected null parameter");
            }
            
            _options = options;
            _metadata = SymbologyPlugin.Metadata(layer.Handle);
            _legend = legend;
            btnApply.Visible = !applyDisabled;

            _initState = options.Serialize();

            _noEvents = true;
            groupPicture.Parent = tabPage2;
            groupPicture.Top = groupGradient.Top;
            groupPicture.Left = groupGradient.Left;

            groupHatch.Parent = tabPage2;
            groupHatch.Top = groupGradient.Top;
            groupHatch.Left = groupGradient.Left;

            cboFillType.Items.Clear();
            cboFillType.Items.Add("Solid");
            cboFillType.Items.Add("Hatch");
            cboFillType.Items.Add("Gradient");
            cboFillType.Items.Add("Texture");

            cboGradientType.Items.Clear();
            cboGradientType.Items.Add("Linear");
            cboGradientType.Items.Add("Rectangular");
            cboGradientType.Items.Add("Circle");

            cboGradientBounds.Items.Clear();
            cboGradientBounds.Items.Add("Whole layer");
            cboGradientBounds.Items.Add("Per-shape");

            cboVerticesType.Items.Clear();
            cboVerticesType.Items.Add("Square");
            cboVerticesType.Items.Add("Circle");
            
            icbHatchStyle.ComboStyle = ImageComboStyle.HatchStyle;
            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            // loading icons
            string path = PathHelper.GetTexturesPath();
            if (System.IO.Directory.Exists(path))
            {
                iconControl1.FilePath = path;
                iconControl1.Textures = true;

                iconControl1.SelectedIndex = _metadata.IconIndex;
            }
            else
            {
                udScaleX.Enabled = false;
                udScaleY.Enabled = false;
            }

            _noEvents = false;

            cboFillType.SelectedIndexChanged += cboFillType_SelectedIndexChanged;

            Options2Ui();

            // -----------------------------------------------------
            // adding event handlers
            // -----------------------------------------------------
            // fill
            chkFillVisible.CheckedChanged += Ui2Options;
            clpFill.SelectedColorChanged += Ui2Options;

            // hatch
            icbHatchStyle.SelectedIndexChanged += Ui2Options;
            chkFillBgTransparent.CheckedChanged += Ui2Options;
            clpHatchBack.SelectedColorChanged += Ui2Options;

            // gradient
            clpGradient2.SelectedColorChanged += Ui2Options;
            udGradientRotation.ValueChanged += Ui2Options;
            cboGradientType.SelectedIndexChanged += Ui2Options;
            cboGradientBounds.SelectedIndexChanged += Ui2Options;

            // outline
            chkOutlineVisible.CheckedChanged += Ui2Options;
            icbLineType.SelectedIndexChanged += Ui2Options;
            icbLineWidth.SelectedIndexChanged += Ui2Options;
            clpOutline.SelectedColorChanged += Ui2Options;

            // vertices
            chkVerticesVisible.CheckedChanged += Ui2Options;
            cboVerticesType.SelectedIndexChanged += Ui2Options;
            clpVerticesColor.SelectedColorChanged += Ui2Options;
            chkVerticesFillVisible.CheckedChanged += Ui2Options;
            udVerticesSize.ValueChanged += Ui2Options;

            udScaleX.ValueChanged += Ui2Options;
            udScaleY.ValueChanged += Ui2Options;

            iconControl1.SelectionChanged += iconControl1_SelectionChanged;

            DrawPreview();

            tabControl1.SelectedIndex = _tabPage;
        }
        #endregion

        /// <summary>
        /// Changes the textures
        /// </summary>
        void iconControl1_SelectionChanged()
        {
            string filename = iconControl1.SelectedName;
            if (filename == string.Empty)
            {
                return;
            }

            var clrTransparent = GetTransparentColor(filename);

            var img = BitmapSource.Open(filename, true);
            {
                //img.LoadBuffer(50);

                img.TransparentColorFrom =  clrTransparent;
                img.TransparentColorTo =  clrTransparent;
                img.UseTransparentColor = true;

                _options.Marker.Icon = img;

                DrawPreview();
            }
        }

        private Color GetTransparentColor(string imageFilename)
        {
            var bmp = new Bitmap(imageFilename);
            var clrTransparent = Color.White;
            for (int i = 0; i < bmp.Width; i++)
            {
                int j;
                for (j = 0; j < bmp.Height; j++)
                {
                    var clr = bmp.GetPixel(i, j);
                    if (clr.A == 0)
                    {
                        clrTransparent = clr;
                        break;
                    }
                }
                if (j != bmp.Width)
                {
                    break;
                }
            }
            return clrTransparent;
        }

        #region OptionsExchange

        /// <summary>
        /// Sets the values entered by user to the class
        /// </summary>
        private void Ui2Options(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            // fill
            _options.Fill.Visible = chkFillVisible.Checked;
            _options.Fill.Type = (FillType)cboFillType.SelectedIndex;
            _options.Fill.Color =  clpFill.Color;

            // hatch
            _options.Fill.HatchStyle = (HatchStyle)icbHatchStyle.SelectedIndex;
            _options.Fill.BgTransparent = chkFillBgTransparent.Checked;
            _options.Fill.BgColor =  clpHatchBack.Color;

            // gradient
            _options.Fill.GradientType = (GradientType)cboGradientType.SelectedIndex;
            _options.Fill.Color2 =  clpGradient2.Color;
            _options.Fill.Rotation = (double)udGradientRotation.Value;
            _options.Fill.GradientBounds = (GradientBounds)cboGradientBounds.SelectedIndex;

            // texture
            _options.Marker.IconScaleX = (double)udScaleX.Value;
            _options.Marker.IconScaleY = (double)udScaleY.Value;

            // outline
            _options.Line.DashStyle = (DashStyle)icbLineType.SelectedIndex;
            _options.Line.Width = (float)icbLineWidth.SelectedIndex + 1;
            _options.Line.Visible = chkOutlineVisible.Checked;
            _options.Line.Color =  clpOutline.Color;

            // vertices
            _options.Vertices.Visible = chkVerticesVisible.Checked;
            _options.Vertices.FillVisible = chkVerticesFillVisible.Checked;
            _options.Vertices.Size = (int)udVerticesSize.Value;
            _options.Vertices.Color =  clpVerticesColor.Color;
            _options.Vertices.VertexType = (VertexType)cboVerticesType.SelectedIndex;

            // transparency
            _options.Line.Transparency = transpOutline.Value;
            _options.Fill.Transparency = transpFill.Value;

            btnApply.Enabled = true;

            DrawPreview();
        }

        /// <summary>
        /// Loads the values of the class instance to the controls
        /// </summary>
        private void Options2Ui()
        {
            _noEvents = true;

            // options
            icbLineType.SelectedIndex = (int)_options.Line.DashStyle;
            icbLineWidth.SelectedIndex = (int)_options.Line.Width - 1;
            cboFillType.SelectedIndex = (int)_options.Fill.Type;
            chkOutlineVisible.Checked = _options.Line.Visible;
            clpOutline.Color =  _options.Line.Color;
            chkFillVisible.Checked = _options.Fill.Visible;

            // hatch
            icbHatchStyle.SelectedIndex = (int)_options.Fill.HatchStyle;
            chkFillBgTransparent.Checked = _options.Fill.BgTransparent;
            clpHatchBack.Color =  _options.Fill.BgColor;

            // gradient
            cboGradientType.SelectedIndex = (int)_options.Fill.GradientType;
            clpGradient2.Color =  _options.Fill.Color2;
            udGradientRotation.Value = (decimal)_options.Fill.Rotation;

            clpFill.Color =  _options.Fill.Color;
            cboGradientBounds.SelectedIndex = (int)_options.Fill.GradientBounds;
            chkOutlineVisible.Checked = _options.Line.Visible;

            // texture
            udScaleX.SetValue(_options.Marker.IconScaleX);
            udScaleY.SetValue(_options.Marker.IconScaleY);

            // vertices
            chkVerticesVisible.Checked = _options.Vertices.Visible;
            chkVerticesFillVisible.Checked = _options.Vertices.FillVisible;
            udVerticesSize.SetValue(_options.Vertices.Size);
            clpVerticesColor.Color =  _options.Vertices.Color;
            cboVerticesType.SelectedIndex = (int)_options.Vertices.VertexType;

            transpFill.Value = _options.Fill.Transparency;
            transpOutline.Value = _options.Line.Transparency;

            _noEvents = false;
        }
        #endregion

        #region ChangingFill
        /// <summary>
        /// Changes available fill options
        /// </summary>
        void cboFillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupHatch.Visible = false;
            groupPicture.Visible = false;
            groupGradient.Visible = false;
            pnlFillPicture.Visible = false;
            clpFill.Visible = true;
            label6.Visible = true;
            
            if (cboFillType.SelectedIndex == (int)FillType.Hatch)
            {
                groupHatch.Visible = true;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Gradient)
            {
                groupGradient.Visible = true;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Picture)
            {
                groupPicture.Visible = true;
                pnlFillPicture.Visible = true;
                clpFill.Visible = false;
                label6.Visible = false;
            }
            
            if (cboFillType.SelectedIndex >= 0)
            {
                _options.Fill.Type = (FillType)cboFillType.SelectedIndex;
            }

            if (!_noEvents)
                btnApply.Enabled = true;
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
            _options.DrawRectangle(g, 40.0f, 40.0f, rect.Width - 80, rect.Height - 80, true, rect.Width, rect.Height, BackColor);
            pctPreview.Image = bmp;
        }
        #endregion

        /// <summary>
        /// Saves the window state
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_options.Serialize() != _initState)
            {
                //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }

            //m_layer.SymbologySettings.IconIndex = iconControl1.SelectedIndex;
            _tabPage = tabControl1.SelectedIndex;
        }

        /// <summary>
        /// Handles the changes of the transparency by user
        /// </summary>
        private void transpOutline_ValueChanged(object sender, byte value)
        {
            Ui2Options(sender, null);
        }

        /// <summary>
        /// Applies the changes and updates the map
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _legend.Map.Redraw();
            _legend.Redraw();
            //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
            _initState = _options.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// Reverts the changes if cancel was hit
        /// </summary>
        private void frmPolygons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                _tabPage = tabControl1.SelectedIndex;
                _options.Deserialize(_initState);
            }
        }

        /// <summary>
        /// Allows to apply newly selected texture
        /// </summary>
        private void iconControl1_SelectionChanged_1()
        {
            if (_noEvents)
            {
                return;
            }
            btnApply.Enabled = true;
        }
    }
}
