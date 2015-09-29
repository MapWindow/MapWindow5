// frmAssignProjection
// Author: Sergei Leschinski

using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.Enums;
using MW5.UI.Forms;
using MW5.UI.Legacy;

namespace MW5.Projections.Forms
{
    /// <summary>
    /// A form providing GUI for assigning projection
    /// </summary>
    public partial class AssignProjectionForm : MapWindowForm
    {
        /// <summary>
        /// Creates a new instance of the frmAssignProjection class
        /// </summary>
        public AssignProjectionForm(IAppContext context): 
            base(context)
        {
            InitializeComponent();
            
            if (context == null)
                throw new NullReferenceException("No reference to MapWindow was passed");

            var database = context.Projections;
            if (database == null)
                throw new InvalidCastException("Invalid instance of projection database was passed");

            LayersControl1.Initialize(context);
            LayersControl1.LayerAdded += delegate {
                RefreshControlState();
            };
            LayersControl1.LayerRemoved += RefreshControlState;

            if (ProjectionTreeView1.Initialize(database, context))
            {
                ProjectionTreeView1.RefreshList();
            }

            LayersControl1.ControlType = LayersControl.CustomType.Projection;

            RefreshControlState();
        }

        /// <summary>
        /// Updates the state of test button
        /// </summary>
        private void RefreshControlState()
        {
            btnTest.Enabled = LayersControl1.SelectedFilename != "";
            btnOk.Enabled = LayersControl1.SelectedFilename != "";
        }

        #region Assign projection
        /// <summary>
        /// Runs the operation
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            CoordinateSystem cs = ProjectionTreeView1.SelectedCoordinateSystem;
            if (cs == null)
            {
                MessageService.Current.Info("No projection is selected.");
                return;
            }
            
            if (!LayersControl1.Filenames.Any())
            {
                MessageService.Current.Info("No files are selected.");
                return;
            }

            var projection = new SpatialReference();
            if (!projection.ImportFromEpsg(cs.Code))
            {
                MessageService.Current.Info("Failed to initialize the selected projection.");
                return;
            }

            var report = new TesterReportForm();
            int count = 0;  // number of successfully processed files

            foreach (string name in LayersControl1.Filenames)
            {
                var layer = GeoSource.Open(name) as ILayerSource;
                if (layer == null)
                {
                    continue;
                }

                string projName = layer.Projection != null ? layer.Projection.Name : "";
                if (layer.LayerType != LayerType.Invalid && layer.Projection != null)
                {
                    layer.Projection.CopyFrom(projection);
                    count++;
                }
                else
                {
                    report.AddFile(name, projName, ProjectionOperaion.Skipped, "");
                }
            }

            if (count > 0)
            {
                MessageService.Current.Info(string.Format("The projection was successfully assigned to the files: {0}", count));
            }

            if (report.MismatchedCount > 0)
            {
                report.ShowReport(projection, "The following files were not processed:", ReportType.Assignment);
            }

            LayersControl1.UpdateProjections();
        }

        #endregion

        #region Testing
        /// <summary>
        /// Tries to assign the projection and reproject the data back to WGS 84 to make sure
        /// that it is placed right on the workld map
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            string filename = LayersControl1.SelectedFilename;

            if (filename == "")
            {
                MessageService.Current.Info("No file is selected");
                return;
            }

            // initializing target projection
            var cs = ProjectionTreeView1.SelectedCoordinateSystem;
            if (cs == null)
            {
                MessageService.Current.Info("No projection is selected");
                return;
            }
            
            var proj = new SpatialReference();
            if (!proj.ImportFromEpsg(cs.Code))
            {
                MessageService.Current.Warn("Failed to initialize projection: " + cs.Name);
            }
            else
            {
                using (var form = new ProjectionResultsForm(_context))
                {
                    if (form.Assign(filename, proj))
                    {
                        form.ShowDialog(this);
                    }    
                }
            }
        }

        #endregion

        private void ProjectionTreeView1_CoordinateSystemSelected(object sender, Controls.CoordinateSystemEventArgs e)
        {
            var cs = e.CoordinateSystem;
            lblProjection.Text = cs != null ? "Projection: " + cs.Name : "";
        }
    }
}
