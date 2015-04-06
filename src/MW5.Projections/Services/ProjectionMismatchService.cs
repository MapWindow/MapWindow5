using System;
using System.Collections;
using System.Diagnostics;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Projections.Helpers;
using MW5.Projections.Services.Abstract;
using MW5.Projections.UI.Forms;

namespace MW5.Projections.Services
{
    /// <summary>
    /// Handle various projection mismatch scenarios while adding a layer to the map.
    /// </summary>
    public class ProjectionMismatchService: IProjectionMismatchService
    {
        private readonly IAppContext _context;
        private readonly IReprojectingService _reprojectingService;
        private readonly TesterReportForm _report = new TesterReportForm();     // TODO: inject
        private bool _usePreviousAnswerMismatch;
        private bool _usePreviousAnswerAbsence;

        /// <summary>
        /// Creates a new instance of MismatchTester class
        /// </summary>
        public ProjectionMismatchService(IAppContext context, IReprojectingService reprojectingService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (reprojectingService == null) throw new ArgumentNullException("reprojectingService");

            _context = context;
            _reprojectingService = reprojectingService;
        }
        
        /// <summary>
        /// Tests projection of a single layer
        /// </summary>
        public TestingResult TestLayer(ILayerSource layer, out ILayerSource newLayer)
        {
            if (layer == null) throw new ArgumentException("Empty layer reference was passed");

            var mapProj = _context.Map.GeoProjection;
            var layerProj = layer.Projection;

            var result = CheckIsSame(layer, mapProj, layerProj, out newLayer);
            if (result)
            {
                return newLayer != null ? TestingResult.Substituted : TestingResult.Ok;
            }

            if (!layer.Projection.IsEmpty)
            {
                if (mapProj.IsEmpty)
                {
                    return HandleEmptyMapProjection(layerProj);
                }

                return HandleProjectionMismatch(layer, mapProj, out newLayer);
            }
            
            return HandleEmptyLayerProjection(layer, mapProj);
        }

        /// <summary>
        /// Checks if layer projection is the same as map projection, including search for dialects and substitutes.
        /// </summary>
        private bool CheckIsSame(ILayerSource layer, ISpatialReference mapProj, ISpatialReference layerProj, out ILayerSource newLayer)
        {
            newLayer = null;

            bool isSame = mapProj.IsSameExt(layerProj, layer.Envelope, 10);

            if (!isSame)
            {
                isSame = _context.Projections.IsDialectOf(mapProj, layerProj);
            }

            if (!isSame)
            {
                if (layer.SeekSubstituteFile(mapProj, out newLayer))
                {
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Substituted, newLayer.Filename);
                    return true;
                }
            }

            return isSame;
        }

        /// <summary>
        /// Assigns laye projection to the map.
        /// </summary>
        private TestingResult HandleEmptyMapProjection(ISpatialReference layerProj)
        {
            var db = _context.Projections;
            if (db != null)
            {
                var cs = db.GetCoordinateSystem(layerProj, ProjectionSearchType.UseDialects);
                if (cs != null)
                {
                    var proj = new SpatialReference();
                    if (proj.ImportFromEpsg(cs.Code))
                    {
                        layerProj = proj;
                    }
                }
            }

            _context.Map.GeoProjection = layerProj;
            return TestingResult.Ok;
        }

        /// <summary>
        /// Handles the projection mismatch by implementing the selected mismatch behavior.
        /// </summary>
        private TestingResult HandleProjectionMismatch(ILayerSource layer, ISpatialReference mapProj, out ILayerSource newLayer)
        {
            newLayer = null;

            // user should be prompted
            if (!_usePreviousAnswerMismatch && !_context.Config.NeverShowProjectionDialog)
            {
                bool dontShow, useForOthers;

                var list = new ArrayList { "Ignore mismatch", "Reproject file", "Don't load the layer" };

                int choice;
                using (var form = new ProjectionMismatchForm(_context))
                {
                    choice = form.ShowProjectionMismatch(list, (int)_context.Config.ProjectionMismatch, mapProj, 
                    layer.Projection, out useForOthers, out dontShow);
                }

                if (choice == -1)
                {
                    return TestingResult.CancelOperation;
                }

                _usePreviousAnswerMismatch = useForOthers;
                _context.Config.ProjectionMismatch = (ProjectionMismatch)choice;
                _context.Config.NeverShowProjectionDialog = dontShow;
            }

            var behavior = _context.Config.ProjectionMismatch;

            switch (behavior)
            {
                case ProjectionMismatch.Reproject:
                    var result = _reprojectingService.Reproject(layer, out newLayer, mapProj, _report);
                    if (result == TestingResult.Ok || result == TestingResult.Substituted)
                    {
                        var oper = result == TestingResult.Ok ? ProjectionOperaion.Reprojected : ProjectionOperaion.Substituted;
                        string newName = newLayer == null ? "" : newLayer.Filename;
                        _report.AddFile(layer.Filename, layer.Projection.Name, oper, newName);
                        return newName == layer.Filename ? TestingResult.Ok : TestingResult.Substituted;
                    }

                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.FailedToReproject, "");
                    return TestingResult.Error;

                case ProjectionMismatch.IgnoreMismatch:
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.MismatchIgnored, "");
                    return TestingResult.Ok;

                case ProjectionMismatch.SkipFile:
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Skipped, "");
                    return TestingResult.SkipFile;
            }

            throw new ApplicationException("Invalid ProjectionMismatch setting: " + behavior);
        }

        /// <summary>
        /// Handles the empty layer projection by implementing selected projection absense behavior.
        /// </summary>
        private TestingResult HandleEmptyLayerProjection(ILayerSource layer, ISpatialReference mapProj)
        {
            bool projectProjectionExists = !mapProj.IsEmpty;

            // user should be prompted
            if (!_usePreviousAnswerAbsence && !_context.Config.NeverShowProjectionDialog)
            {
                bool dontShow, useForOthers;

                var list = new ArrayList();

                // when there in projection the first variant should be excluded
                int val = projectProjectionExists ? 0 : 1;

                if (projectProjectionExists)
                {
                    list.Add("Use the project's projection");
                }

                list.Add("Ignore the missing of projection file");
                list.Add("Don't load the layer");

                int choice;
                using (var form = new ProjectionMismatchForm(_context))
                {
                    choice = form.ShowProjectionAbsence(list,
                        (int)_context.Config.ProjectionAbsence - val, mapProj, out useForOthers, out dontShow);
                }

                if (choice == -1)
                {
                    return TestingResult.CancelOperation;
                }

                choice += val;

                _usePreviousAnswerAbsence = useForOthers;
                _context.Config.ProjectionAbsence = (ProjectionAbsence)choice;
                _context.Config.NeverShowProjectionDialog = dontShow;
            }

            // when there is no projection in project, it can't be assign for layer
            var behavior = _context.Config.ProjectionAbsence;
            if (!projectProjectionExists && _context.Config.ProjectionAbsence == ProjectionAbsence.AssignFromProject)
            {
                behavior = ProjectionAbsence.IgnoreAbsence;
            }

            switch (behavior)
            {
                case ProjectionAbsence.AssignFromProject:
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Assigned, "");
                    layer.Projection.CopyFrom(mapProj);
                    return TestingResult.Ok;

                case ProjectionAbsence.IgnoreAbsence:
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.AbsenceIgnored, "");
                    return TestingResult.Ok;

                case ProjectionAbsence.SkipFile:
                    _report.AddFile(layer.Filename, layer.Projection.Name, ProjectionOperaion.Skipped, "");
                    return TestingResult.SkipFile;
            }

            return TestingResult.Ok;
        }
    }
}
