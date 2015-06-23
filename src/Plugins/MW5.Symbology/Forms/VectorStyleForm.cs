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
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.Projections.UI.Forms;
using MW5.Services.Serialization;
using MW5.Shared;
using MW5.UI.Enums;
using MW5.UI.Forms;
using PathHelper = MW5.Shared.PathHelper;

namespace MW5.Plugins.Symbology.Forms
{
    /// <summary>
    /// UI for managing vector layer symbology and settings.
    /// </summary>
    public partial class VectorStyleForm : MapWindowForm
    {
        private static int _tabIndex = 0;
        private readonly ILegendLayer _layer;
        private readonly IFeatureSet _featureSet;
        private readonly SymbologyMetadata _metadata;
        private string _initState;
        private bool _stateChanged;
        private bool _lockUpdate;

        /// <summary>
        /// Creates new instance of the SymbologyMainForm class
        /// </summary>
        public VectorStyleForm(IAppContext context, ILegendLayer layer)
            : base(context)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layer == null) throw new ArgumentNullException("layer");
            
            InitializeComponent();

            _layer = layer;

            _metadata = SymbologyPlugin.GetMetadata(_layer.Handle);
            _featureSet = _layer.FeatureSet;

            Initialize();
        }

        private void Initialize()
        {
            MapConfig.ForceHideLabels = true;

            Text = "Layer properties: " + _layer.Name;

            LockLegendAndMap(true);

            _initState = SaveState();

            LockUpdate = true;

            InitGeneralTab();

            InitModeTab();

            InitAppearanceTab();

            InitCategoriesTab();

            InitLabelsTab();

            InitChartsTab();

            InitExpressionTab();

            UpdateColorSchemes();

            attributesControl1.Initialize(_featureSet);

            joinControl1.Initialize(_context, _featureSet.Table);

            joinControl1.JoinsChanged += () => attributesControl1.UpdateView();

            // the state should be set after the loading as otherwise we can trigger unnecessary redraws
            chkRedrawMap.Checked = _metadata.UpdateMapAtOnce;

            LockUpdate = false;

            // sets the enabled state of the controls
            RefreshControls();

            DrawAllPreviews();

            AddTooltips();

            tabControl1.SelectedIndex = _tabIndex;

            ColorSchemeProvider.SetFirstColorScheme(SchemeTarget.Vector, _featureSet);

            Shown += frmSymbologyMain_Shown;
        }

        public bool LockUpdate
        {
            get { return _lockUpdate; }
            set
            {
                _lockUpdate = value;
                dgvCategories.LockUpdate = _lockUpdate;
            }
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

            MapConfig.ForceHideLabels = false;
        }

        /// <summary>
        /// Sets the state of controls on the expression tab on loading
        /// </summary>
        private void InitExpressionTab()
        {
            txtLayerExpression.Text = _featureSet.VisibilityExpression;
        }
       
        #region Controls updating

        /// <summary>
        /// Updates shapefile settings according to the values of the controls 
        /// </summary>
        private void Ui2Settings(object sender, EventArgs e)
        {
            if (LockUpdate)
            {
                return;
            }

            _stateChanged = true;
            btnSaveChanges.Enabled = true;

            switch (tabControl1.SelectedTab.Name.ToLower())
            {
                case "tabmode":
                    _featureSet.CollisionMode = (CollisionMode)cboCollisionMode.SelectedIndex;
                    break;
                case "tabgeneral":
                    _layer.Visible = chkLayerVisible.Checked;
                    _layer.Name = txtLayerName.Text;
                    break;
                case "tabdefault":
                    Controls2Appearance();
                    break;
                case "tablabels":
                    UpdateLabels();
                    break;
                case "tabcharts":
                    UpdateCharts();
                    break;
            }

            dynamicVisibilityControl1.ApplyChanges();

            _featureSet.VisibilityExpression = txtLayerExpression.Text;

            RefreshControls();
            RedrawMap();
        }

        /// <summary>
        /// Changes the enabled properties of controls
        /// </summary>
        private void RefreshControlsState(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void RefreshControls()
        {
            if (LockUpdate)
                return;

            // appearance
            udDefaultSize.Enabled = _featureSet.PointOrMultiPoint;
            clpPointFill.Enabled = _featureSet.GeometryType == GeometryType.Polyline;
            clpSelection.Enabled = _featureSet.GeometryType == GeometryType.Polygon;

            // provide the options if there are a single line pattern, otherwise extednded options are needed
            IGeometryStyle options = _featureSet.Style;
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
            btnCategoryRemove.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryClear.Enabled = (dgvCategories.Rows.Count > 0);

            // labels
            var labels = _featureSet.Labels;

            //btnLabelsAppearance.Enabled = (labels.Count > 0);
            btnLabelsClear.Enabled = !labels.Empty;
            groupLabelAppearance.Enabled = !labels.Empty;
            groupLabelStyle.Enabled = !labels.Empty;
            chkShowLabels.Enabled = !labels.Empty;
            panelLabels.Enabled = !labels.Empty;
            groupChartAppearance.Enabled = _featureSet.Diagrams.Count > 0;

            // charts
            bool enabled = (_featureSet.Diagrams.Count > 0 && (_featureSet.Diagrams.Fields.Any()));
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
            if (!LockUpdate)
            {
                MarkStateChanged();
            }
        }

        /// <summary>
        /// Redraws legend
        /// </summary>
        private void RedrawLegend()
        {
            if (chkRedrawMap.Checked && !LockUpdate)
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
        /// Cancels the changes made by user
        /// </summary>
        private void CancelChanges()
        {
            string state = _layer.Serialize();

            if (state != _initState)
            {
                // label and chart data must not be serialized
                var mode1 = _featureSet.Labels.SavingMode;
                var mode2 = _featureSet.Diagrams.SavingMode;

                _featureSet.Labels.SavingMode = PersistenceType.None;
                _featureSet.Diagrams.SavingMode = PersistenceType.None;

                bool res = _layer.Deserialize(_initState);

                _featureSet.Labels.SavingMode = mode1;
                _featureSet.Diagrams.SavingMode = mode2;

                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }

            LockLegendAndMap(false);
        }

        /// <summary>
        /// Applies the changes and closes the form
        /// </summary>
        private void OnButtonOkClicked(object sender, EventArgs e)
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
            // serializing for undo (label and chart data must not be serialized)
            var mode1 = _featureSet.Labels.SavingMode;
            var mode2 = _featureSet.Diagrams.SavingMode;

            _featureSet.Labels.SavingMode = PersistenceType.None;
            _featureSet.Diagrams.SavingMode = PersistenceType.None;

            string state = _layer.Serialize();

            _featureSet.Labels.SavingMode = mode1;
            _featureSet.Diagrams.SavingMode = mode2;

            return state;
        }

        /// <summary>
        /// Sets visiblity of the layer
        /// </summary>
        private void OnLayerVisibleChecked(object sender, EventArgs e)
        {
            Ui2Settings(null, null);
        }

        /// <summary>
        /// Sets visiblity expression
        /// </summary>
        private void OnLayerExpressionTextChanged(object sender, EventArgs e)
        {
            Ui2Settings(null, null);
        }

        private void OnProjectionDetailsClick(object sender, EventArgs e)
        {
            using (var form = new ProjectionPropertiesForm(_layer.Projection))
            {
                _context.View.ShowChildView(form);
            }
        }

        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitAppearanceTab()
        {
            // default options
            var options = _featureSet.Style;

            groupPoint.MakeSameSize(groupFill);
            groupLine.MakeSameSize(groupFill);

            groupFill.Visible = false;
            groupLine.Visible = false;
            groupPoint.Visible = false;

            icbFillStyle.ComboStyle = ImageComboStyle.HatchStyleWithNone;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            var type = _featureSet.GeometryType;
            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                groupPoint.Visible = true;
                clpPointFill.Color = options.Fill.Color;
            }
            else if (type == GeometryType.Polyline)
            {
                groupLine.Visible = true;
            }
            else if (type == GeometryType.Polygon)
            {
                groupFill.Visible = true;
                clpPolygonFill.Color = options.Fill.Color;
            }

            Appearance2Controls();
        }

        /// <summary>
        /// Updating controls
        /// </summary>
        private void Appearance2Controls()
        {
            var options = _featureSet.Style;
            clpSelection.Color = _featureSet.SelectionColor;
            transpSelection.Value = _featureSet.SelectionTransparency;

            var type = _featureSet.GeometryType;
            switch (type)
            {
                case GeometryType.MultiPoint:
                case GeometryType.Point:
                    transpMain.Value = _featureSet.Style.Fill.Transparency;
                    clpPointFill.Color = options.Fill.Color;
                    udDefaultSize.SetValue(options.Marker.Size);
                    break;
                case GeometryType.Polyline:
                    transpMain.Value = _featureSet.Style.Line.Transparency;
                    icbLineWidth.SelectedIndex = (int)options.Line.Width - 1;
                    clpDefaultOutline.Color = options.Line.Color;
                    break;
                case GeometryType.Polygon:
                    clpPolygonFill.Color = _featureSet.Style.Fill.Color;
                    icbFillStyle.SelectedIndex = options.Fill.Type == FillType.Hatch ? (int)options.Fill.HatchStyle : 0;
                    break;
            }
        }

        /// <summary>
        /// Opens default drawing options
        /// </summary>
        private void OnDefaultDrawingOptionsClick(object sender, EventArgs e)
        {
            if (_context.ShowDefaultStyleDialog(_layer.Handle, true, this))
            {
                Appearance2Controls();

                DrawAllPreviews();

                Application.DoEvents();

                RedrawMap();

                RefreshControls();
            }
        }

        /// <summary>
        /// Draws preview on the appearance tab
        /// </summary>
        private void DrawAppearancePreview()
        {
            PictureBox pct = pictureBox1;
            var sdo = _featureSet.Style;

            if (pct.Image != null)
            {
                pct.Image.Dispose();
            }

            Rectangle rect = pct.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            if (_featureSet.PointOrMultiPoint)
            {
                sdo.DrawPoint(g, 0.0f, 0.0f, rect.Width, rect.Height, Color.White);
            }
            else if (_featureSet.GeometryType == GeometryType.Polyline)
            {
                if (sdo.Line.UsePattern)
                {
                    sdo.DrawLine(g, 20.0f, 0.0f, 0, 0, true, rect.Width - 40, rect.Height, Color.White);
                }
                else
                {
                    int w = rect.Width - 40;
                    int h = rect.Height - 40;
                    int x = Convert.ToInt32((rect.Width - w) / 2.0);
                    int y = Convert.ToInt32((rect.Height - h) / 2);
                    sdo.DrawLine(g, x, y, w, h, true, rect.Width, rect.Height, Color.White);
                }
            }
            else if (_featureSet.GeometryType == GeometryType.Polygon)
            {
                sdo.DrawRectangle(g, rect.Width / 2 - 40, rect.Height / 2 - 40, 80, 80, true, rect.Width, rect.Height, Color.White);
            }

            pct.Image = bmp;
        }

        /// <summary>
        /// Sets the properties of the labels based upon user input
        /// </summary>
        private void Controls2Appearance()
        {
            IGeometryStyle options = _featureSet.Style;

            if (_featureSet.GeometryType == GeometryType.Polygon)
            {
                options.Fill.Color = clpPolygonFill.Color;
                // hatch style is set in the corresponding event
            }
            else if (_featureSet.PointOrMultiPoint)
            {
                options.Fill.Color = clpPointFill.Color;
                options.Marker.Size = (float)udDefaultSize.Value;
            }
            else if (_featureSet.GeometryType == GeometryType.Polyline)
            {
                options.Line.Color = clpDefaultOutline.Color;
                options.Line.Width = (float)icbLineWidth.SelectedIndex + 1;

                // and pattern ones in case there is a single line pattern
                if (options.Line.UsePattern)
                {
                    if (options.Line.Pattern.Count == 1)
                    {
                        var line = options.Line.Pattern[0];
                        line.Color = options.Line.Color;
                        if (line.LineType == LineType.Simple)
                        {
                            line.LineWidth = options.Line.Width;
                        }
                    }
                }
            }

            _featureSet.SelectionColor = clpSelection.Color;
            _featureSet.SelectionTransparency = transpSelection.Value;

            DrawAppearancePreview();
        }

        /// <summary>
        /// Handles the change of transparency by user
        /// </summary>
        private void OnTransparencyMainChanged(object sender, byte value)
        {
            if (_featureSet.PointOrMultiPoint)
            {
                _featureSet.Style.Fill.Transparency = value;
                _featureSet.Style.Line.Transparency = value;
            }
            else if (_featureSet.IsPolyline)
            {
                _featureSet.Style.Line.Transparency = value;
            }
            else if (_featureSet.IsPolygon)
            {
                _featureSet.Style.Fill.Transparency = value;
                _featureSet.Style.Line.Transparency = value;
            }
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the changes of the selection transparency by user
        /// </summary>
        private void OnTransparencySelectionChanged(object sender, byte value)
        {
            _featureSet.SelectionTransparency = value;
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the changes of the fill type by user
        /// </summary>
        private void OnFillStyleChanged(object sender, EventArgs e)
        {
            if (LockUpdate)
            {
                return;
            }

            IGeometryStyle options = _featureSet.Style;
            if (icbFillStyle.SelectedIndex == 0 && options.Fill.Type == FillType.Hatch)
            {
                options.Fill.Type = FillType.Solid;
            }
            if (icbFillStyle.SelectedIndex > 0)
            {
                options.Fill.Type = FillType.Hatch;
                options.Fill.HatchStyle = (HatchStyle)icbFillStyle.SelectedIndex - 1;
            }
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the change of selection color
        /// </summary>
        private void OnSelectedColorChanged(object sender, EventArgs e)
        {
            _featureSet.SelectionColor = clpSelection.Color;
            transpSelection.BandColor = clpSelection.Color;
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Initializes the categories tab
        /// </summary>
        private void InitCategoriesTab()
        {
            dgvCategories.StyleClicked += (s, e) => OnCategoryAppearanceClick(null, null);
            dgvCategories.CategoryNameChanged += (s, e) => RedrawLegend();
            dgvCategories.Initialize(_featureSet);

            icbCategories.ComboStyle = SchemeType.Graduated;
            icbCategories.SchemeTarget = SchemeTarget.Vector;
            if (icbCategories.Items.Count > 0)
            {
                icbCategories.SelectedIndex = 0;
            }

            // layer settings
            chkSetGradient.Checked = _metadata.CategoriesUseGradient;
            chkRandomColors.Checked = _metadata.CategoriesRandomColors;
            udNumCategories.Value = _metadata.CategoriesCount;
            chkUniqueValues.Checked = _metadata.CategoriesClassification == Classification.UniqueValues;
            chkUseVariableSize.Checked = _metadata.CategoriesVariableSize;

            // fills in the list of fields
            FillFieldList(_metadata.CategoriesFieldName);

            // setting the color scheme that is in use
            icbCategories.SetSelectedItem(_metadata.CategoriesColorScheme);

            var type = _featureSet.GeometryType;
            groupVariableSize.Visible = (type == GeometryType.Point || type == GeometryType.Polyline);

            if (type == GeometryType.Point)
            {
                udMinSize.SetValue(_featureSet.Style.Marker.Size);
            }
            else if (type == GeometryType.Polyline)
            {
                udMinSize.SetValue(_featureSet.Style.Line.Width);
            }
            udMaxSize.SetValue((double)udMinSize.Value + _metadata.CategoriesSizeRange);

            RefreshCategoriesList();

            if (dgvCategories.Rows.Count > 0 && dgvCategories.Columns.Count > 0)
            {
                dgvCategories[0, 0].Selected = true;
            }
        }

        /// <summary>
        /// Generates shapefile categories
        /// </summary>
        private void OnGenerateCategoriesClick(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(udNumCategories.Value);
            var categories = _featureSet.Categories;

            if (lstFields1.SelectedItem == null) return;
            string name = lstFields1.SelectedItem.ToString().ToLower().Trim();

            int index = _featureSet.Fields.IndexByName(name);

            if (index == -1)
            {
                return;
            }

            var classification = chkUniqueValues.Checked ? Classification.UniqueValues : Classification.NaturalBreaks;

            // preventing the large number of categories
            bool showWaiting = false;
            if (classification == Classification.UniqueValues)
            {
                var set = new HashSet<object>();
                for (int i = 0; i < _featureSet.Features.Count; i++)
                {
                    object val = _featureSet.Table.CellValue(index, i);
                    set.Add(val);
                }

                if (set.Count > 300)
                {
                    showWaiting = true;
                    string s = string.Format("The chosen field = {1}.\nThe number of unique values = {0}.\n" +
                    "Large number of categories negatively affects performance.\nDo you want to continue?", set.Count, "[" + name.ToUpper() + "]");

                    if (!MessageService.Current.Ask(s))
                    {
                        return;
                    }
                }
                set.Clear();
            }

            if (showWaiting)
            {
                Enabled = false;
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                btnCategoryGenerate.Enabled = false;
            }

            // generating
            categories.Generate(index, classification, count);
            categories.Caption = "Categories: " + _featureSet.Fields[index].Name;
            ApplyColorScheme2Categories();

            if (chkUseVariableSize.Checked)
            {
                ApplyVariablePointSize();
            }

            _featureSet.Categories.ApplyExpressions();

            RefreshCategoriesList();
            RedrawMap();

            // saving the settings
            _metadata.CategoriesClassification = classification;
            _metadata.CategoriesFieldName = name;
            _metadata.CategoriesSizeRange = (int)(udMaxSize.Value - udMinSize.Value);
            _metadata.CategoriesCount = (int)udNumCategories.Value;
            _metadata.CategoriesRandomColors = chkRandomColors.Checked;
            _metadata.CategoriesUseGradient = chkSetGradient.Checked;
            _metadata.CategoriesVariableSize = chkUseVariableSize.Checked;

            // cleaning
            if (showWaiting)
            {
                Enabled = true;
                Cursor = Cursors.Default;
            }
            else
            {
                btnCategoryGenerate.Enabled = true;
            }

            RefreshControls();
            MarkStateChanged();
        }

        private void RefreshCategoriesList()
        {
            dgvCategories.RefreshList();
            RefreshControls();
        }

        /// <summary>
        /// Sets the changed flag to the layer state
        /// </summary>
        private void MarkStateChanged()
        {
            _stateChanged = true;
            btnSaveChanges.Enabled = true;
        }

        /// <summary>
        /// Toggles between unique values and natural breaks. Natural break are available for numeric fields only.
        /// </summary>
        private void OnUniqueValuesChecked(object sender, EventArgs e)
        {
            FillFieldList(string.Empty);
        }

        /// <summary>
        /// Sets symbols with variable size for point categories 
        /// </summary>
        private void ApplyVariablePointSize()
        {
            if (chkUseVariableSize.Checked && (udMinSize.Value != udMaxSize.Value))
            {
                var categories = _featureSet.Categories;
                if (_featureSet.PointOrMultiPoint)
                {
                    double step = (double)(udMaxSize.Value - udMinSize.Value) / ((double)categories.Count - 1);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories[i].Style.Marker.Size = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
                else if (_featureSet.GeometryType == GeometryType.Polyline)
                {
                    double step = (double)(udMaxSize.Value + udMinSize.Value) / (double)categories.Count;
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories[i].Style.Line.Width = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
            }
        }

        /// <summary>
        /// Toggles between random and graduated colors schemes
        /// </summary>
        private void OnRandomColorsChecked(object sender, EventArgs e)
        {
            int index = icbCategories.SelectedIndex;
            icbCategories.ComboStyle = chkRandomColors.Checked ? SchemeType.Random : SchemeType.Graduated;

            if (index >= 0 && index < icbCategories.Items.Count)
            {
                icbCategories.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Applies color scheme chosen in the image combo to categories
        /// </summary>
        private void ApplyColorScheme2Categories()
        {
            if (_featureSet.Categories.Count == 0)
            {
                return;
            }

            _metadata.CategoriesColorScheme = icbCategories.GetSelectedItem();
            var scheme = _metadata.CategoriesColorScheme.ToColorScheme();

            _featureSet.Categories.ApplyColorScheme(chkRandomColors.Checked ? SchemeType.Random : SchemeType.Graduated, scheme);

            var categories = _featureSet.Categories;
            if (chkSetGradient.Checked)
            {
                foreach (var options in categories.Select(t => t.Style))
                {
                    options.Fill.SetGradient(options.Fill.Color, 75);
                    options.Fill.Type = FillType.Gradient;
                }
            }
            else
            {
                var color = _featureSet.Style.Fill.Color2;

                foreach (IGeometryStyle options in categories.Select(t => t.Style))
                {
                    options.Fill.Color2 = color;
                    options.Fill.Type = FillType.Solid;
                }
            }
        }

        /// <summary>
        /// Removes selected category
        /// </summary>
        private void OnCategoryRemoveClick(object sender, EventArgs e)
        {
            dgvCategories.RemoveSelectedCategory();

            RedrawMap();
        }

        /// <summary>
        /// Shows form to chnage visualization of the given category
        /// </summary>
        private void OnCategoryAppearanceClick(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                ChangeCategoryStyle(dgvCategories.CurrentRow.Index);
            }
        }

        /// <summary>
        /// Removes all the categories in the list
        /// </summary>
        private void OnCategoryClearClick(object sender, EventArgs e)
        {
            _featureSet.Categories.Clear();
            RefreshCategoriesList();

            _metadata.CategoriesClassification = chkUniqueValues.Checked ? Classification.UniqueValues : Classification.NaturalBreaks;

            RedrawMap();
        }

        /// <summary>
        /// Changes the style of the selected category
        /// </summary>
        private void ChangeCategoryStyle(int row)
        {
            var cat = _featureSet.Categories[row];

            if (cat == null) return;

            using (Form form = _context.GetSymbologyForm(_layer.Handle, cat.Style, true))
            {
                form.Text = "Category drawing options";

                if (_context.View.ShowChildView(form))
                {
                    dgvCategories.Invalidate();
                    RedrawMap();
                }
            }
        }

        /// <summary>
        /// Fills the list of fields
        /// </summary>
        private void FillFieldList(string name)
        {
            if (name == string.Empty)
            {
                // we need to preserve currently selected field
                name = lstFields1.SelectedItem != null ? lstFields1.SelectedItem.ToString().Trim() : string.Empty;
            }
            // else  = we need some particular field as selected

            lstFields1.Items.Clear();

            // adding names
            foreach (var fld in _featureSet.Fields)
            {
                if (!chkUniqueValues.Checked && fld.Type == AttributeType.String ||
                     chkUniqueValues.Checked && fld.Type != AttributeType.String)
                {
                    continue;
                }

                lstFields1.Items.Add("  " + fld.Name);
            }

            // setting the selected field back
            if (name != string.Empty)
            {
                for (int i = 0; i < lstFields1.Items.Count; i++)
                {
                    if (lstFields1.Items[i].ToString().ToLower().Trim() == name.ToLower())
                    {
                        lstFields1.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (lstFields1.SelectedItem == null && lstFields1.Items.Count > 0)
            {
                lstFields1.SelectedIndex = 0;
            }
            RefreshControls();
        }

        /// <summary>
        /// Opens the editor of color schemes
        /// </summary>
        private void btnChangeColorScheme_Click(object sender, EventArgs e)
        {
            using (var form = new ColorSchemesForm(_context, icbCategories.ColorSchemes))
            {
                _context.View.ShowChildView(form, this);
            }
        }

        /// <summary>
        /// The code for initialization of the charts tab
        /// </summary>
        private void InitChartsTab()
        {
            icbChartColorScheme.ComboStyle = SchemeType.Graduated;
            icbChartColorScheme.SchemeTarget = SchemeTarget.Charts;
            if (icbChartColorScheme.Items.Count > 0)
            {
                icbChartColorScheme.SelectedIndex = 0;
            }

            var charts = _featureSet.Diagrams;
            chkChartsVisible.Checked = charts.Visible;

            optChartBars.Checked = (charts.DiagramType == DiagramType.Bar);
            optChartsPie.Checked = (charts.DiagramType == DiagramType.Pie);
        }

        /// <summary>
        ///  Draws preview on the charts tab
        /// </summary>
        private void DrawChartsPreview()
        {
            var rect = pctCharts.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var charts = _featureSet.Diagrams;
            if (charts.Count > 0 && charts.Fields.Any())
            {
                var g = Graphics.FromImage(bmp);

                int x = Convert.ToInt32((rect.Width - charts.IconWidth) / 2.0);
                int y = Convert.ToInt32((rect.Height - charts.IconHeight) / 2.0);
                _featureSet.Diagrams.DrawChart(g, x, y, false, Color.White);
            }

            pctCharts.Image = bmp;
        }

        /// <summary>
        /// Opens form to change chart appearance
        /// </summary>
        private void OnChartAppearanceClick(object sender, EventArgs e)
        {
            using (var form = new ChartStyleForm(_context, _layer))
            {
                _context.View.ShowChildView(form, this);
            }

            // even if cancel was hit, a user could have applied the options
            bool state = LockUpdate;
            LockUpdate = true;
            optChartBars.Checked = _featureSet.Diagrams.DiagramType == DiagramType.Bar;
            optChartsPie.Checked = _featureSet.Diagrams.DiagramType == DiagramType.Pie;
            LockUpdate = state;

            DrawChartsPreview();
            RefreshControls();
            RedrawMap();
        }

        /// <summary>
        /// Removes all chart fields and redraws the map
        /// </summary>
        private void OnClearChartsClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Do you want to delete charts?"))
            {
                _featureSet.Diagrams.Fields.Clear();
                _featureSet.Diagrams.Clear();
                RefreshControls();
                DrawChartsPreview();
                RedrawMap();
            }
        }

        /// <summary>
        /// Updating colors of the charts
        /// </summary>
        private void OnChartColorSchemeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (icbChartColorScheme.ColorSchemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                Ui2Settings(null, null);
                DrawChartsPreview();
                RedrawMap();
            }
        }

        /// <summary>
        /// Sets the properties of the labels based upon user input
        /// </summary>
        private void UpdateCharts()
        {
            var charts = _featureSet.Diagrams;
            charts.Visible = chkChartsVisible.Checked;
            charts.DiagramType = optChartBars.Checked ? DiagramType.Bar : DiagramType.Pie;
            UpdateFieldColors();
            DrawChartsPreview();
        }

        private void UpdateFieldColors()
        {
            var schemes = icbChartColorScheme.ColorSchemes;
            if (schemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                var blend = schemes[icbChartColorScheme.SelectedIndex];
                var scheme = blend.ToColorScheme();
                if (scheme != null)
                {
                    int fieldCount = _featureSet.Diagrams.Fields.Count;
                    for (int i = 0; i < fieldCount; i++)
                    {
                        var field = _featureSet.Diagrams.Fields[i];
                        double value = i / (double)(fieldCount - 1);
                        field.Color = scheme.GetGraduatedColor(value);
                    }
                }
            }
        }

        /// <summary>
        /// Opens editor of color schemes
        /// </summary>
        private void OnChartsEditColorSchemeClick(object sender, EventArgs e)
        {
            using (var form = new ColorSchemesForm(_context, icbChartColorScheme.ColorSchemes))
            {
                _context.View.ShowChildView(form, this);
            }
        }

        /// <summary>
        /// Building layer visibility expression
        /// </summary>
        private void OnLayerExpressionClick(object sender, EventArgs e)
        {
            string s = txtLayerExpression.Text;

            if (FormHelper.ShowQueryBuilder(_context, _layer, this, ref s, false))
            {
                txtLayerExpression.Text = s;
                _featureSet.VisibilityExpression = txtLayerExpression.Text;
                RedrawMap();
            }
        }

        /// <summary>
        /// Clears the layer expression
        /// </summary>
        private void btnClearLayerExpression_Click(object sender, EventArgs e)
        {
            txtLayerExpression.Clear();
            _featureSet.VisibilityExpression = "";
            RedrawMap();
        }

        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitGeneralTab()
        {
            chkLayerVisible.Checked = _layer.Visible;
            chkLayerPreview.Checked = _metadata.ShowLayerPreview;

            txtLayerName.Text = _layer.Name;

            txtDatasourceName.Text = _layer.Filename;

            txtProjection.Text = _layer.Projection.IsEmpty ? "<not defined>" : _layer.Projection.Name;

            txtComments.Text = _layer.Description;

            dynamicVisibilityControl1.Initialize(_layer, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            dynamicVisibilityControl1.ValueChanged += (s, e) => MarkStateChanged();

            PopulateBriefInfo();

            vectorInfoTreeView1.Initialize(_layer);
        }

        private void PopulateBriefInfo()
        {
            int numFeatures = _featureSet.Features.Count;
            var type = _featureSet.GeometryType.EnumToString().ToLower();
            txtBriefInfo.Text = string.Format("Feature count: {0}; geometry type: {1}", numFeatures, type);
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnLayerNameValidated(object sender, EventArgs e)
        {
            _layer.Name = txtLayerName.Text;
            MarkStateChanged();
            RedrawLegend();
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnLayerNameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _layer.Name = txtLayerName.Text;
                MarkStateChanged();
                RedrawLegend();
            }
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnCommentsValidated(object sender, EventArgs e)
        {
            _layer.Description = txtComments.Text;
            MarkStateChanged();
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnCommentsKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _layer.Description = txtComments.Text;
                MarkStateChanged();
            }
        }

        /// <summary>
        /// Updates the state of the layer preview
        /// </summary>
        private void OnLayerPreviewChecked(object sender, EventArgs e)
        {
            if (axMap1.Layers.Count == 0 && chkLayerPreview.Checked)
            {
                ShowLayerPreview();
            }
            axMap1.Visible = chkLayerPreview.Checked;

        }

        /// <summary>
        /// Refreshes the layer preview
        /// </summary>
        private void ShowLayerPreview()
        {
            bool val = MapConfig.LoadSymbologyOnAddLayer;
            MapConfig.LoadSymbologyOnAddLayer = false;

            axMap1.ShowCoordinates = CoordinatesDisplay.None;
            axMap1.ScalebarVisible = false;
            axMap1.Visible = true;
            axMap1.ZoomBar.Visible = false;
            axMap1.TileProvider = TileProvider.None;
            axMap1.MapCursor = MapCursor.None;
            axMap1.MouseWheelSpeed = 1.0;
            axMap1.ZoomBehavior = ZoomBehavior.Default;
            int handle = axMap1.Layers.Add(_featureSet, true);
            axMap1.ZoomToLayer(handle);

            MapConfig.LoadSymbologyOnAddLayer = val;
        }

        /// <summary>
        /// Initializes labels tab
        /// </summary>
        private void InitLabelsTab()
        {
            var lb = _featureSet.Labels;
            chkShowLabels.Checked = lb.Visible;

            chkLabelFrame.Checked = lb.Style.FrameVisible;
            clpLabelFrame.Color = lb.Style.FrameBackColor;
            udLabelFontSize.SetValue(lb.Style.FontSize);
        }

        /// <summary>
        /// Updates preview of the labels
        /// </summary>
        private void DrawLabelsPreview()
        {
            LabelHelper.DrawPreview(_featureSet.Labels.Style, _featureSet, pctLabelPreview, false);
        }

        /// <summary>
        /// Changing the default style of labels
        /// </summary>
        private void OnLabelsAppearanceClick(object sender, EventArgs e)
        {
            using (var form = new LabelStyleForm(_context, _layer))
            {
                _context.View.ShowChildView(form, this);
            }

            // updating controls (even if cancel was hit, a user could have applied the options)
            var options = _featureSet.Labels.Style;
            udLabelFontSize.Value = options.FontSize;
            clpLabelFrame.Color = options.FrameBackColor;
            chkLabelFrame.Checked = options.FrameVisible;
            chkShowLabels.Checked = options.Visible;

            RefreshControls();

            RedrawMap();

            // refreshing preview
            DrawLabelsPreview();
        }

        /// <summary>
        /// Deletes all the labels
        /// </summary>
        private void OnLabelsClearClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Do you want to delete labels?"))
            {
                _featureSet.Labels.Items.Clear();
                _featureSet.Labels.Expression = "";
                DrawLabelsPreview();
                RefreshControls();
                RedrawMap();
            }
        }

        /// /// <summary>
        /// Changes label font size. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFontSizeValueChanged(object sender, EventArgs e)
        {
            if (LockUpdate)
            {
                return;
            }

            _featureSet.Labels.Style.FontSize = (int)udLabelFontSize.Value;
            DrawLabelsPreview();
            RedrawMap();
        }

        /// <summary>
        /// Changes label frame color. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFrameColorChanged(object sender, EventArgs e)
        {
            if (LockUpdate)
                return;

            _featureSet.Labels.Style.FrameBackColor = clpLabelFrame.Color;
            DrawLabelsPreview();
            RedrawMap();
        }

        /// <summary>
        /// Changes label frame visiblity. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFrameChecked(object sender, EventArgs e)
        {
            if (LockUpdate)
                return;

            _featureSet.Labels.Style.FrameVisible = chkLabelFrame.Checked;
            DrawLabelsPreview();
            RedrawMap();
        }

        /// <summary>
        /// Sets the properties of the labels based upon user input
        /// </summary>
        private void UpdateLabels()
        {
            var lb = _featureSet.Labels;
            lb.Visible = chkShowLabels.Checked;

            DrawLabelsPreview();
        }

        /// <summary>
        /// Creates spatial index for the shapefile. Toggles it's usage.
        /// </summary>
        private void OnSpatialIndexChecked(object sender, EventArgs e)
        {
            if (LockUpdate)
            {
                return;
            }

            if (chkSpatialIndex.Checked)
            {
                if (!_featureSet.SpatialIndex.DiskIndexExists)
                {
                    Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    if (_featureSet.SpatialIndex.CreateDiskIndex())
                    {
                        MessageService.Current.Info("Spatial index was successfully created");
                    }
                    Enabled = true;
                    Cursor = Cursors.Default;
                }
                else
                {
                    _featureSet.SpatialIndex.UseDiskIndex = true;
                }
            }
            else
            {
                _featureSet.SpatialIndex.UseDiskIndex = false;
            }

            RedrawMap();
        }

        private void OnModeMouseMove(object sender, MouseEventArgs e)
        {
            OnModeEnter(sender, null);
        }

        private void OnModeEnter(object sender, EventArgs e)
        {
            string s = string.Empty;
            if (sender == chkInMemory)
            {
                s += "In memory: shapefile data is current loaded into RAM.";
            }
            else if (sender == chkEditMode)
            {
                s += "Editing mode: starts or stops the editing session for the shapefile. The changes can be saved or discarded while closing.";
            }
            else if (sender == chkFastMode)
            {
                s += "Fast mode: loads shape data in the memory for faster drawing. There are certain limitations when using it coupled with editing mode.";
            }
            else if (sender == chkSpatialIndex)
            {
                s += "Spatial index: creates R-tree for faster search. Affects drawing and selection at close scales. Creates 2 files with .mwd and .mwx extentions in the shapefile folder. Isn't used for editing mode.";
            }
            else if (sender == udMinDrawingSize)
            {
                s += "Minimal drawing size: if the size polyline or polygon at current scale in pixels is less than this value, it will be drawn as a single dot.";
            }
            else if (sender == udMinLabelingSize)
            {
                s += "Minimal labeling size: a polygon or polyline will be labeled only if it's size in pixels greater than this value.";
            }
            else if (sender == cboCollisionMode)
            {
                s += "Collision mode: detemines whether point symbols can be drawn one above the another. Also if the collisions of points with labels are allowed.";
            }

            txtModeDescription.Text = s;

            var font = new Font("Arial", 10.0f);
            txtModeDescription.SelectAll();
            txtModeDescription.SelectionFont = font;

            string[] str = { "Fast mode:", "Editing mode:", "In memory:", "Spatial index:", "Minimal drawing size: ", "Minimal labeling size:", "GDI mode for labels:", "Collision mode" };
            font = new Font("Arial", 10.0f, FontStyle.Bold);

            foreach (string t in str)
            {
                int position = txtModeDescription.Text.IndexOf(t, StringComparison.Ordinal);
                if (position >= 0)
                {
                    txtModeDescription.Select(position, t.Length);
                    txtModeDescription.SelectionFont = font;
                }
            }
        }

        private void OnSaveStyleClick(object sender, EventArgs e)
        {
            LayerSerializationHelper.SaveSettings(_layer);
        }

        private void btnOpenLocation_Click(object sender, EventArgs e)
        {
            string filename = _featureSet.Filename;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                PathHelper.OpenFolderWithExplorer(filename);
            }
            else
            {
                MessageService.Current.Info("Can't find the datasource.");
            }
        }

        private void OnRemoveStyleClick(object sender, EventArgs e)
        {
            LayerSerializationHelper.RemoveSettings(_layer, false);
        }

        #region TODO

        /// <summary>
        /// Changes the minimum size of object in pixels to be drawn
        /// </summary>
        private void udMinDrawingSizeChanged(object sender, EventArgs e)
        {
            //_shapefile.MinDrawingSize = (int)udMinDrawingSize.Value;
            RedrawMap();
        }

        /// <summary>
        /// Changes the minimum size of the object to label
        /// </summary>
        private void OnMinLabelingSizeChanged(object sender, EventArgs e)
        {
            //_shapefile.Labels.MinDrawingSize = (int)udMinLabelingSize.Value;
            RedrawMap();
        }

        private void OnRedrawMapChecked(object sender, EventArgs e)
        {
            //if (_noEvents) return;

            if (!chkRedrawMap.Checked)
            {
                //m_mapWin.View.LockMap();
                //Globals.Legend.Lock();
            }
            else
            {
                //m_mapWin.View.UnlockMap();
                //Globals.Legend.Unlock();
            }

            //_redrawModeIsChanging = true;
            //Ui2Settings(null, null);
            //RedrawMap();
            //_redrawModeIsChanging = false;
        }

        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitModeTab()
        {
            if (_featureSet.GeometryType == GeometryType.Point)
            {
                cboCollisionMode.Enabled = true;
                cboCollisionMode.Items.Clear();
                cboCollisionMode.Items.Add("Allow collisions");
                cboCollisionMode.Items.Add("Avoid point vs point collisions");
                cboCollisionMode.Items.Add("Avoid point vs label collisions");
                cboCollisionMode.SelectedIndex = (int)_featureSet.CollisionMode;
            }
            else
            {
                cboCollisionMode.Enabled = false;
            }

            chkSpatialIndex.Checked = _featureSet.SpatialIndex.UseDiskIndex && _featureSet.SpatialIndex.DiskIndexValid;
            chkInMemory.Checked = _featureSet.EditingShapes;
            chkEditMode.Checked = _featureSet.InteractiveEditing;

            // TODO: restore
            //chkFastMode.Checked = _shapefile.FastMode;
            //udMinDrawingSize.SetValue((double)_shapefile.MinDrawingSize);
            //udMinLabelingSize.SetValue((double)_shapefile.Labels.MinDrawingSize);

            // displaying help string default help
            OnModeEnter(chkFastMode, null);
        }

        /// <summary>
        /// Saves the current changes treating them as the new initial state
        /// </summary>
        private void OnSaveChangesClick(object sender, EventArgs e)
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
        /// Updates color schemes list on the charts tab
        /// </summary>
        public void UpdateColorSchemes()
        {
            //icbChartColorScheme.ColorSchemes = Globals.ChartColors;
            //icbCategories.ColorSchemes = Globals.LayerColors;
        }
        #endregion
    }
}
