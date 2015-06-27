// -------------------------------------------------------------------------------------------
// <copyright file="ProjectionMismatchModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;

namespace MW5.Projections.Views
{
    public class ProjectionMismatchModel
    {
        public ProjectionMismatchModel(ILayerSource layerSource, bool isMismatch, ISpatialReference projectProj)
        {
            if (layerSource == null) throw new ArgumentNullException("layerSource");

            IsMismatch = isMismatch;
            ProjectProjection = projectProj;
            LayerSource = layerSource;
        }

        public ProjectionAbsence AbsenceBehavior { get; set; }

        public bool DontShow { get; set; }

        public bool IsMismatch { get; private set; }

        public ILayerSource LayerSource { get; private set; }

        public ProjectionMismatch MismatchBehavior { get; set; }

        public ISpatialReference ProjectProjection { get; private set; }

        public bool UseAnswerLater { get; set; }
    }
}