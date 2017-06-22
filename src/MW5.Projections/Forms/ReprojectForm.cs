// -------------------------------------------------------------------------------------------
// <copyright file="ReprojectForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.Enums;
using MW5.Projections.Services.Abstract;
using MW5.UI.Forms;
using MW5.UI.Legacy;

namespace MW5.Projections.Forms
{
    public partial class ReprojectForm : MapWindowForm
    {
        private readonly IReprojectingService _reprojectingService;

        /// <summary>
        /// Creates a new instance of the frmAssignProjection class
        /// </summary>
        public ReprojectForm(IAppContext context, IReprojectingService reprojectingService)
            : base(context)
        {
            _reprojectingService = reprojectingService;

            InitializeComponent();

            if (context == null) throw new ArgumentException("No reference to MapWindow was passed");
            if (reprojectingService == null) throw new ArgumentNullException("reprojectingService");

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

            int count = 0; // number of successfully reprojected shapefiles
            foreach (string filename in filenames)
            {
                var layer = GeoSource.Open(filename) as ILayerSource;
                if (layer == null)
                {
                    continue;
                }

                ILayerSource layerNew = null;

                if (projection.IsSame(layer.Projection))
                {
                    report.AddFile(layer.Filename, projection.Name, ProjectionOperation.SameProjection, "");
                    files.Add(layer.Filename);
                }
                else
                {
                    TestingResult result = _reprojectingService.Reproject(layer, out layerNew, projection, report);
                    if (result == TestingResult.Ok || result == TestingResult.Substituted)
                    {
                        var oper = result == TestingResult.Ok
                                       ? ProjectionOperation.Reprojected
                                       : ProjectionOperation.Substituted;
                        string newName = layerNew == null ? "" : layerNew.Filename;
                        report.AddFile(layer.Filename, layer.Projection.Name, oper, newName);
                        files.Add(newName == "" ? layer.Filename : newName);
                        count++;
                    }
                    else
                    {
                        var operation = result == TestingResult.Error
                                            ? ProjectionOperation.FailedToReproject
                                            : ProjectionOperation.Skipped;
                        report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperation.Skipped, "");
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

            if (!projection.IsSame(_context.Map.Projection))
            {
                MessageService.Current.Info(
                    "Chosen projection is different from the project one. The layers can't be added to map.");
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
                    var ds = GeoSource.Open(filename);
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

        private void ReprojectForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}