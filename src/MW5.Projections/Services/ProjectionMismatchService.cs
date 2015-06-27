using System;
using System.Collections;
using System.Diagnostics;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Projections.Helpers;
using MW5.Projections.Services.Abstract;
using MW5.Projections.UI.Forms;
using MW5.Projections.Views;

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

            var mapProj = _context.Map.Projection;
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

            _context.Map.Projection = layerProj;
            return TestingResult.Ok;
        }

        /// <summary>
        /// Handles the projection mismatch by implementing the selected mismatch behavior.
        /// </summary>
        private TestingResult HandleProjectionMismatch(ILayerSource layer, ISpatialReference mapProj, out ILayerSource newLayer)
        {
            newLayer = null;

            // user should be prompted
            if (!_usePreviousAnswerMismatch && _context.Config.ShowProjectionMismatchDialog)
            {
                var model = new ProjectionMismatchModel(layer, true, mapProj);
                if (!_context.Container.Run<ProjectionMismatchPresenter, ProjectionMismatchModel>(model))
                {
                    return TestingResult.CancelOperation;
                }

                _usePreviousAnswerMismatch = model.UseAnswerLater;
                _context.Config.ProjectionMismatch = model.MismatchBehavior;
                _context.Config.ShowProjectionMismatchDialog = !model.DontShow;
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
            if (!_usePreviousAnswerAbsence && _context.Config.ShowProjectionAbsenceDialog)
            {
                var model = new ProjectionMismatchModel(layer, false, mapProj);
                if (!_context.Container.Run<ProjectionMismatchPresenter, ProjectionMismatchModel>(model))
                {
                    return TestingResult.CancelOperation;    
                }

                _usePreviousAnswerAbsence = model.UseAnswerLater;
                _context.Config.ProjectionAbsence = model.AbsenceBehavior;
                _context.Config.ShowProjectionAbsenceDialog = !model.DontShow;
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
