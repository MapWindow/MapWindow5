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
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms.Style;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    //public partial class GenerateLabelCategoriesForm : MapWindowForm
    //{
    //    private readonly IAppContext _context;
    //    private readonly ILayer _layer;
    //    private readonly SymbologyMetadata _metadata;
    //    private readonly IFeatureSet _shapefile;
    //    private readonly int _layerHandle;

    //    /// <summary>
    //    /// Creates a new instance of the frmGenerateLabelCategories class
    //    /// </summary>
    //    public GenerateLabelCategoriesForm(IAppContext context, ILayer layer, SymbologyMetadata metadata)
    //    {
    //        if (context == null) throw new ArgumentNullException("context");
    //        if (metadata == null) throw new ArgumentNullException("metadata");

    //        if (layer == null || layer.FeatureSet == null)
    //        {
    //            throw new ArgumentNullException("layer");
    //        }

    //        InitializeComponent();

    //        _context = context;
    //        _layer = layer;
    //        _metadata = metadata;

    //        _shapefile = layer.FeatureSet;
    //        _layerHandle = layer.Handle;

    //        // classification
    //        cboClassificationType.Items.Clear();
    //        cboClassificationType.Items.Add("Natural breaks");
    //        cboClassificationType.Items.Add("Unique values");
    //        cboClassificationType.Items.Add("Quantiles");
    //        cboClassificationType.Items.Add("Equal intervals");

    //        // number of categories
    //        cboCategoriesCount.Items.Clear();
    //        for (int i = 3; i <= 25; i++)
    //        {
    //            cboCategoriesCount.Items.Add(Convert.ToString(i));
    //        }

    //        // initializing for list of color schemes
    //        ColorSchemeProvider.SetFirstColorScheme(ColorSchemes.Default, _shapefile.Labels.Style.FrameBackColor);
    //        icbFrame.ColorSchemeType = ColorSchemes.Default;

    //        udMinSize.Value = _shapefile.Labels.Style.FontSize;

    //        LoadOptions();

    //        RefreshControlsState(null, null);

    //        DrawPreview();
    //    }

    //    /// <summary>
    //    /// Loads options set by previous run
    //    /// </summary>
    //    private void LoadOptions()
    //    {
    //        cboClassificationType.SelectedIndex = (int)_metadata.LabelsClassification;
    //        cboCategoriesCount.Text = _metadata.LabelsCategoriesCount.ToString();
    //        udMinSize.SetValue((double)_metadata.LabelsSize);
    //        udMaxSize.SetValue((double)udMinSize.Value + _metadata.LabelsSizeRange);
    //        chkUseVariableSize.Checked = _metadata.LabelsVariableSize;
    //        icbFrame.ComboStyle = _metadata.LabelsRandomColors ? ColorRampType.Random : ColorRampType.Graduated;
    //        chkGraduatedFrame.Checked = _metadata.LabelsGraduatedColors;
    //        chkRandomColors.Checked = _metadata.LabelsRandomColors;

    //        cboField.Items.Clear();
    //        cboField.Items.Add(_metadata.LabelsFieldName);
    //        cboField.SelectedIndex = 0;
            
    //        if (icbFrame.Items.Count > _metadata.LabelsSchemeIndex && _metadata.LabelsSchemeIndex >= 0)
    //        {
    //            icbFrame.SelectedIndex = _metadata.LabelsSchemeIndex;
    //        }
    //        else
    //        {
    //            if (icbFrame.Items.Count > 0)
    //                icbFrame.SelectedIndex = 0;
    //        }
    //    }

    //    /// <summary>
    //    /// Displaying the visualiztion options according to the chosen classification
    //    /// </summary>
    //    private void RefreshControlsState(object sender, EventArgs e)
    //    {
    //        bool uniqueValues = ((Classification)cboClassificationType.SelectedIndex == Classification.UniqueValues);
    //        cboCategoriesCount.Enabled = !uniqueValues;
            
    //        // fields; graduated color schemes doesn't accept string fields, therefore we need to build new list in this case
    //        string fieldName = "";
    //        if (cboField.SelectedItem != null)
    //        {
    //            fieldName = cboField.SelectedItem.ToString();
    //        }
            
    //        cboField.Items.Clear();
    //        if (_shapefile != null)
    //        {
    //            foreach(var fld in _shapefile.Fields)
    //            {
    //                if ((!uniqueValues) && fld.Type == AttributeType.String)
    //                {
    //                    continue;
    //                }
    //                cboField.Items.Add(fld.Name);
    //            }

    //            if (cboField.Items.Count > 0)
    //            {
    //                if (fieldName != "")
    //                {
    //                    for (int i = 0; i < cboField.Items.Count; i++)
    //                    {
    //                        if (cboField.Items[i].ToString() == fieldName)
    //                        {
    //                            cboField.SelectedIndex = i;
    //                            break;
    //                        }
    //                    }
    //                    if (cboField.SelectedIndex == -1)
    //                    {
    //                        cboField.SelectedIndex = 0;
    //                    }
    //                }
    //                else
    //                {
    //                    cboField.SelectedIndex = 0;
    //                }
    //            }
    //        }
            
    //        udMinSize.Enabled = chkUseVariableSize.Checked;
    //        udMaxSize.Enabled = chkUseVariableSize.Checked;
    //        icbFrame.Enabled = chkGraduatedFrame.Checked;
    //        btnFrameScheme.Enabled = chkGraduatedFrame.Checked;
    //        groupColors.Text = _shapefile.Labels.Style.FrameVisible ? "Frame colors" : "Font colors";
    //        chkRandomColors.Enabled = chkGraduatedFrame.Checked;
    //    }

    //    /// <summary>
    //    /// Generation of labels categories
    //    /// </summary>
    //    private void btnOk_Click(object sender, EventArgs e)
    //    {
    //        if (cboField.SelectedIndex < 0)
    //        {
    //            MessageService.Current.Info("No field for generation was selected");
    //            this.DialogResult = DialogResult.None;
    //            return;
    //        }

    //        int count = 0;
    //        if (!Int32.TryParse(cboCategoriesCount.Text, out count))
    //        {
    //            MessageService.Current.Info("The entered categories count isn't a number");
    //            DialogResult = DialogResult.None;
    //            return;
    //        }

    //        string fieldName = cboField.SelectedItem.ToString();
    //        int index = -1;
    //        for (int i = 0; i < _shapefile.Fields.Count; i++)
    //        {
    //            if (_shapefile.Fields[i].Name == fieldName)
    //            {
    //                index = i;
    //                break;
    //            }
    //        }

    //        if (index == -1)
    //            return;

    //        //m_shapefile.Labels.GenerateCategories(index, (MapWinGIS.tkClassificationType)cboClassificationType.SelectedIndex, count);

    //        //if (chkUseVariableSize.Checked)
    //        //{
    //        //    int numCategories = m_shapefile.Labels.NumCategories;
    //        //    double step = (double)(udMaxSize.Value - udMinSize.Value) / ((double)numCategories - 1);
    //        //    for (int i = 0; i < numCategories; i++)
    //        //    {
    //        //        m_shapefile.Labels.get_Category(i).FontSize = (int)udMinSize.Value + Convert.ToInt32(i * step);
    //        //    }
    //        //}

    //        //if (chkGraduatedFrame.Checked)
    //        //{
    //        //    ColorBlend blend = (ColorBlend)icbFrame.ColorSchemes.List[icbFrame.SelectedIndex];
    //        //    ColorRamp scheme = ColorSchemes.ColorBlend2ColorScheme(blend);
    //        //    tkColorSchemeType type = chkRandomColors.Checked ? tkColorSchemeType.ctSchemeRandom : tkColorSchemeType.ctSchemeGraduated;
    //        //    m_shapefile.Labels.ApplyColorScheme2(type, scheme, tkLabelElements.leFrameBackground);
    //        //}
    //        //for (int i = 0; i < m_shapefile.Labels.NumCategories; i++)
    //        //{
    //        //    m_shapefile.Labels.get_Category(i).FrameVisible = chkGraduatedFrame.Checked;
    //        //}

    //        //m_shapefile.Labels.ApplyCategories();
    //        SaveSettings();
    //    }

    //    /// <summary>
    //    /// Saves the settings for the next session
    //    /// </summary>
    //    private void SaveSettings()
    //    {
    //        // saving the settings for the subsequent generations
    //        _metadata.LabelsVariableSize = chkUseVariableSize.Checked;
    //        _metadata.LabelsSizeRange = (int)(udMaxSize.Value - udMinSize.Value);
    //        _metadata.LabelsGraduatedColors = chkGraduatedFrame.Checked;
    //        _metadata.LabelsRandomColors = chkRandomColors.Checked;
    //        _metadata.LabelsFieldName = cboField.Text;
    //        _metadata.LabelsSchemeIndex = icbFrame.SelectedIndex;
    //        _metadata.LabelsClassification= (Classification)cboClassificationType.SelectedIndex;
    //        _metadata.LabelsSize = (int)udMinSize.Value;

    //        int val;
    //        if (Int32.TryParse(cboCategoriesCount.Text, out val))
    //        {
    //            _metadata.LabelsCategoriesCount = val;
    //        }
    //        if (icbFrame.SelectedItem != null)
    //        {
    //            _metadata.LabelsScheme = icbFrame.ColorSchemes.List[icbFrame.SelectedIndex];
    //        }
    //    }

    //    /// <summary>
    //    /// Changes the default style of labels to generate based on
    //    /// </summary>
    //    private void btnChangeStyle_Click(object sender, EventArgs e)
    //    {
    //        using (var form = new LabelStyleForm(_context, _layer))
    //        {
    //            if (_context.View.ShowDialog(form, this))
    //            {
    //                DrawPreview();
    //                RefreshControlsState(null, null);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Refreshes the preview of the default style
    //    /// </summary>
    //    private void DrawPreview()
    //    {
            
    //    }

    //    /// <summary>
    //    /// Opens the editor of color schemes
    //    /// </summary>
    //    private void btnFrameScheme_Click(object sender, EventArgs e)
    //    {
    //        using (var form = new ColorSchemesForm(_context, icbFrame.ColorSchemes))
    //        {
    //            _context.View.ShowDialog(form, this);
    //        }
    //    }

    //    /// <summary>
    //    /// Toggles between random and graduated colors schemes
    //    /// </summary>
    //    private void chkRandomColors_CheckedChanged(object sender, EventArgs e)
    //    {
    //        int index = icbFrame.SelectedIndex;
    //        icbFrame.ComboStyle = chkRandomColors.Checked ? ColorRampType.Random : ColorRampType.Graduated;

    //        if (index >= 0 && index < icbFrame.Items.Count)
    //        {
    //            icbFrame.SelectedIndex = index;
    //        }
    //    }
    //}
}
