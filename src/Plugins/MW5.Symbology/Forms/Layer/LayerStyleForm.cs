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
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Services;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    /// <summary>
    /// A class representing GUI for managing Shapefile symbology
    /// </summary>
    public partial class LayerStyleForm : MapWindowForm
    {
        private const bool _redrawModeIsChanging = false;

        static int _tabIndex = 0;

        private readonly ILayer _layer;
        private readonly IFeatureSet _shapefile;
        private readonly SymbologyMetadata _metadata;

        private bool _noEvents;
        private string _initState;
        private bool _stateChanged;

        /// <summary>
        /// Creates new instance of the SymbologyMainForm class
        /// </summary>
        public LayerStyleForm(IAppContext context, ILayer layer):
            base(context)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layer == null) throw new ArgumentNullException("layer");
            
            InitializeComponent();

            Config.ForceHideLabels = true;

            _layer = layer;

            _metadata = SymbologyPlugin.Metadata(_layer.Handle);
            _shapefile = _layer.FeatureSet;

            Text = "Layer properties: " + _layer.Name;

            LockLegendAndMap(true);

            _initState = SaveState();
           
            ColorSchemeProvider.SetFirstColorScheme(ColorSchemes.Default, _shapefile);

            _noEvents = true;

            InitGeneralTab();

            InitModeTab();

            InitAppearanceTab();

            InitCategoriesTab();

            InitLabelsTab();

            InitChartsTab();

            InitExpressionTab();

            InitVisibilityTab();

            UpdateColorSchemes();
            
            // the state should be set after the loading as otherwise we can trigger unnecessary redraws
            chkRedrawMap.Checked = _metadata.UpdateMapAtOnce;

            _noEvents = false;
            
            // sets the enabled state of the controls
            RefreshControlsState(null, null);

            DrawAllPreviews();
            
            AddTooltips();

            tabControl1.SelectedIndex = _tabIndex;

            Shown += frmSymbologyMain_Shown;
        }

        private void LockLegendAndMap( bool state)
        {
            var legend = _context.Legend;
            if (state)
            {
                legend.Lock();
                legend.Map.Lock();
            }
            else
            {
                legend.Unlock();
                legend.Map.Unlock();
            }
        }

        void frmSymbologyMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Config.ForceHideLabels = false;
        }

        /// <summary>
        /// Sets the state of controls on the expression tab on loading
        /// </summary>
        private void InitExpressionTab()
        {
            txtLayerExpression.Text = _shapefile.VisibilityExpression;
        }
       
        #region Controls updating

        /// <summary>
        /// Updates shapefile settings according to the values of the controls 
        /// </summary>
        private void Ui2Settings(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            _stateChanged = true;
            btnSaveChanges.Enabled = true;

            if (tabControl1.SelectedTab.Name.ToLower() == "tabmode")
            {
                _shapefile.CollisionMode = (CollisionMode)cboCollisionMode.SelectedIndex;
            }
            if (tabControl1.SelectedTab.Name.ToLower() == "tabgeneral")
            {
                _layer.Visible = chkLayerVisible.Checked;
                _layer.Name = txtLayerName.Text;
            }
            else if (tabControl1.SelectedTab.Name.ToLower() == "tabdefault")
            {
                Controls2Appearance();
            }
            else if (tabControl1.SelectedTab.Name.ToLower() == "tablabels")
            {
                UpdateLabels();
                
            }
            else if (tabControl1.SelectedTab.Name.ToLower() == "tabcharts")
            {
                UpdateCharts();
            }

            _shapefile.VisibilityExpression = txtLayerExpression.Text;

            RefreshControlsState(null, null);
            RedrawMap();
        }

        /// <summary>
        /// Changes the enabled properties of controls
        /// </summary>
        private void RefreshControlsState(object sender, EventArgs e)
        {
            if (_noEvents)
                return;
            
            // appearance
            udDefaultSize.Enabled = _shapefile.PointOrMultiPoint;
            clpPointFill.Enabled = _shapefile.GeometryType == GeometryType.Polyline;
            clpSelection.Enabled = _shapefile.GeometryType == GeometryType.Polygon;

            // provide the options if there are a single line pattern, otherwise extednded options are needed
            IGeometryStyle options = _shapefile.Style;
            if (options.Line.UsePattern)
            {
                if (options.Line.Pattern.Count <= 1)
                {
                    panelLineOptions.Visible = true;
                    clpDefaultOutline.Enabled = true;
                    icbLineWidth.Enabled = (options.Line.Pattern[0].LineType == LineType.Simple);
                    lblMultilinePattern.Visible = false;
                }
                else
                {
                    lblMultilinePattern.Visible = true;
                    panelLineOptions.Visible = false;
                }
            }
            else
            {
                clpDefaultOutline.Enabled = true;
                icbLineWidth.Enabled = true;
                panelLineOptions.Visible = true;
                lblMultilinePattern.Visible = false;
            }

            // categories
            udMinSize.Enabled = chkUseVariableSize.Checked;
            udMaxSize.Enabled = chkUseVariableSize.Checked;
            udNumCategories.Enabled = !chkUniqueValues.Checked;
            btnCategoryAppearance.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryRemove.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryClear.Enabled = (dgvCategories.Rows.Count > 0);

            // labels
            var labels = _shapefile.Labels;

            //btnLabelsAppearance.Enabled = (labels.Count > 0);
            btnLabelsClear.Enabled = !labels.Empty;
            groupLabelAppearance.Enabled = !labels.Empty;
            groupLabelStyle.Enabled = !labels.Empty;
            chkShowLabels.Enabled = !labels.Empty;
            panelLabels.Enabled = !labels.Empty;
            groupChartAppearance.Enabled = _shapefile.Diagrams.Count > 0;

            // charts
            bool enabled = (_shapefile.Diagrams.Count > 0 && (_shapefile.Diagrams.Fields.Any()));
            groupChartAppearance.Enabled = enabled;
            btnClearCharts.Enabled = enabled;
            icbChartColorScheme.Enabled = enabled;
            groupCharts.Enabled = enabled;
            optChartBars.Enabled = enabled;
            optChartsPie.Enabled = enabled;
            chkChartsVisible.Enabled = enabled;
            btnChartsEditColorScheme.Enabled = enabled;
        }
        #endregion

        #region Utility
        /// <summary>
        /// Redraws the map if needed
        /// </summary>
        private void RedrawMap()
        {
            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            
            // it's assumed that we call redraw when state changed only
            if (!_noEvents && !_redrawModeIsChanging)
            {
                MarkStateChanged();
            }
        }

        /// <summary>
        /// Redraws legend
        /// </summary>
        private void RedrawLegend()
        {
            if (chkRedrawMap.Checked && !_noEvents)
            {
                _context.Legend.Redraw();
            }
        }

        /// <summary>
        /// Redraws preview windows on all tabs
        /// </summary>
        private void DrawAllPreviews()
        {
            DrawAppearancePreview();
            DrawLabelsPreview();
            DrawChartsPreview();
        }

        /// <summary>
        /// Updates color schemes list on the charts tab
        /// </summary>
        public void UpdateColorSchemes()
        {
            //icbChartColorScheme.ColorSchemes = Globals.ChartColors;
            //icbCategories.ColorSchemes = Globals.LayerColors;
        }

        /// <summary>
        /// Saves all the data before the closing
        /// </summary>
        private void frmSymbologyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                CancelChanges();
            }

            LockLegendAndMap(false);

            var lyr = _layer;
            if (lyr != null)
            {
                lyr.Name = txtLayerName.Text;
                _tabIndex = tabControl1.SelectedIndex;

                if (!chkRedrawMap.Checked)      // we presume here that the map is in actual state in case the checkbox is set
                {
                    _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                }

                _metadata.ShowLayerPreview = chkLayerPreview.Checked;
                _metadata.UpdateMapAtOnce = chkRedrawMap.Checked;
                _metadata.Comments = txtComments.Text;

                axMap1.Layers.RemoveWithoutClosing(0);
            }
        }

        #endregion

        #region Tooltips
        /// <summary>
        /// Adds tooltips t the controls. Resources should be used here to support internatianalization.
        /// </summary>
        private void AddTooltips()
        {
            // general tab
            toolTip1.SetToolTip(txtLayerName, "The name of layer. \nEditable. Can be different from the name of the source file");
            toolTip1.SetToolTip(txtLayerSource, "Source file information. Can be copied and pasted");
            toolTip1.SetToolTip(chkLayerVisible, "Toggles the visibility of the layer");
            toolTip1.SetToolTip(btnOk, "Closes the window. Saves the settings.");

            // appearance tab
            toolTip1.SetToolTip(pictureBox1, "Symbology used for the shapes which don't fall into any category. \nClick to change settings.");
            toolTip1.SetToolTip(btnDefaultChange, "Changes the default symbology");
            // categories
            toolTip1.SetToolTip(lstFields1, "List of fields from the attribute table");
            toolTip1.SetToolTip(udNumCategories, "Specifies the number of classes to be generated");
            toolTip1.SetToolTip(chkUniqueValues, "A separate category will be generated for every unique lock of the field");
            toolTip1.SetToolTip(icbCategories, "List of available color schemes. \nNew color schemes can be added by clicking <...> button");
            toolTip1.SetToolTip(chkSetGradient, "Sets color gradient for particular shapes");
            toolTip1.SetToolTip(chkRandomColors, "Chooses the colors from color scheme randomly");
            toolTip1.SetToolTip(btnChangeColorScheme, "Opens color schemes editor");
            toolTip1.SetToolTip(dgvCategories, "List of categories. \nClick on the preview to change settings." +
            "\nClick on the name to edit it.\nCount column displays number of shapes which fell in the category");

            toolTip1.SetToolTip(chkUseVariableSize, "Enables the graduated symbol size.\nApplicable for point layers only");
            toolTip1.SetToolTip(udMinSize, "Minimum size of symbols");
            toolTip1.SetToolTip(udMinSize, "Maximum size of symbols");
            toolTip1.SetToolTip(btnCategoryGenerate, "Generates categories and applies new settings");
            toolTip1.SetToolTip(btnCategoryAppearance, "Changes style of the selected category");
            toolTip1.SetToolTip(btnCategoryRemove, "Removes selected category");
            toolTip1.SetToolTip(btnCategoryClear, "Removes all categories");

            // TODO: should be written for the rest tabs
        }
        #endregion

        /// <summary>
        /// Reverts the changes and closes the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Cancels the changes made by user
        /// </summary>
        private void CancelChanges()
        {
            
            string state = _layer.Serialize();

            if (state != _initState)
            {
                // label and chart data must not be serialized
                var mode1 = _shapefile.Labels.SavingMode;
                var mode2 = _shapefile.Diagrams.SavingMode;

                _shapefile.Labels.SavingMode = PersistenceType.None;
                _shapefile.Diagrams.SavingMode = PersistenceType.None;

                bool res = _layer.Deserialize(_initState);

                _shapefile.Labels.SavingMode = mode1;
                _shapefile.Diagrams.SavingMode = mode2;

                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }

            LockLegendAndMap(false);
        }

        /// <summary>
        /// Saves the current changes treating them as the new initial state
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_stateChanged)
            {
                Ui2Settings(null, null);

                // triggering redraw
                //if (!chkRedrawMap.Checked)
                {
                    LockLegendAndMap(false);

                    _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                    Application.DoEvents();

                    LockLegendAndMap(true);
                }

                // saving new state
                _initState = SaveState();

                _stateChanged = false;
                btnSaveChanges.Enabled = false;

                _context.Project.SetModified();
            }
        }

        /// <summary>
        /// Applies the changes and closes the form
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_initState != SaveState())
            {
                _context.Project.SetModified();
            }

            LockLegendAndMap(false);
        }

        /// <summary>
        /// Saves the state in the m_InitState variable
        /// </summary>
        private string SaveState()
        {
            string state = "";
            
            // serializing for undo (label and chart data must not be serialized)
            var mode1 = _shapefile.Labels.SavingMode;
            var mode2 = _shapefile.Diagrams.SavingMode;

            _shapefile.Labels.SavingMode = PersistenceType.None;
            _shapefile.Diagrams.SavingMode = PersistenceType.None;

            state = _layer.Serialize();

            _shapefile.Labels.SavingMode = mode1;
            _shapefile.Diagrams.SavingMode = mode2;

            return state;
        }

        /// <summary>
        /// Sets visiblity of the layer
        /// </summary>
        private void chkLayerVisible_CheckedChanged(object sender, EventArgs e)
        {
            Ui2Settings(null, null);
        }

        /// <summary>
        /// Sets visiblity expression
        /// </summary>
        private void txtLayerExpression_TextChanged(object sender, EventArgs e)
        {
            Ui2Settings(null, null);
        }
    }
}
