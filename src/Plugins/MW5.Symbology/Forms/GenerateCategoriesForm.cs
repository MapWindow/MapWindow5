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
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
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
        public GenerateCategoriesForm(IAppContext context, ILayer layer):
            base(context)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }
            _layer = layer;

            InitializeComponent();

            _shapefile = layer.FeatureSet;

            var settings = SymbologyPlugin.GetMetadata(_layer.Handle);
            
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
            ColorSchemeProvider.SetFirstColorScheme(SchemeTarget.Vector, _shapefile);

            // initializing for list of color schemes
            icbColorScheme.SchemeTarget = SchemeTarget.Vector;

            // settings active color scheme
            icbColorScheme.SetSelectedItem(settings.CategoriesColorScheme);

            if (icbColorScheme.SelectedItem == null)
            {
                icbColorScheme.SelectedIndex = 0;
            }

            InitSize();

            chkRandomColors.Checked = settings.CategoriesRandomColors;
            chkSetGradient.Checked = settings.CategoriesUseGradient;
            chkUseVariableSize.Checked = settings.CategoriesVariableSize;

            RefreshControlsState(null, null);

            string name = settings.CategoriesFieldName.ToLower();
            for (int i = 0; i < cboField.Items.Count; i++)
            {
                if (((RealIndexComboItem)cboField.Items[i]).Text.ToLower() == name)
                {
                    cboField.SelectedIndex = i;
                    break;
                }
            }
        }

        private void InitSize()
        {
            var settings = SymbologyPlugin.GetMetadata(_layer.Handle);

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
            else if (_shapefile.GeometryType == GeometryType.Polyline)
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
        }

        /// <summary>
        /// Generates shapefile categories according to specified options
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0)
            {
                MessageService.Current.Info("No field for generation was selected.");
                DialogResult = DialogResult.None;
                return;
            }
            
            int count;
            if (!Int32.TryParse(cboCategoriesCount.Text, out count))
            {
                MessageService.Current.Warn("Number of categories isn't a valid interger.");
                return;
            }

            var categories = _shapefile.Categories;
            int index = ((RealIndexComboItem)cboField.SelectedItem).RealIndex;
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
                var blend = icbColorScheme.ColorSchemes[icbColorScheme.SelectedIndex];
                scheme = blend.ToColorScheme();
            }

            var type = chkRandomColors.Checked ? SchemeType.Random : SchemeType.Graduated;
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
        /// Saves the state of controls for the further launches
        /// </summary>
        private void SaveSettings()
        {
            var settings = SymbologyPlugin.GetMetadata(_layer.Handle);

            int count;
            settings.CategoriesCount = Int32.TryParse(cboCategoriesCount.Text, out count) ? count : 8;

            settings.CategoriesFieldName = cboField.SelectedItem != null ? ((RealIndexComboItem)cboField.SelectedItem).Text : string.Empty;
            settings.CategoriesClassification = (Classification)cboClassificationType.SelectedIndex; ;
            settings.CategoriesColorScheme = icbColorScheme.GetSelectedItem();
            settings.CategoriesRandomColors = chkRandomColors.Checked;
            settings.CategoriesUseGradient = chkSetGradient.Checked;
            settings.CategoriesVariableSize = chkUseVariableSize.Checked;

            if (chkUseVariableSize.Checked)
            {
                settings.CategoriesSizeRange = (int) (udMaxSize.Value - udMinSize.Value);
            }
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
                fieldIndex = ((RealIndexComboItem)cboField.SelectedItem).RealIndex;
            
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
                    cboField.Items.Add(new RealIndexComboItem(fld.Name, i));
                }

                if (cboField.Items.Count > 0)
                {
                    if (fieldIndex != -1)
                    {
                        for (int i = 0; i < cboField.Items.Count; i++)
                        {
                            if (((RealIndexComboItem)cboField.Items[i]).RealIndex == fieldIndex)
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
            icbColorScheme.ComboStyle = chkRandomColors.Checked ? SchemeType.Random : SchemeType.Graduated;
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
            using (var form = new ColorSchemesForm(_context, icbColorScheme.ColorSchemes))
            {
                _context.View.ShowChildView(form, this);
            }
        }
    }
}
