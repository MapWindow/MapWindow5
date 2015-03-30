// MapWindow.Controls.Projections.MismatcTester
// Author: Sergei Leschinski
// Created: 20 July 2011

using System;
using System.Collections;
using System.Diagnostics;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Projections.Forms;

namespace MW5.Projections.Services
{
    /// <summary>
    /// A class to handle various projection mismatch scenarious while adding a layer to the map
    /// </summary>
    public class MismatchTester
    {
        private IAppContext _context;

        private readonly TesterReportForm _report = new TesterReportForm();

        private bool _usePreviousAnswerMismatch = false;

        private bool _usePreviousAnswerAbsence = false;

        /// <summary>
        /// Creates a new instance of MismatchTester class
        /// </summary>
        public MismatchTester(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }


        /// <summary>
        /// Gets the list of files where projection mismatch happened (or projction absence)
        /// </summary>
        public int FileCount
        {
            get
            {
                if (_report == null)
                {
                    return 0;
                }
                return _report.MismatchedCount;
            }
        }

        #region Report methods

        public void ShowReprojectionProgress(ISpatialReference proj)
        {
            _report.InitProgress(proj);
        }

        public void ShowReport(ISpatialReference proj)
        {
            _report.ShowReport(proj, "", ReportType.Loading);
        }

        public void HideProgress()
        {
            _report.Visible = false;
        }

        #endregion

        #region Testing

        private bool IsDialectOf(ISpatialReference multiDefinedProj, ISpatialReference testProj)
        {
            if (multiDefinedProj.IsEmpty)
            {
                return false;
            }

            var db = _context.Projections;
            if (db == null)
            {
                return false;
            }
            
            var cs = db.GetCoordinateSystem(multiDefinedProj, ProjectionSearchType.Enhanced);
            if (cs == null)
            {
                return false;
            }
            
            db.ReadDialects(cs);

            foreach (var dialect in cs.Dialects)
            {
                var projTemp = new SpatialReference();
                if (!projTemp.ImportFromAutoDetect(dialect))
                {
                    continue;
                }

                if (testProj.IsSame(projTemp))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Tests projection of a single layer
        /// </summary>
        public TestingResult TestLayer(ILayerSource layer, out ILayerSource newLayer)
        {
            if (layer == null) throw new ArgumentException("Empty layer reference was passed");

            newLayer = null;

            var mapProj = _context.Map.GeoProjection;
            var layerProj = layer.Projection;

            bool isSame = mapProj.IsSameExt(layerProj, layer.Envelope, 10);

            // let's check whether we have a dialect of the project projection
            if (!isSame)
            {
                isSame = IsDialectOf(mapProj, layerProj);
            }

            // projection can be included in the name of the file as suffix, let's try to search the file with correct suffix
            if (!isSame)
            {
                if (ReprojectingService.SeekSubstituteFile(layer, mapProj, out newLayer))
                {
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Substituted, newLayer.Filename);
                    return TestingResult.Substituted;
                }
            }

            if (!layer.Projection.IsEmpty)
            {
                if (mapProj.IsEmpty)
                {
                    // layer has a projection, project - doesn't; assign to projection, don't prompt user

                    // let's try to find well known projection with EPSG code
                    var db = _context.Projections;
                    if (db != null)
                    {
                        var cs = db.GetCoordinateSystem(layerProj, ProjectionSearchType.UseDialects);
                        if (cs != null)
                        {
                            var proj = new SpatialReference();
                            if (proj.ImportFromEpsg(cs.Code))
                                layerProj = proj;
                        }
                    }
                    
                    _context.Map.GeoProjection = layerProj;
                    return TestingResult.Ok;
                }
                
                if (isSame)
                {
                    // the same projection 
                    return TestingResult.Ok;
                }
                
                // user should be prompted
                if (!_usePreviousAnswerMismatch && !_context.Config.NeverShowProjectionDialog)
                {
                    bool dontShow = false;
                    bool useForOthers = false;

                    var list = new ArrayList {"Ignore mismatch", "Reproject file", "Don't load the layer"};

                    var form = new ProjectionMismatchForm(_context.Projections);

                    int choice = form.ShowProjectionMismatch(list, (int)_context.Config.ProjectionMismatchBehavior, 
                        mapProj, layer.Projection, out useForOthers, out dontShow);

                    form.Dispose();
                    if (choice == -1)
                        return TestingResult.CancelOperation;

                    _usePreviousAnswerMismatch = useForOthers;
                    _context.Config.ProjectionMismatchBehavior = (ProjectionMismatchBehavior)choice;
                    _context.Config.NeverShowProjectionDialog = dontShow;
                }

                var behavior = _context.Config.ProjectionMismatchBehavior;
                    
                switch (behavior)
                {
                    case ProjectionMismatchBehavior.Reproject:
                        TestingResult result = ReprojectingService.ReprojectLayer(layer, out newLayer, mapProj, _report);
                        if (result == TestingResult.Ok || result == TestingResult.Substituted)
                        {
                            ProjectionOperaion oper = result == TestingResult.Ok ? ProjectionOperaion.Reprojected : ProjectionOperaion.Substituted;
                            string newName = newLayer == null ? "" : newLayer.Filename;
                            _report.AddFile(layer.Filename, layer.Projection.Name, oper, newName);
                            return newName == layer.Filename ? TestingResult.Ok : TestingResult.Substituted;
                        }

                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.FailedToReproject, "");
                        return TestingResult.Error;

                    case ProjectionMismatchBehavior.IgnoreMismatch:
                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.MismatchIgnored, "");
                        return TestingResult.Ok;
                        
                    case ProjectionMismatchBehavior.SkipFile:
                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Skipped, "");
                        return TestingResult.SkipFile;
                }
            }
            else if (!mapProj.IsEmpty)          // layer projection is empty
            {
                bool projectProjectionExists = !mapProj.IsEmpty;

                // user should be prompted
                if (!_usePreviousAnswerAbsence && !_context.Config.NeverShowProjectionDialog)
                {
                    bool dontShow = false;
                    bool useForOthers = false;

                    ArrayList list = new ArrayList();

                    // when there in projection the first variant should be excluded
                    int val = projectProjectionExists ? 0 : 1;

                    if (projectProjectionExists)
                    {
                      // PM 2013-05-03:
                      //list.Add("Assign projection from project");
                      list.Add("Use the project's projection");
                    }
                    // list.Add("Ignore the absence");
                    // list.Add("Skip the file");
                    list.Add("Ignore the missing of projection file");
                    list.Add("Don't load the layer");

                    ProjectionMismatchForm form = new ProjectionMismatchForm(_context.Projections);
                    int choice = form.ShowProjectionAbsence(list, (int)_context.Config.ProjectionAbsenceBehavior - val, mapProj, out useForOthers, out dontShow);
                    form.Dispose();

                    if (choice == -1)
                        return TestingResult.CancelOperation;

                    choice += val;

                    _usePreviousAnswerAbsence = useForOthers;
                    _context.Config.ProjectionAbsenceBehavior = (ProjectionAbsenceBehavior)choice;
                    _context.Config.NeverShowProjectionDialog = dontShow;
                }

                // when there is no projection in project, it can't be assign for layer
                ProjectionAbsenceBehavior behavior = _context.Config.ProjectionAbsenceBehavior;
                if (!projectProjectionExists && _context.Config.ProjectionAbsenceBehavior == ProjectionAbsenceBehavior.AssignFromProject)
                {
                    behavior = ProjectionAbsenceBehavior.IgnoreAbsence;
                }

                switch (behavior)
                {
                    case ProjectionAbsenceBehavior.AssignFromProject:
                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Assigned, "");
                        layer.Projection.CopyFrom(mapProj);
                        return TestingResult.Ok;

                    case ProjectionAbsenceBehavior.IgnoreAbsence:
                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.AbsenceIgnored, "");
                        return TestingResult.Ok;

                    case ProjectionAbsenceBehavior.SkipFile:
                        _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Skipped, "");
                        return TestingResult.SkipFile;
                }
            }
            else
            {
                // layer doesn't have projection, project either, nothing to do further here
            }

            Debug.Print("Invalid result in projection tester");
            return TestingResult.Ok;
        }

        
        #endregion
    }
}
