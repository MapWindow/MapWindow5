// -------------------------------------------------------------------------------------------
// <copyright file="ProjectionInfoView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Projections.BL;
using MW5.Projections.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.Projections.Views
{
    public partial class ProjectionInfoView : ProjectionInfoViewBase, IProjectionInfoView
    {
        private static int _lastTabIndex;
        private readonly IAppContext _context;

        public ProjectionInfoView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            tabControl1.SelectedIndex = _lastTabIndex;

            FormClosed += (s, e) => _lastTabIndex = tabControl1.SelectedIndex;

            
        }

        public event Action EditDialect;

        public override void UpdateView()
        {
            btnRemoveDialect.Enabled = dialectGrid1.Adapter.SelectedItem != null;
            btnEditDialect.Enabled = dialectGrid1.Adapter.SelectedItem != null;
            btnClearDialects.Enabled = dialectGrid1.Adapter.Items.Any();

            dialectGrid1.AdjustRowHeights();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            if (Model.CoordinateSystem != null)
            {
                LoadMapPreviewSettings();

                ShowCoordinateSystem();

                InitDialectsGrid();

                LoadDialects();
            }
            else
            {
                ShowProjection();

                _projectionMap1.Visible = false;
                linkLabel1.Visible = false;
                tabControl1.SelectedIndex = _lastTabIndex;

                // those aren't avaialable for unidentified projection
                tabControl1.TabPages.Remove(tabMap);
                tabControl1.TabPages.Remove(tabDialects);
            }
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnAddDialect;
                yield return btnRemoveDialect;
                yield return btnClearDialects;
                yield return btnEditDialect;
            }
        }

        public ProjectionDialect SelectedDialect
        {
            get { return dialectGrid1.Adapter.SelectedItem; }
            set
            {
                dialectGrid1.Adapter.SelectedItem = value;
                dialectGrid1.Adapter.ScrollToSelectedRow();
            }
        }

        private void InitDialectsGrid()
        {
            dialectGrid1.Adapter.SelectionChanged += (s, e) => UpdateView();

            dialectGrid1.TableControlCellDoubleClick += (s, e) => Invoke(EditDialect);

            dialectGrid1.Adapter.AutoAdjustRowHeights = true;
        }

        /// <summary>
        /// Loads and displays dialects for projection.
        /// </summary>
        private void LoadDialects()
        {
            if (Model.LoadDialects(_context.Projections))
            {
                dialectGrid1.DataSource = Model.Dialects;
                dialectGrid1.Adapter.SelectFirstRecord();

                var cmn = dialectGrid1.Adapter.GetColumn(d => d.Definition);
                if (cmn != null)
                {
                    cmn.Width -= 55;
                    dialectGrid1.AdjustRowHeights();
                }
            }
        }

        /// <summary>
        /// Initializes map control with projection bounds.
        /// </summary>
        private void LoadMapPreviewSettings()
        {
            _projectionMap1.LoadStateFromExeName(Application.ExecutablePath);
            _projectionMap1.ZoomBar.Visible = false;
            _projectionMap1.ScalebarVisible = false;
            _projectionMap1.ShowCoordinates = CoordinatesDisplay.None;
            _projectionMap1.ShowVersionNumber = false;
            _projectionMap1.TileProvider = TileProvider.None;
            _projectionMap1.ZoomBehavior = ZoomBehavior.Default;
        }

        private void OnCopyClipboardClick(object sender, EventArgs e)
        {
            projectionTextBox1.SelectAll();
            projectionTextBox1.Copy();
            projectionTextBox1.SelectionLength = 0;
        }

        private void OnEpsgLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://spatialreference.org/ref/epsg/" + txtCode.Text + "/";
            PathHelper.OpenUrl(url);
        }

        /// <summary>
        /// Shows information about selected projection
        /// </summary>
        private void ShowCoordinateSystem()
        {
            var cs = Model.CoordinateSystem;

            txtName.Text = cs.Name;
            txtCode.Text = cs.Code.ToString(CultureInfo.InvariantCulture);

            var sr = new SpatialReference();
            if (!sr.ImportFromEpsg(cs.Code))
            {
                // usupported projection
            }
            else
            {
                projectionTextBox1.ShowProjection(sr.ExportToWkt());

                _projectionMap1.DrawCoordinateSystem(cs);
                _projectionMap1.ZoomToCoordinateSystem(cs);

                txtProj4.Text = sr.ExportToProj4();

                txtAreaName.Text = cs.AreaName;
                txtRemarks.Text = cs.Remarks;
                txtScope.Text = cs.Scope;
            }
        }

        /// <summary>
        /// Shows information about unrecognized projection
        /// </summary>
        private void ShowProjection()
        {
            var projection = Model.SpatialReference;

            txtName.Text = projection.Name == "" ? "None" : projection.Name;
            txtCode.Text = "None";

            if (!projection.IsEmpty)
            {
                projectionTextBox1.ShowProjection(projection.ExportToWkt());
                txtProj4.Text = projection.ExportToProj4();

                txtAreaName.Text = "Not defined";
                txtScope.Text = "Not defined";
                txtRemarks.Text = "Unrecognized projection";
            }
        }
    }

    public class ProjectionInfoViewBase : MapWindowView<ProjectionInfoModel>
    {
    }
}