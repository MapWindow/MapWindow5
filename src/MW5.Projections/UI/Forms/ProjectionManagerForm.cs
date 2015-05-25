// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections:
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Projections.UI.Forms
{
    /// <summary>
    /// Provides GUI to work with favorite and custom projections
    /// </summary>
    public partial class ProjectionManagerForm : MapWindowForm
    {
        // the previous projection code shown
        private int _lastCode = 4326;

        /// <summary>
        /// Creates a new instance of frmProjectionManager class
        /// </summary>
        public ProjectionManagerForm(IAppContext context):
            base(context)
        {
            if (context == null) throw new ArgumentNullException("context");

            InitializeComponent();

            var database = context.Projections;
            if (database == null)
            {
                throw new InvalidCastException("Invalid instance of projection database was passed");
            }

            // initializing tree
            if (_projectionTreeView1.Initialize(database, _context))
            {
                int gcsCount, pcsCount;
                _projectionTreeView1.RefreshList(out gcsCount, out pcsCount);
                lblGcsCount.Text = "Coordinate systems: " + gcsCount;
                lblPcsCount.Text = "Projections: " + pcsCount.ToString();
            }
            _projectionTreeView1.CoordinateSystemSelected += TreeViewCoordinateSystemSelected;

            // initializing map
            projectionMap1.LoadStateFromExeName(Application.ExecutablePath);
            projectionMap1.CoordinatesChanged += projectionMap1_CoordinatesChanged;

            // showing information on WGS 84
            IEnumerable<IGeographicCs> list = _projectionTreeView1.CoordinateSystems.Where(cs => cs.Code == 4326);
            OnCoordinateSystemSelected((CoordinateSystem)list.First());
        }

        private void TreeViewCoordinateSystemSelected(object sender, Controls.CoordinateSystemEventArgs e)
        {
            OnCoordinateSystemSelected(e.CoordinateSystem);
        }

        private void OnCoordinateSystemSelected(CoordinateSystem cs)
        {
            projectionMap1.DrawCoordinateSystem(cs);
            projectionMap1.ZoomToCoordinateSystem(cs);

            _lastCode = cs.Code;
            txtCode.Text = cs.Code.ToString();
            txtName.Text = cs.Name;

            txtRemarks.Text = cs.Remarks != "" ? cs.Remarks : "No remarks";
            txtScope.Text = cs.Scope != "" ? cs.Scope : "No description";
        }

        /// <summary>
        /// Updates coordianates in the status bar
        /// </summary>
        void projectionMap1_CoordinatesChanged(double x, double y, string textX, string textY)
        {
            lblX.Text = "Long: " + textX;
            lblY.Text = "Lat: " + textY;
        }

        /// <summary>
        /// Show projection at spatialreference.org site
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://spatialreference.org/ref/epsg/" + txtCode.Text + "/";
            PathHelper.OpenUrl(url);
        }
        
        /// <summary>
        /// Zoomes to max extents
        /// </summary>
        private void btnZoomToMaxExtents_Click(object sender, EventArgs e)
        {
            projectionMap1.ZoomToMaxExtents();
        }

        /// <summary>
        /// Shows properties for selected coorinate system
        /// </summary>
        private void btnProperties_Click(object sender, EventArgs e)
        {
            int code;
            if (Int32.TryParse(txtCode.Text, out code))
            {
                _projectionTreeView1.ShowProjectionProperties(code);
            }
        }

        /// <summary>
        /// Zoomes to coordinate system
        /// </summary>
        private void btnZoomToProjection_Click(object sender, EventArgs e)
        {
            projectionMap1.ZoomToCoordinateSystem();
        }

        /// <summary>
        /// Seeking coordinate system by code enetered by user
        /// </summary>
        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            ShowProjectionByCode();
        }

        /// <summary>
        /// Seeking coordinate system by code enetered by user
        /// </summary>
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ShowProjectionByCode();
            }
        }

        /// <summary>
        /// Seeking coordinate system by code enetered by user
        /// </summary>
        private void ShowProjectionByCode()
        {
            int val;
            if (!Int32.TryParse(txtCode.Text, out val))
            {
                txtCode.Text = _lastCode.ToString();
                val = _lastCode;     
            }

            if (val == _lastCode)
            {
                return;
            }

            // showing information on WGS 84
            var list = _projectionTreeView1.CoordinateSystems.Where(cs => cs.Code == val).ToList();
            if (list.Any())
            {
                OnCoordinateSystemSelected((CoordinateSystem)list.First());
                return;
            }
            
            var list2 = _projectionTreeView1.Projections.Where(cs => cs.Code == val).ToList();
            if (list2.Any())
            {
                OnCoordinateSystemSelected((CoordinateSystem)list2.First());
            }
            else
            {
                txtCode.Text = _lastCode.ToString();
                MessageService.Current.Info("Failed to find coordinate system with EPSG code: " + val);
            }
        }
    }
}
