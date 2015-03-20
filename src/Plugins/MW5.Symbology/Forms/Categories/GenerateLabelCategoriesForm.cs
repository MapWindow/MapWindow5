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
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Forms.Labels;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    public partial class GenerateLabelCategoriesForm : Form
    {
        // Refrence to the shapefile
        private IFeatureSet m_shapefile;
        
        // Reference to the plug-in
        private IMuteLegend m_legend = null;
        
        // Layer handle
        private int m_layerHandle = -1;

        /// <summary>
        /// Creates a new instance of the frmGenerateLabelCategories class
        /// </summary>
        public GenerateLabelCategoriesForm(IMuteLegend legend, IFeatureSet sf, int layerHandle)
        {
            InitializeComponent();

            m_shapefile = sf;
            m_legend = legend;
            m_layerHandle = layerHandle;

            var layer = legend.Layers.ItemByHandle(layerHandle);

            // classification
            cboClassificationType.Items.Clear();
            cboClassificationType.Items.Add("Natural breaks");
            cboClassificationType.Items.Add("Unique values");
            cboClassificationType.Items.Add("Quantiles");
            cboClassificationType.Items.Add("Equal intervals");

            // number of categories
            cboCategoriesCount.Items.Clear();
            for (int i = 3; i <= 25; i++)
            {
                cboCategoriesCount.Items.Add(Convert.ToString(i));
            }

            // initializing for list of color schemes
            icbFrame.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            Globals.LayerColors.SetFirstColorScheme(m_shapefile.Labels.Style.FrameBackColor);
            icbFrame.ColorSchemes = Globals.LayerColors;

            udMinSize.Value = sf.Labels.Style.FontSize;

            LoadOptions();

            RefreshControlsState(null, null);

            DrawPreview();
        }

        /// <summary>
        /// Loads options set by previous run
        /// </summary>
        private void LoadOptions()
        {
            SymbologySettings settings = null;//m_plugin.get_LayerSettings(_layerHandle);

            cboClassificationType.SelectedIndex = (int)settings.LabelsClassification;
            cboCategoriesCount.Text = settings.LabelsCategoriesCount.ToString();
            udMinSize.SetValue((double)settings.LabelsSize);
            udMaxSize.SetValue((double)udMinSize.Value + settings.LabelsSizeRange);
            chkUseVariableSize.Checked = settings.LabelsVariableSize;
            icbFrame.ComboStyle = settings.LabelsRandomColors ? ImageComboStyle.ColorSchemeRandom : ImageComboStyle.ColorSchemeGraduated;
            chkGraduatedFrame.Checked = settings.LabelsGraduatedColors;
            chkRandomColors.Checked = settings.LabelsRandomColors;

            cboField.Items.Clear();
            cboField.Items.Add(settings.LabelsFieldName);
            cboField.SelectedIndex = 0;
            
            if (icbFrame.Items.Count > settings.LabelsSchemeIndex && settings.LabelsSchemeIndex >= 0)
            {
                icbFrame.SelectedIndex = settings.LabelsSchemeIndex;
            }
            else
            {
                if (icbFrame.Items.Count > 0)
                    icbFrame.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Displaying the visualiztion options according to the chosen classification
        /// </summary>
        private void RefreshControlsState(object sender, EventArgs e)
        {
            bool uniqueValues = ((Classification)cboClassificationType.SelectedIndex == Classification.UniqueValues);
            cboCategoriesCount.Enabled = !uniqueValues;
            
            // fields; graduated color schemes doesn't accept string fields, therefore we need to build new list in this case
            string fieldName = "";
            if (cboField.SelectedItem != null)
            {
                fieldName = cboField.SelectedItem.ToString();
            }
            
            cboField.Items.Clear();
            if (m_shapefile != null)
            {
                foreach(var fld in m_shapefile.Fields)
                {
                    if ((!uniqueValues) && fld.Type == AttributeType.String)
                    {
                        continue;
                    }
                    cboField.Items.Add(fld.Name);
                }

                if (cboField.Items.Count > 0)
                {
                    if (fieldName != "")
                    {
                        for (int i = 0; i < cboField.Items.Count; i++)
                        {
                            if (cboField.Items[i].ToString() == fieldName)
                            {
                                cboField.SelectedIndex = i;
                                break;
                            }
                        }
                        if (cboField.SelectedIndex == -1)
                        {
                            cboField.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cboField.SelectedIndex = 0;
                    }
                }
            }
            
            udMinSize.Enabled = chkUseVariableSize.Checked;
            udMaxSize.Enabled = chkUseVariableSize.Checked;
            icbFrame.Enabled = chkGraduatedFrame.Checked;
            btnFrameScheme.Enabled = chkGraduatedFrame.Checked;
            groupColors.Text = m_shapefile.Labels.Style.FrameVisible ? "Frame colors" : "Font colors";
            chkRandomColors.Enabled = chkGraduatedFrame.Checked;
        }

        /// <summary>
        /// Generation of labels categories
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0)
            {
                Globals.Message.Info("No field for generation was selected");
                this.DialogResult = DialogResult.None;
                return;
            }

            int count = 0;
            if (!Int32.TryParse(cboCategoriesCount.Text, out count))
            {
                Globals.Message.Info("The entered categories count isn't a number");
                DialogResult = DialogResult.None;
                return;
            }

            string fieldName = cboField.SelectedItem.ToString();
            int index = -1;
            for (int i = 0; i < m_shapefile.Fields.Count; i++)
            {
                if (m_shapefile.Fields[i].Name == fieldName)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return;

            //m_shapefile.Labels.GenerateCategories(index, (MapWinGIS.tkClassificationType)cboClassificationType.SelectedIndex, count);

            //if (chkUseVariableSize.Checked)
            //{
            //    int numCategories = m_shapefile.Labels.NumCategories;
            //    double step = (double)(udMaxSize.Value - udMinSize.Value) / ((double)numCategories - 1);
            //    for (int i = 0; i < numCategories; i++)
            //    {
            //        m_shapefile.Labels.get_Category(i).FontSize = (int)udMinSize.Value + Convert.ToInt32(i * step);
            //    }
            //}

            //if (chkGraduatedFrame.Checked)
            //{
            //    ColorBlend blend = (ColorBlend)icbFrame.ColorSchemes.List[icbFrame.SelectedIndex];
            //    ColorRamp scheme = ColorSchemes.ColorBlend2ColorScheme(blend);
            //    tkColorSchemeType type = chkRandomColors.Checked ? tkColorSchemeType.ctSchemeRandom : tkColorSchemeType.ctSchemeGraduated;
            //    m_shapefile.Labels.ApplyColorScheme2(type, scheme, tkLabelElements.leFrameBackground);
            //}
            //for (int i = 0; i < m_shapefile.Labels.NumCategories; i++)
            //{
            //    m_shapefile.Labels.get_Category(i).FrameVisible = chkGraduatedFrame.Checked;
            //}

            //m_shapefile.Labels.ApplyCategories();
            SaveSettings();
        }

        /// <summary>
        /// Saves the settings for the next session
        /// </summary>
        private void SaveSettings()
        {
            // saving the settings for the subsequent generations
            SymbologySettings settings = Globals.get_LayerSettings(m_layerHandle);

            settings.LabelsVariableSize = chkUseVariableSize.Checked;
            settings.LabelsSizeRange = (int)(udMaxSize.Value - udMinSize.Value);
            settings.LabelsGraduatedColors = chkGraduatedFrame.Checked;
            settings.LabelsRandomColors = chkRandomColors.Checked;
            settings.LabelsFieldName = cboField.Text;
            settings.LabelsSchemeIndex = icbFrame.SelectedIndex;
            settings.LabelsClassification= (Classification)cboClassificationType.SelectedIndex;
            settings.LabelsSize = (int)udMinSize.Value;

            int val;
            if (Int32.TryParse(cboCategoriesCount.Text, out val))
                settings.LabelsCategoriesCount = val;
            if (icbFrame.SelectedItem != null)
                settings.LabelsScheme = (ColorBlend)icbFrame.ColorSchemes.List[icbFrame.SelectedIndex];

            Globals.SaveLayerSettings(m_layerHandle, settings);
        }

        /// <summary>
        /// Changes the default style of labels to generate based on
        /// </summary>
        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            var styleFormForm = new LabelStyleForm(m_shapefile, m_shapefile.Labels.Style);
            if (styleFormForm.ShowDialog(this) == DialogResult.OK)
            {
                // refreshing preview
                DrawPreview();
                RefreshControlsState(null, null);    
            }
            styleFormForm.Dispose();
        }

        /// <summary>
        /// Refreshes the preview of the default style
        /// </summary>
        private void DrawPreview()
        {
            var lyr = m_legend.Layers.ItemByHandle(m_layerHandle);
            var fs = lyr.FeatureSet;
        }

        /// <summary>
        /// Opens the editor of color schemes
        /// </summary>
        private void btnEditColorScheme_Click(object sender, EventArgs e)
        {
            frmColorSchemes form = new frmColorSchemes(ref Globals.LayerColors);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.icbFrame.ColorSchemes = Globals.LayerColors;
            }
            form.Dispose();
        }

        /// <summary>
        /// Opens the editor of color schemes
        /// </summary>
        private void btnFrameScheme_Click(object sender, EventArgs e)
        {
            frmColorSchemes form = new frmColorSchemes(ref Globals.LayerColors);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.icbFrame.ColorSchemes = Globals.LayerColors;
            }
            form.Dispose();
        }

        #region ComboItem
        /// <summary>
        /// A class for items with realIndex property
        /// </summary>
        private class ComboItem
        {
            string m_text = string.Empty;
            int m_realIndex;

            public ComboItem(string text, int realIndex)
            {
                m_text = text;
                m_realIndex = realIndex;
            }
            public override string ToString()
            {
                return m_text;
            }
            public string Text
            {
                get { return m_text; }
            }
            public int RealIndex
            {
                get { return m_realIndex; }
            }
        }
        #endregion

        /// <summary>
        /// Toggles between random and graduated colors schemes
        /// </summary>
        private void chkRandomColors_CheckedChanged(object sender, EventArgs e)
        {
            int index = icbFrame.SelectedIndex;
            if (chkRandomColors.Checked)
            {
                icbFrame.ComboStyle = ImageComboStyle.ColorSchemeRandom;
            }
            else
            {
                icbFrame.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            }

            if (index >= 0 && index < icbFrame.Items.Count)
            {
                icbFrame.SelectedIndex = index;
            }
        }

    }
}
