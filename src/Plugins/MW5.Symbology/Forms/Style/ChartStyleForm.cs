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
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Charts
{
    public partial class ChartStyleForm : MapWindowForm
    {
        private static int _selectedTab = 0;

        private readonly IFeatureSet _shapefile;
        private readonly DiagramsLayer _charts;
        private readonly int _handle;
        private readonly IAppContext _context;
        private readonly ILayer _layer;

        private bool _noEvents;
        private string _initState;

        /// <summary>
        /// Initializes a new instance of the ChartStyleForm class
        /// </summary>
        public ChartStyleForm(IAppContext context, ILayer layer)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }

            InitializeComponent();
            _shapefile = layer.FeatureSet;
            _charts = _shapefile.Diagrams;
            _context = context;
            _layer = layer;
            _handle = layer.Handle;

            var mode = _charts.SavingMode;
            _charts.SavingMode = PersistenceType.None;
            _initState = _charts.Serialize();
            _charts.SavingMode = mode;

            _noEvents = true;

            panelPieChart.Top = panelBarChart.Top;
            panelPieChart.Left = panelBarChart.Left;

            foreach (FontFamily family in FontFamily.Families)
                cboFontName.Items.Add(family.Name);

            cboValuesStyle.Items.Clear();
            cboValuesStyle.Items.Add("Horizontal");
            cboValuesStyle.Items.Add("Vertical");

            cboChartVerticalPosition.Items.Clear();
            cboChartVerticalPosition.Items.Add("Above current layer");
            cboChartVerticalPosition.Items.Add("Above all layers");

            optBarCharts.Checked = _charts.Bars;
            optPieCharts.Checked = !_charts.Bars;

            // initializing for list of color schemes
            icbColors.ColorSchemeType = ColorSchemes.Charts;

            if (icbColors.Items.Count > 0)
            {
                icbColors.SelectedIndex = 0;
            }

            string[] scales = { "1", "10", "100", "1000", "5000", "10000", "25000", "50000", "100000", 
                                "250000", "500000", "1000000", "10000000" };
            cboMinScale.Items.Clear();
            cboMaxScale.Items.Clear();
            for (int i = 0; i < scales.Length; i++)
            {
                cboMinScale.Items.Add(scales[i]);
                cboMaxScale.Items.Add(scales[i]);
            }

            txtChartExpression.Text = _shapefile.Diagrams.VisibilityExpression;

            SetChartsType();

            InitFields();

            _noEvents = false;

            Settings2Ui();

            Draw();

            RefreshControlsState();

            tabControl1.SelectedIndex = _selectedTab;
        }
            
        /// <summary>
        /// Fills the fields tab
        /// </summary>
        private void InitFields()
        {
            // building list of fields
            listLeft.Items.Clear();
            listRight.Items.Clear();

            foreach (var fld in _shapefile.Table.Fields)
            {
                if (fld.Type != AttributeType.String)
                {
                    listLeft.Items.Add(fld.Name);
                }
            }

            // in case some fields have been chosen we must show them
            foreach (var fld in _shapefile.Diagrams.Fields)
            {
                string name = fld.Name.ToLower();
                for (int j = 0; j < listLeft.Items.Count; j++)
                {
                    if (listLeft.Items[j].ToString().ToLower() == name)
                    {
                        listRight.Items.Add(listLeft.Items[j]);
                        listLeft.Items.Remove(listLeft.Items[j]);
                        break;
                    }
                }
            }

            if (listLeft.Items.Count > 0)
            {
                listLeft.SelectedIndex = 0;
            }

            if (listRight.Items.Count > 0)
            {
                listRight.SelectedIndex = 0;
            }

            // Filling size and normalization fields
            cboChartSizeField.Items.Clear();
            cboChartNormalizationField.Items.Clear();

            cboChartSizeField.Items.Add("<None>");          // default
            cboChartNormalizationField.Items.Add("<None>");

            foreach(var fld in _shapefile.Table.Fields)
            {
                if (fld.Type != AttributeType.String)
                {
                    cboChartSizeField.Items.Add(fld.Name);
                    cboChartNormalizationField.Items.Add(fld.Name);
                }
            }

            if (cboChartSizeField.Items.Count >= 0)
                cboChartSizeField.SelectedIndex = 0;

            if (cboChartNormalizationField.Items.Count >= 0)
                cboChartNormalizationField.SelectedIndex = 0;

            // size field
            var charts = _shapefile.Diagrams;
            if (charts.SizeField >= 0 && charts.SizeField < cboChartSizeField.Items.Count - 1)  // first item is <none>
            {
                var fld = _shapefile.Table.Fields[charts.SizeField];
                if (fld != null)
                {
                    for (int i = 2; i < cboChartSizeField.Items.Count; i++)     // 2 = <none> and <sum of fields>
                    {
                        if (fld.Name == cboChartSizeField.Items[i].ToString())
                        {
                            cboChartSizeField.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                cboChartSizeField.SelectedIndex = 0;
            }

            // normalization field
            if (charts.NormalizationField >= 0 && charts.NormalizationField < cboChartNormalizationField.Items.Count - 1)  // first item is <none>
            {
                var fld = _shapefile.Table.Fields[charts.NormalizationField];
                if (fld != null)
                {
                    for (int i = 2; i < cboChartNormalizationField.Items.Count; i++)     // 2 = <none> and <sum of fields>
                    {
                        if (fld.Name == cboChartNormalizationField.Items[i].ToString())
                        {
                            cboChartNormalizationField.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                cboChartNormalizationField.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Activating pie charts
        /// </summary>
        private void optPieCharts_CheckedChanged(object sender, EventArgs e)
        {
            _charts.DiagramType = DiagramType.Pie;
            SetChartsType();
        }

        /// <summary>
        /// Activating bar charts
        /// </summary>
        private void optBarCharts_CheckedChanged(object sender, EventArgs e)
        {
            _charts.DiagramType = DiagramType.Bar;
            SetChartsType();
        }

        /// <summary>
        /// Chosing the type of charts
        /// </summary>
        private void SetChartsType()
        {
            if (_charts.Bars)
            {
                tabControl1.TabPages[1].Text = "Bar charts";
                panelBarChart.Visible = true;
                panelPieChart.Visible = false;
            }
            
            if (!_charts.Bars)
            {
                tabControl1.TabPages[1].Text = "Pie charts";
                panelPieChart.Visible = true;
                panelBarChart.Visible = false;
            }

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            RefreshControlsState();
            Draw();
        }

        /// <summary>
        /// Copies chart settings from the controls to the charts class
        /// </summary>
        private void Ui2Settings(object sender, EventArgs e)
        {
             if (_charts == null) 
                 return;

             if (_noEvents)
                 return;

            _charts.BarHeight = (int)udBarHeight.Value;
            _charts.BarWidth =  (int)udBarWidth.Value;
            _charts.PieRadius = (int)udPieRadius.Value;
            _charts.PieRadius2 = (int)udPieRadius2.Value;
            _charts.Thickness = (double)udThickness.Value;
            _charts.Tilt = (double)udTilt.Value;

            _charts.Use3DMode = chk3DMode.Checked;
            _charts.Visible = chkVisible.Checked;

            _charts.ValuesFontBold = chkFontBold.Checked;
            _charts.ValuesFontColor = clpFont.Color;

            _charts.ValuesFontItalic = chkFontItalic.Checked;
            _charts.ValuesFontName = cboFontName.Text;
            _charts.ValuesFontSize = (int)udFontSize.Value;
            
            _charts.ValuesFrameColor = clpFrame.Color;
            _charts.ValuesFrameVisible = chkValuesFrame.Checked;
            _charts.ValuesVisible = chkValuesVisible.Checked;
            _charts.ValuesStyle = (DiagramValuesStyle)cboValuesStyle.SelectedIndex;

            _charts.UseVariableRadius = (cboChartSizeField.SelectedIndex > 0);
            _charts.OffsetX = (int)udChartsOffsetX.Value;
            _charts.OffsetY = (int)udChartsOffsetY.Value;
            _charts.CollisionBuffer = (int)udChartsBuffer.Value;
            _charts.AlphaTransparency = transparencyControl1.Value;

            double val;
            if (double.TryParse(cboMinScale.Text, out val))
            {
                _shapefile.Diagrams.MinVisibleScale = val;
            }

            if (double.TryParse(cboMaxScale.Text, out val))
            {
                _shapefile.Diagrams.MaxVisibleScale = val;
            }
            _shapefile.Diagrams.DynamicVisibility = chkDynamicVisibility.Checked;

            // size field
            if (cboChartSizeField.SelectedIndex > 0)
            {
                string name = (string)cboChartSizeField.SelectedItem;

                int fieldCount = _shapefile.Table.Fields.Count;
                for (int i = 0; i < fieldCount; i++)
                {
                    var fld = _shapefile.Table.Fields[i];
                    if (fld != null)
                    {
                        if (fld.Name == name)
                        {
                            _charts.SizeField = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                _charts.SizeField = -1;
            }

            // normalization field
            if (cboChartNormalizationField.SelectedIndex > 0)
            {
                string name = (string)cboChartNormalizationField.SelectedItem;

                int fieldCount = _shapefile.Table.Fields.Count;
                for (int i = 0; i < fieldCount; i++)
                {
                    var fld = _shapefile.Table.Fields[i];
                    if (fld != null)
                    {
                        if (fld.Name == name)
                        {
                            _charts.NormalizationField = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                _charts.NormalizationField = -1;
            }

            btnApply.Enabled = true;

            RefreshControlsState();

            Draw();
        }

        /// <summary>
        /// Performs drawing
        /// </summary>
        private void Draw()
        {
            int width = pictureBox1.ClientRectangle.Width;
            int height = pictureBox1.ClientRectangle.Height;

            Bitmap bmp = new Bitmap(width, height,  System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            if (_charts.Visible)
            {
                _charts.DrawChart(g, (width - _charts.IconWidth) / 2, (height - _charts.IconHeight) / 2,  false, BackColor);
            }

            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// Copies settings from the charts class to the controls
        /// </summary>
        private void Settings2Ui()
        {
            if (_charts == null)
            {
                return;
            }

            _noEvents = true;
            udBarHeight.SetValue(_charts.BarHeight);
            udBarWidth.SetValue(_charts.BarWidth);
            
            cboChartVerticalPosition.SelectedIndex = (int)_charts.VerticalPosition;
            udChartsOffsetX.SetValue(_charts.OffsetX);
            udChartsOffsetY.SetValue(_charts.OffsetY);
            udChartsBuffer.SetValue(_charts.CollisionBuffer);

            udPieRadius.SetValue(_charts.PieRadius);
            udPieRadius2.SetValue(_charts.PieRadius2);
            udThickness.SetValue(_charts.Thickness);
            udTilt.SetValue(_charts.Tilt);
            chk3DMode.Checked = _charts.Use3DMode;
            chkVisible.Checked = _charts.Visible;

            chkFontBold.Checked = _charts.ValuesFontBold;
            clpFont.Color = _charts.ValuesFontColor;
            chkFontItalic.Checked = _charts.ValuesFontItalic;
            udFontSize.SetValue(_charts.ValuesFontSize);

            clpFrame.Color = _charts.ValuesFrameColor;
            chkValuesFrame.Checked = _charts.ValuesFrameVisible;
            chkValuesVisible.Checked = _charts.ValuesVisible;
            cboValuesStyle.SelectedIndex = (int)_charts.ValuesStyle;

            // looking for the font
            string name = _charts.ValuesFontName.ToLower();
            for (int i = 0; i < cboFontName.Items.Count; i++)
            {
                if (cboFontName.Items[i].ToString().ToLower() == name)
                {
                    cboFontName.SelectedIndex = i;
                }
            }
            if (cboFontName.SelectedIndex < 0)
                cboFontName.Text = "Arial";
               
            // transparency
            transparencyControl1.Value = _charts.AlphaTransparency;

            cboMinScale.Text = _shapefile.Diagrams.MinVisibleScale.ToString();
            cboMaxScale.Text = _shapefile.Diagrams.MaxVisibleScale.ToString();
            chkDynamicVisibility.Checked = _shapefile.Diagrams.DynamicVisibility;

            _noEvents = false;
       }
        
        /// <summary>
        /// Applies options, generates charts if needed
        /// </summary>
        private bool ApplyOptions()
        {
            if (_charts.Fields.Count == 0 )
            {
                if (_charts.Count == 0)
                {
                    SymbologyPlugin.Msg.Info("No fields were chosen. No charts will be displayed.");
                    return false;
                }

                if (SymbologyPlugin.Msg.Ask("No fields were chosen. Do you want to remove all charts?"))
                {
                    _charts.Clear();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // there is no charts, start generation
                if (_shapefile.PointOrMultiPoint)
                {
                    // start generation, no need to prompt the user for position
                    Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        _shapefile.Diagrams.Generate(LabelPosition.Centroid);
                    }
                    finally
                    {
                        Enabled = true;
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    // prompting user for charts position
                    using (var form = new AddChartsForm(_shapefile))
                    {
                        if (form.ShowDialog() != DialogResult.OK)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Saves the settings
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ApplyOptions())
            {
                return;
            }

           _selectedTab = tabControl1.SelectedIndex;

           if (_charts.Serialize() != _initState)
           {
               _context.Legend.Redraw(LegendRedraw.LegendAndMap);
               _context.Project.SetModified();
           }

           // saves options for default loading behavior
           LayerSettingsService.SaveLayerOptions(_handle);

           DialogResult = DialogResult.OK;
       }

        /// <summary>
        /// Updating colors of the charts
        /// </summary>
        private void icbColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            btnApply.Enabled = true;
            UpdateFieldColors();

            // updating preview
            Draw();
        }

        private void UpdateFieldColors()
        {
            List<ColorBlend> schemes = icbColors.ColorSchemes.List;
            if (schemes != null && icbColors.SelectedIndex >= 0)
            {
                var blend = schemes[icbColors.SelectedIndex];
                var scheme = blend.ToColorScheme();
                if (scheme != null)
                {
                    var fields = _charts.Fields;
                    for (int i = 0; i < fields.Count; i++)
                    {
                        var field = fields[i];
                        double value = i / (double)(fields.Count - 1);
                        field.Color = scheme.GetGraduatedColor(value);
                    }
                }
                
            }
        }
        
        /// <summary>
        /// Updates the enabled state of the controls
        /// </summary>
        private void RefreshControlsState()
        {
            cboValuesStyle.Enabled = chkValuesVisible.Checked && (_charts.Bars);
            groupBox4.Enabled = chkValuesVisible.Checked;
            groupBox5.Enabled = chkValuesVisible.Checked;

            udThickness.Enabled = chk3DMode.Checked;
            udTilt.Enabled = chk3DMode.Checked;

            cboChartSizeField.Enabled = _shapefile.Diagrams.DiagramType == DiagramType.Pie;

            cboMinScale.Enabled = chkDynamicVisibility.Checked;
            cboMaxScale.Enabled = chkDynamicVisibility.Checked;

            bool haveFields = _charts.Fields.Any();
            groupBox4.Enabled = haveFields;
            groupBox5.Enabled = haveFields;
            groupBox6.Enabled = haveFields;
            groupBox7.Enabled = haveFields;
            groupBox10.Enabled = haveFields;
            chkValuesVisible.Enabled = haveFields;
            cboValuesStyle.Enabled = haveFields;
            label10.Enabled = haveFields;
            icbColors.Enabled = haveFields;
            label1.Enabled = haveFields;;
            groupboxChartsOffset.Enabled = haveFields;
            
            groupBox9.Enabled = haveFields;
            groupBox11.Enabled = haveFields;
            groupBox2.Enabled = haveFields;
            groupBox3.Enabled = haveFields;
            groupBox8.Enabled = haveFields;
            groupBox13.Enabled = haveFields;

            btnChangeScheme.Enabled = haveFields; ;
        }

                #region "Fields"
        /// <summary>
        /// Adds selected field to the chart
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listLeft.SelectedIndex >= 0)
            {
                int index = listLeft.SelectedIndex;
                listRight.Items.Add(listLeft.SelectedItem);
                listLeft.Items.Remove(listLeft.SelectedItem);

                if (index < listLeft.Items.Count)
                    listLeft.SelectedIndex = index;
                else if (index - 1 >= 0)
                    listLeft.SelectedIndex = index - 1;

                listRight.SelectedIndex = listRight.Items.Count - 1;

                if (!_noEvents)
                    btnApply.Enabled = true;
            }
            RefreshFields();
            RefreshControlsState();
            Draw();
        }

        /// <summary>
        /// Updates fields chosen by user
        /// </summary>
        private void RefreshFields()
        {
            _shapefile.Diagrams.Fields.Clear();

            // adding selected fields
            for (int i = 0; i < listRight.Items.Count; i++)
            {
                var fields = _shapefile.Fields;
                for (int j = 0; j < fields.Count; j++)
                {
                    if (listRight.Items[i].ToString().ToLower() == fields[j].Name.ToLower())
                    {
                        double val = i / (double)(listRight.Items.Count - 1);

                        var field = new DiagramField();
                        field.Index = j;
                        field.Name = fields[j].Name;
                        _shapefile.Diagrams.Fields.Add(field);
                    }
                }
            }

            UpdateFieldColors();
        }

        /// <summary>
        /// Removes selected field form the chart
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listRight.SelectedIndex >= 0)
            {
                int index = listRight.SelectedIndex;
                listLeft.Items.Add(listRight.SelectedItem);
                listRight.Items.Remove(listRight.SelectedItem);

                if (index < listRight.Items.Count)
                {
                    listRight.SelectedIndex = index;
                }
                else if (index - 1 >= 0)
                {
                    listRight.SelectedIndex = index - 1;
                }

                listLeft.SelectedIndex = listLeft.Items.Count - 1;

                if (!_noEvents)
                {
                    btnApply.Enabled = true;
                }
            }
            RefreshFields();
            RefreshControlsState();
            Draw();
        }

        /// <summary>
        /// Adds all the fields to the chart
        /// </summary>
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (!_noEvents && listLeft.Items.Count > 0)
            {
                btnApply.Enabled = true;
            }

            for (int i = 0; i < listLeft.Items.Count; i++)
            {
                listRight.Items.Add(listLeft.Items[i]);
            }
            listLeft.Items.Clear();

            if (listRight.Items.Count > 0)
            {
                listRight.SelectedIndex = listRight.Items.Count - 1;
            }
            RefreshFields();
            RefreshControlsState();
            Draw();
        }

        /// <summary>
        ///  Removes all the fields from the chart
        /// </summary>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (!_noEvents && listRight.Items.Count > 0)
            {
                btnApply.Enabled = true;
            }

            for (int i = 0; i < listRight.Items.Count; i++)
            {
                listLeft.Items.Add(listRight.Items[i]);
            }
            listRight.Items.Clear();
            
            if (listLeft.Items.Count > 0)
            {
                listLeft.SelectedIndex = listLeft.Items.Count - 1;
            }
            
            RefreshFields();
            RefreshControlsState();
            Draw();
        }

        #endregion

        /// <summary>
        /// Building chart expression
        /// </summary>
        private void btnChartExpression_Click(object sender, EventArgs e)
        {
            string s = txtChartExpression.Text;
            var form = new QueryBuilderForm(_layer, s, false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtChartExpression.Text = form.Tag.ToString();
                _shapefile.Diagrams.VisibilityExpression = txtChartExpression.Text;
                btnApply.Enabled = true;
            }
            form.Dispose();
        }

        /// <summary>
        /// Clears the charts expression
        /// </summary>
        private void btnClearChartsExpression_Click(object sender, EventArgs e)
        {
            txtChartExpression.Clear();
            _shapefile.Diagrams.VisibilityExpression = "";
            btnApply.Enabled = true;
        }

        /// <summary>
        /// Applies options and redraws map without closing the form
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ApplyOptions())
            {
                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                _context.Project.SetModified();
                _initState = _charts.Serialize();
                btnApply.Enabled = false;
            }
        }
        
        /// <summary>
        /// Applies trasnparency set by user
        /// </summary>
        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Ui2Settings(null, null);
        }
        
        /// <summary>
        /// Reverts changes if cancel was chosen
        /// </summary>
        private void frmChartStyle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                var mode = _charts.SavingMode;
                _charts.SavingMode = PersistenceType.None;
                _charts.Deserialize(_initState);
                _charts.SavingMode = mode;
            }
        }

        /// <summary>
        /// Opens window to edit the list of color schemes for charts
        /// </summary>
        private void btnChangeScheme_Click(object sender, EventArgs e)
        {
            using (var form = new ColorSchemesForm(icbColors.ColorSchemes))
            {
                _noEvents = true;
                form.ShowDialog(this);
                form.Dispose();
            }
        }

        /// <summary>
        /// Sets max visible scale to current scale
        /// </summary>
        private void btnSetMaxScale_Click(object sender, EventArgs e)
        {
            var map = _context.Map;
            if (map != null)
            {
                cboMaxScale.Text = map.CurrentScale.ToString();
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Sets min visible scale to current scale
        /// </summary>
        private void btnSetMinScale_Click(object sender, EventArgs e)
        {
            var map = _context.Map;
            if (map != null)
            {
                cboMinScale.Text = map.CurrentScale.ToString();
                btnApply.Enabled = true;
            }
        }
    }
}
