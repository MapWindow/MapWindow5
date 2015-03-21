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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    /// <summary>
    /// Categories generation form with avanced set of options
    /// </summary>
    public partial class GenerateCategoriesForm : MapWindowForm
    {
        private readonly ILayer _layer;
        private readonly IFeatureSet _shapefile;
        
        /// <summary>
        /// Generates a new instance of the GenerateCategoriesForm class
        /// </summary>
        public GenerateCategoriesForm(ILayer layer)
        {
            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }
            _layer = layer;

            InitializeComponent();

            _shapefile = layer.FeatureSet;
            
            var settings = LayerSettingsService.get_LayerSettings(_layer.Handle);
            
            // classification
            cboClassificationType.Items.Clear();
            cboClassificationType.Items.Add("Natural breaks");
            cboClassificationType.Items.Add("Unique values");
            cboClassificationType.Items.Add("Equal intervals");
            cboClassificationType.Items.Add("Quantiles");
            cboClassificationType.SelectedIndex = (int)settings.CategoriesClassification;

            // number of categories
            cboCategoriesCount.Items.Clear();
            for (int i = 3; i <= 25; i++)
            {
                cboCategoriesCount.Items.Add(Convert.ToString(i));
            }
            cboCategoriesCount.Text = settings.CategoriesCount.ToString();

            // dummy color scheme
            ColorSchemeProvider.GetList(ColorSchemeType.Default).SetDefaultColorScheme(_shapefile);

            // initializing for list of color schemes
            icbColorScheme.ColorSchemeType = ColorSchemeType.Default;
            icbColorScheme.ComboStyle = ImageComboStyle.ColorSchemeGraduated;

            // settings active color scheme
            for (int i = 0; i < icbColorScheme.Items.Count; i++)
            {
                if (icbColorScheme.ColorSchemes.List[i] == settings.CategoriesColorScheme)
                {
                    icbColorScheme.SelectedIndex = i;
                    break;
                }
            }
            if (icbColorScheme.SelectedItem == null)
                icbColorScheme.SelectedIndex = 0;

            if (_shapefile.PointOrMultiPoint)
            {
                chkUseVariableSize.Text = "Use variable symbol size";
                udMinSize.Minimum = 1;
                udMinSize.Maximum = 80;
                udMaxSize.Minimum = 1;
                udMaxSize.Maximum = 80;
                udMinSize.SetValue(_shapefile.Style.Marker.Size);
                udMaxSize.SetValue((double)udMinSize.Value + settings.CategoriesSizeRange);
            }
            else if (_shapefile.GeometryType == MW5.Api.GeometryType.Polyline)
            {
                chkUseVariableSize.Text = "Use variable line width";
                udMinSize.Minimum = 1;
                udMinSize.Maximum = 10;
                udMaxSize.Minimum = 1;
                udMaxSize.Maximum = 10;
                udMinSize.SetValue(_shapefile.Style.Line.Width);
                udMaxSize.SetValue((double)udMinSize.Value + settings.CategoriesSizeRange);
            }
            else
            {
                chkUseVariableSize.Enabled = false;
                udMinSize.Value = udMinSize.Minimum;
                udMinSize.Enabled = false;
                udMaxSize.Value = udMaxSize.Minimum;
                udMaxSize.Enabled = false;
            }

            chkRandomColors.Checked = settings.CategoriesRandomColors;
            chkSetGradient.Checked = settings.CategoriesUseGradient;
            chkUseVariableSize.Checked = settings.CategoriesVariableSize;

            RefreshControlsState(null, null);

            string name = settings.CategoriesFieldName.ToLower();
            for (int i = 0; i < cboField.Items.Count; i++)
            {
                if (((ComboItem)cboField.Items[i]).Text.ToLower() == name)
                {
                    cboField.SelectedIndex = i;
                    break;
                }
            }
        }
       
        /// <summary>
        /// Generates shapefile categories according to specified options
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0)
            {
                SymbologyPlugin.Msg.Info("No field for generation was selected.");
                DialogResult = DialogResult.None;
                return;
            }
            
            int count;
            if (!Int32.TryParse(cboCategoriesCount.Text, out count))
            {
                SymbologyPlugin.Msg.Warn("Number of categories isn't a valid interger.");
                return;
            }

            var categories = _shapefile.Categories;
            int index = ((ComboItem)cboField.SelectedItem).RealIndex;
            categories.Generate(index, (Classification)cboClassificationType.SelectedIndex, count);

            categories.Caption = "Categories: " + _shapefile.Fields[index].Name;

            if (chkUseVariableSize.Checked)
            {
                if (_shapefile.PointOrMultiPoint)
                {
                    double step =  (double)(udMaxSize.Value - udMinSize.Value) / ((double)categories.Count - 1);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories[i].Style.Marker.Size = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
                else if (_shapefile.GeometryType == GeometryType.Polyline)
                {
                    double step = (double)(udMaxSize.Value + udMinSize.Value) / (double)categories.Count;
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories[i].Style.Line.Width = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
            }

            ColorRamp scheme = null;
            if (icbColorScheme.SelectedIndex >= 0)
            {
                var blend = icbColorScheme.ColorSchemes.List[icbColorScheme.SelectedIndex];
                scheme = blend.ToColorScheme();
            }

            var type = chkRandomColors.Checked ? ColorRampType.Random : ColorRampType.Graduated;
            _shapefile.Categories.ApplyColorScheme(type, scheme);

            if (chkSetGradient.Checked)
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    IGeometryStyle options = categories[i].Style;
                    options.Fill.SetGradient(options.Fill.Color, 75);
                    options.Fill.Type = FillType.Gradient;
                }
            }

            _shapefile.Categories.ApplyExpressions();

            SaveSettings();
        }

        /// <summary>
        /// Generates label categories for the given set of categories
        /// </summary>
        //private void GenerateLabelCategories()
        //{
        //    Layer layer = m_legend.Layers.ItemByHandle(_layerHandle);
        //    if (layer == null) return;

        //    _shapefile.Labels.ClearCategories();
        //    for (int i = 0; i < _shapefile.Categories.Count; i++)
        //    {
        //        _shapefile.Labels.AddCategory(_shapefile.Categories.get_Item(i).Name);
        //    }
        //}

        /// <summary>
        /// Saves the state of controls for the further launches
        /// </summary>
        private void SaveSettings()
        {
            var settings = LayerSettingsService.get_LayerSettings(_layer.Handle);

            int count;
            settings.CategoriesCount = Int32.TryParse(cboCategoriesCount.Text, out count) ? count : 8;

            // saving the options for the next time
            if (cboField.SelectedItem != null)
                settings.CategoriesFieldName = ((ComboItem)cboField.SelectedItem).Text;
            else
                settings.CategoriesFieldName = string.Empty;

            settings.CategoriesClassification = (Classification)cboClassificationType.SelectedIndex; ;

            if (icbColorScheme.SelectedItem != null)
                settings.CategoriesColorScheme = (ColorBlend)icbColorScheme.ColorSchemes.List[icbColorScheme.SelectedIndex];
            else
                settings.CategoriesColorScheme = null;

            settings.CategoriesRandomColors = chkRandomColors.Checked;
            settings.CategoriesUseGradient = chkSetGradient.Checked;
            settings.CategoriesVariableSize = chkUseVariableSize.Checked;
            //settings.CategoriesSortingField = cboSortingField.Text;

            if (chkUseVariableSize.Checked)
                settings.CategoriesSizeRange = (int)(udMaxSize.Value - udMinSize.Value);

            LayerSettingsService.SaveLayerSettings(_layer.Handle, settings);
        }

        /// <summary>
        /// Displaying the visualization options according to the chosen classification
        /// </summary>
        private void RefreshControlsState(object sender, EventArgs e)
        {
            bool uniqueValues = ((Classification)cboClassificationType.SelectedIndex == Classification.UniqueValues);
            cboCategoriesCount.Enabled = !uniqueValues;
            //cboSortingField.Enabled = false; // uniqueValues;

            udMaxSize.Enabled = chkUseVariableSize.Checked;
            udMinSize.Enabled = chkUseVariableSize.Checked;

            // fields; graduated color schemes doesn't accept string fields, therefore we need to build new list in this case
            int fieldIndex = -1;
            if (cboField.SelectedItem != null)
                fieldIndex = ((ComboItem)cboField.SelectedItem).RealIndex;
            
            cboField.Items.Clear();
            if (_shapefile != null)
            {
                for (int i = 0; i < _shapefile.Fields.Count; i++)
                {
                    var fld = _shapefile.Fields[i];
                    if ((!uniqueValues) && fld.Type == AttributeType.String)
                    {
                        continue;
                    }
                    cboField.Items.Add(new ComboItem(fld.Name, i));
                }

                if (cboField.Items.Count > 0)
                {
                    if (fieldIndex != -1)
                    {
                        for (int i = 0; i < cboField.Items.Count; i++)
                        {
                            if (((ComboItem)cboField.Items[i]).RealIndex == fieldIndex)
                            {
                                cboField.SelectedIndex = i;
                                break;
                            }
                        }
                        if (cboField.SelectedIndex == -1)
                            cboField.SelectedIndex = 0;
                    }
                    else
                        cboField.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Toggles between graduated and random colors
        /// </summary>
        private void chkRandomColors_CheckedChanged(object sender, EventArgs e)
        {
            int index = icbColorScheme.SelectedIndex;
            icbColorScheme.ComboStyle = chkRandomColors.Checked ? ImageComboStyle.ColorSchemeRandom : ImageComboStyle.ColorSchemeGraduated;
            if (index >= 0 && index < icbColorScheme.Items.Count)
            {
                icbColorScheme.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //SaveSettings();
        }

        /// <summary>
        /// Opens the editor of color schemes
        /// </summary>
        private void btnChangeColorScheme_Click(object sender, EventArgs e)
        {
            var list = ColorSchemeProvider.GetList(ColorSchemeType.Default);
            using (var form = new ColorSchemesForm(list))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    icbColorScheme.ColorSchemes = list;
                }
            }
        }
    }
}
