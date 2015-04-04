using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.Services;
using MW5.UI;
using MW5.UI.Controls;

namespace MW5.Projections.UI.Forms
{
    public partial class ReprojectForm : MapWindowForm
    {
        /// <summary>
        /// Creates a new instance of the frmAssignProjection class
        /// </summary>
        public ReprojectForm(IAppContext context):
            base(context)
        {
            InitializeComponent();
            
            if (context == null) throw new ArgumentException("No reference to MapWindow was passed");

            var database = context.Projections;
            if (database == null)
            {
                throw new InvalidCastException("Invalid instance of projection database was passed");
            }

            LayersControl1.Initialize(context);
           
            if (ProjectionTreeView1.Initialize(database, context))
            {
                ProjectionTreeView1.RefreshList();
            }

            LayersControl1.ControlType = LayersControl.CustomType.Projection;
        }

        /// <summary>
        /// Checks user input to start transformation
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            var cs = ProjectionTreeView1.SelectedCoordinateSystem;
            if (cs == null)
            {
                MessageService.Current.Info("No projection is selected");
                return;
            }

            var filenames = LayersControl1.Filenames.ToList();
            if (!filenames.Any())
            {
                MessageService.Current.Info("No files are selected");
                return;
            }

            ISpatialReference proj = new SpatialReference();
            if (!proj.ImportFromEpsg(cs.Code))
            {
                MessageService.Current.Warn("Failed to initialize the selected projection");
                return;
            }
            
            DoReprojection(filenames, proj, false);
        }

        /// <summary>
        /// Does the reprojection work
        /// </summary>
        private void DoReprojection(IEnumerable<string> filenames, ISpatialReference projection, bool inPlace)
        {
            var report = new TesterReportForm();
            report.InitProgress(projection);
            var files = new List<string>();

            int count = 0;  // number of successfully reprojected shapefiles
            foreach (string filename in filenames)
            {
                var layer = GeoSourceManager.Open(filename) as ILayerSource;
                if (layer == null)
                {
                    continue;
                }

                ILayerSource layerNew = null;
                
                if (projection.IsSame(layer.Projection))
                {
                    report.AddFile(layer.Filename, projection.Name, ProjectionOperaion.SameProjection, "");
                    files.Add(layer.Filename);
                }
                else
                {
                    TestingResult result = ReprojectingService.ReprojectLayer(layer, out layerNew, projection, report);
                    if (result == TestingResult.Ok || result == TestingResult.Substituted)
                    {
                        ProjectionOperaion oper = result == TestingResult.Ok ? ProjectionOperaion.Reprojected : ProjectionOperaion.Substituted;
                        string newName = layerNew == null ? "" : layerNew.Filename;
                        report.AddFile(layer.Filename, layer.Projection.Name, oper, newName);
                        files.Add(newName == "" ? layer.Filename : newName);
                        count++;
                    }
                    else
                    {
                        ProjectionOperaion operation = result == TestingResult.Error ? ProjectionOperaion.FailedToReproject : ProjectionOperaion.Skipped;
                        report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Skipped, "");
                    }
                }
                
                layer.Close();
                if (layerNew != null)
                {
                    layerNew.Close();
                }
            }
            report.ShowReport(projection, "Reprojection results:", ReportType.Loading);

            IEnumerable<string> names = _context.Layers.Select(l => l.Filename).ToList();
            names = files.Except(names);

            if (count == 0)
            {
                MessageService.Current.Info("No files to add to the map.");
                return;
            }

            if (!projection.IsSame(_context.Map.GeoProjection))
            {
                MessageService.Current.Info("Chosen projection is different from the project one. The layers can't be added to map.");
                return;
            }

            if (!names.Any())
            {
                MessageService.Current.Info("No files to add to the map.");
                return;
            }

            if (MessageService.Current.Ask("Do you want to add layers to the project?"))
            {
                //_context.Layers.StartAddingSession();

                foreach (string filename in names)
                {
                    var ds = GeoSourceManager.Open(filename);
                    var layer = LayerSourceHelper.ConvertToLayer(ds);
                    _context.Layers.Add(layer);    
                }

                //_context.Layers.StopAddingSession();
            }
        }

        /// <summary>
        /// Updating label
        /// </summary>
        private void ProjectionTreeView1_AfterSelect(object sender, EventArgs e)
        {
            var cs = ProjectionTreeView1.SelectedCoordinateSystem;
            lblProjection.Text = cs == null ? "" : "Projection: " + cs.Name;
        }
    }
}
