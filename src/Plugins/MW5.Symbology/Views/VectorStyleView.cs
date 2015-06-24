// -------------------------------------------------------------------------------------------
// <copyright file="VectorStyleView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    /// <summary>
    /// UI for managing vector layer symbology and settings.
    /// </summary>
    public partial class VectorStyleView : VectorStyleViewBase, IVectorStyleView
    {
        private static int _tabIndex;
        private readonly CategoriesPresenter _categoriesPresenter;
        private readonly IAppContext _context;
        private IFeatureSet _featureSet;
        private string _initState;
        private bool _lockUpdate;
        private SymbologyMetadata _metadata;
        private bool _stateChanged;

        public VectorStyleView(IAppContext context, CategoriesPresenter categoriesPresenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (categoriesPresenter == null) throw new ArgumentNullException("categoriesPresenter");

            _context = context;
            _categoriesPresenter = categoriesPresenter;

            InitializeComponent();

            InitCategoriesSubView();

            cboCollisionMode.AddItemsFromEnum<CollisionMode>();
        }

        public event Action ModifyCharts;

        public event Action ModifyLabels;

        public event Action UpdateSpatialIndex;

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnOpenLocation;
                yield return btnProjectionDetails;
                yield return btnChartAppearance;
                yield return btnChartsEditColorScheme;
                yield return btnClearCharts;
                yield return btnChangeVisibilityExpression;
                yield return btnLabelAppearance;
                yield return btnClearLabels;
                yield return btnClearVisibilityExpression;
            }
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        public bool SpatialIndex
        {
            get { return chkSpatialIndex.Checked; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return toolStyle.DropDownItems; }
        }

        public void Initialize()
        {
            _metadata = SymbologyPlugin.GetMetadata(Model.Handle);
            _featureSet = Model.FeatureSet;

            var model = new CategoriesSubViewModel(Model, _metadata);
            _categoriesPresenter.Initialize(model);

            MapConfig.ForceHideLabels = true;

            Text = "Layer properties: " + Model.Name;

            _initState = SaveState();

            InitializeCore();

            ColorSchemeProvider.SetFirstColorScheme(SchemeTarget.Vector, _featureSet);

            Shown += OnFormShown;
        }

        public void LockView()
        {
            _lockUpdate = true;
            Enabled = false;
            Cursor = Cursors.WaitCursor;
        }

        public void RefreshCharts()
        {
            // even if cancel was hit, a user could have applied the options
            bool state = _lockUpdate;

            _lockUpdate = true;
            optChartBars.Checked = _featureSet.Diagrams.DiagramType == DiagramType.Bar;
            optChartsPie.Checked = _featureSet.Diagrams.DiagramType == DiagramType.Pie;
            _lockUpdate = state;

            DrawChartsPreview();
            RefreshControls();
            RedrawMap();
        }

        public void RefreshLabels()
        {
            // updating controls (even if cancel was hit, a user could have applied the options)
            var options = _featureSet.Labels.Style;
            udLabelFontSize.Value = options.FontSize;
            clpLabelFrame.Color = options.FrameBackColor;
            chkLabelFrame.Checked = options.FrameVisible;
            chkShowLabels.Checked = options.Visible;

            UpdateView();

            DrawLabelsPreview();
        }

        public void UnlockView()
        {
            _lockUpdate = false;
            Enabled = true;
            Cursor = Cursors.Default;
        }

        public override void UpdateView()
        {
            RefreshControls();
            RedrawMap();
        }

        private void AddTooltips()
        {
            // general tab
            toolTip1.SetToolTip(txtLayerName, "The name of layer. \nEditable. Can be different from the name of the source file.");
            toolTip1.SetToolTip(chkLayerVisible, "Toggles the visibility of the layer.");
            toolTip1.SetToolTip(btnOk, "Closes the window. Saves the settings.");

            // appearance tab
            toolTip1.SetToolTip(pictureBox1, "Symbology used for the shapes which don't fall into any category.");
        }

        /// <summary>
        /// Cancels the changes made by user
        /// </summary>
        private void CancelChanges()
        {
            string state = Model.Serialize();

            if (state != _initState)
            {
                // label and chart data must not be serialized
                var mode1 = _featureSet.Labels.SavingMode;
                var mode2 = _featureSet.Diagrams.SavingMode;

                _featureSet.Labels.SavingMode = PersistenceType.None;
                _featureSet.Diagrams.SavingMode = PersistenceType.None;

                Model.Deserialize(_initState);

                _featureSet.Labels.SavingMode = mode1;
                _featureSet.Diagrams.SavingMode = mode2;

                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }

            LockLegendAndMap(false);
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
        /// Draws preview on the appearance tab
        /// </summary>
        private void DrawAppearancePreview()
        {
            var pct = pictureBox1;
            var sdo = _featureSet.Style;

            if (pct.Image != null)
            {
                pct.Image.Dispose();
            }

            var rect = pct.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);

            switch (_featureSet.GeometryType)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    sdo.DrawPoint(g, 0.0f, 0.0f, rect.Width, rect.Height, Color.White);
                    break;
                case GeometryType.Polyline:
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
                    break;
                case GeometryType.Polygon:
                    sdo.DrawRectangle(g, rect.Width / 2 - 40, rect.Height / 2 - 40, 80, 80, true, rect.Width, rect.Height, Color.White);
                    break;
            }

            pct.Image = bmp;
        }

        /// <summary>
        ///  Draws preview on the charts tab
        /// </summary>
        private void DrawChartsPreview()
        {
            var rect = pctCharts.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);

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
        /// Updates preview of the labels
        /// </summary>
        private void DrawLabelsPreview()
        {
            LabelHelper.DrawPreview(_featureSet.Labels.Style, _featureSet, pctLabelPreview, false);
        }

        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitAppearanceTab()
        {
            if (_featureSet.GeometryType == GeometryType.Point)
            {
                cboCollisionMode.Enabled = true;

                cboCollisionMode.SetValue(_featureSet.CollisionMode);
            }
            else
            {
                cboCollisionMode.Enabled = false;
            }

            chkSpatialIndex.Checked = _featureSet.SpatialIndex.UseDiskIndex && _featureSet.SpatialIndex.DiskIndexValid;
            chkEditMode.Checked = _featureSet.InteractiveEditing;

            udMinDrawingSize.SetValue(_featureSet.MinDrawingSize);
            udMinLabelingSize.SetValue(_featureSet.Labels.MinDrawingSize);
        }

        private void InitCategoriesSubView()
        {
            tabCategories.Controls.Clear();
            tabCategories.Controls.Add(_categoriesPresenter.View);
            _categoriesPresenter.View.Left = 15;
            _categoriesPresenter.View.Top = 15;
            _categoriesPresenter.LockView += LockView;
            _categoriesPresenter.UnlockView += UnlockView;
            _categoriesPresenter.RedrawMap += RedrawMap;
            _categoriesPresenter.RedrawLegend += RedrawLegend;
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
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitGeneralTab()
        {
            chkLayerVisible.Checked = Model.Visible;
            chkLayerPreview.Checked = _metadata.ShowLayerPreview;

            txtLayerName.Text = Model.Name;

            txtDatasourceName.Text = Model.Filename;

            txtProjection.Text = Model.Projection.IsEmpty ? "<not defined>" : Model.Projection.Name;

            txtComments.Text = Model.Description;

            dynamicVisibilityControl1.Initialize(Model, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            dynamicVisibilityControl1.ValueChanged += (s, e) => MarkStateChanged();

            int numFeatures = _featureSet.Features.Count;
            var type = _featureSet.GeometryType.EnumToString().ToLower();
            txtBriefInfo.Text = string.Format("Feature count: {0}; geometry type: {1}", numFeatures, type);

            vectorInfoTreeView1.Initialize(Model);
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

        private void InitializeCore()
        {
            LockLegendAndMap(true);

            _lockUpdate = true;

            InitGeneralTab();

            InitAppearanceTab();

            InitLabelsTab();

            InitChartsTab();

            txtLayerExpression.Text = _featureSet.VisibilityExpression;

            attributesControl1.Initialize(_featureSet);

            joinControl1.Initialize(_context, _featureSet.Table);

            joinControl1.JoinsChanged += () => attributesControl1.UpdateView();

            _lockUpdate = false;

            // sets the enabled state of the controls
            RefreshControls();

            DrawAllPreviews();

            AddTooltips();

            tabControl1.SelectedIndex = _tabIndex;
        }

        private void LockLegendAndMap(bool state)
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

        /// <summary>
        /// Sets the changed flag to the layer state
        /// </summary>
        private void MarkStateChanged()
        {
            _stateChanged = true;
            btnApply.Enabled = true;
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
        /// Updating colors of the charts
        /// </summary>
        private void OnChartColorSchemeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (icbChartColorScheme.ColorSchemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                RefreshModel();
                DrawChartsPreview();
                RedrawMap();
            }
        }

        private void OnChartsClick(object sender, EventArgs e)
        {
            Invoke(ModifyCharts);
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnCommentsKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Model.Description = txtComments.Text;
                MarkStateChanged();
            }
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnCommentsValidated(object sender, EventArgs e)
        {
            Model.Description = txtComments.Text;
            MarkStateChanged();
        }

        /// <summary>
        /// Opens default drawing options
        /// </summary>
        private void OnDefaultDrawingOptionsClick(object sender, EventArgs e)
        {
            if (_context.ShowDefaultStyleDialog(Model.Handle, true, this))
            {
                DrawAllPreviews();

                Application.DoEvents();

                RedrawMap();

                RefreshControls();
            }
        }

        /// <summary>
        /// Saves all the data before the closing
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                CancelChanges();
            }

            LockLegendAndMap(false);

            var lyr = Model;
            if (lyr != null)
            {
                lyr.Name = txtLayerName.Text;
                _tabIndex = tabControl1.SelectedIndex;

                _metadata.ShowLayerPreview = chkLayerPreview.Checked;
                _metadata.Comments = txtComments.Text;

                axMap1.Layers.RemoveWithoutClosing(0);
            }
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            Application.DoEvents();

            MapConfig.ForceHideLabels = false; // TODO: it's ugly; thing of a better way to show preview
        }

        /// /// <summary>
        /// Changes label font size. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFontSizeValueChanged(object sender, EventArgs e)
        {
            if (_lockUpdate)
            {
                return;
            }

            _featureSet.Labels.Style.FontSize = (int)udLabelFontSize.Value;
            DrawLabelsPreview();
            RedrawMap();
        }

        /// <summary>
        /// Changes label frame visiblity. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFrameChecked(object sender, EventArgs e)
        {
            if (_lockUpdate) return;

            _featureSet.Labels.Style.FrameVisible = chkLabelFrame.Checked;
            DrawLabelsPreview();
            RedrawMap();
        }

        /// <summary>
        /// Changes label frame color. We shall make changes for the categories as well in case a user wants to
        /// </summary>
        private void OnLabelFrameColorChanged(object sender, EventArgs e)
        {
            if (_lockUpdate) return;

            _featureSet.Labels.Style.FrameBackColor = clpLabelFrame.Color;
            DrawLabelsPreview();
            RedrawMap();
        }

        private void OnLabelPreviewClick(object sender, EventArgs e)
        {
            Invoke(ModifyLabels);
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnLayerNameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Model.Name = txtLayerName.Text;
                MarkStateChanged();
                RedrawLegend();
            }
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void OnLayerNameValidated(object sender, EventArgs e)
        {
            Model.Name = txtLayerName.Text;
            MarkStateChanged();
            RedrawLegend();
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
        /// Saves the current changes treating them as the new initial state
        /// </summary>
        private void OnSaveChangesClick(object sender, EventArgs e)
        {
            if (!_stateChanged) return;

            RefreshModel(null, null);

            LockLegendAndMap(false);

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            Application.DoEvents();

            LockLegendAndMap(true);

            _initState = SaveState();

            _stateChanged = false;
            btnApply.Enabled = false;

            _context.Project.SetModified();
        }

        private void OnSpatialIndexChecked(object sender, EventArgs e)
        {
            if (_lockUpdate) return;

            Invoke(UpdateSpatialIndex);
        }

        private void RedrawLegend()
        {
            if (!_lockUpdate)
            {
                _context.Legend.Redraw();
            }
        }

        private void RedrawMap()
        {
            _context.Legend.Redraw(LegendRedraw.LegendAndMap);

            if (!_lockUpdate)
            {
                MarkStateChanged();
            }
        }

        private void RefreshControls()
        {
            if (_lockUpdate) return;

            // labels
            var labels = _featureSet.Labels;
            btnClearLabels.Enabled = !labels.Empty;
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

            txtLayerExpression.Text = _featureSet.VisibilityExpression;
        }

        private void RefreshModel()
        {
            if (_lockUpdate)
            {
                return;
            }

            _stateChanged = true;
            btnApply.Enabled = true;

            _featureSet.VisibilityExpression = txtLayerExpression.Text;
            _featureSet.CollisionMode = cboCollisionMode.GetValue<CollisionMode>();
            _featureSet.MinDrawingSize = (int)udMinDrawingSize.Value;

            var labels = _featureSet.Labels;
            labels.MinDrawingSize = (int)udMinLabelingSize.Value;

            var lb = _featureSet.Labels;
            lb.Visible = chkShowLabels.Checked;

            var charts = _featureSet.Diagrams;
            charts.Visible = chkChartsVisible.Checked;
            charts.DiagramType = optChartBars.Checked ? DiagramType.Bar : DiagramType.Pie;
            ChartHelper.UpdateChartFieds(icbChartColorScheme, _featureSet);

            Model.Visible = chkLayerVisible.Checked;
            Model.Name = txtLayerName.Text;

            dynamicVisibilityControl1.ApplyChanges();

            RefreshControls();

            RedrawMap();
        }

        private void RefreshModel(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private string SaveState()
        {
            // serializing for undo functionality (label and chart data must not be serialized)
            var mode1 = _featureSet.Labels.SavingMode;
            var mode2 = _featureSet.Diagrams.SavingMode;

            _featureSet.Labels.SavingMode = PersistenceType.None;
            _featureSet.Diagrams.SavingMode = PersistenceType.None;

            string state = Model.Serialize();

            _featureSet.Labels.SavingMode = mode1;
            _featureSet.Diagrams.SavingMode = mode2;

            return state;
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
    }

    public class VectorStyleViewBase : MapWindowView<ILegendLayer>
    {
    }
}