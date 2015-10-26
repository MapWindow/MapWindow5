// -------------------------------------------------------------------------------------------
// <copyright file="WarpRasterToolParameters.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Gdal.Tools
{
    public partial class WarpRasterTool
    {
        private const string GroupSize = "Extents";
        private const string GroupOutput = "Output";
        private const string GroupSource = "Source";
        private const string GroupAdvanced = "Advanced";

        [Input("Target projection", 0, GroupSize)]
        public string TargetProjection { get; set; }

        [Input("Target extents", 1, GroupSize)]
        public string TargetExtents { get; set; }

        [Input("Projection for target extents", 2, GroupSize)]
        public string TargetExtentsProjection { get; set; }

        [Input("Target resolution (size of pixel in map units?)", 3, GroupSize)]
        public string TargetResolution { get; set; }

        [Input("Target size in pixels", 4, GroupSize)]
        public string TargetSize { get; set; }

        [Input("Align pixels to target resolution", 5, GroupSize)]
        public bool AlignPixelsToResolution { get; set; }


        [Input("Output type", 0, GroupOutput)]
        [ControlHint(ControlHint.Combo)]
        public override string OutputType { get; set; }

        [Input("Resampling method", 1, GroupOutput)]
        [ControlHint(ControlHint.Combo)]
        public string DstResampling { get; set; }

        [Input("Destination no data value", 2, GroupOutput)]
        public string DstNoDataValue { get; set; }

        [Input("Add alpha channel for no data values", 3, GroupOutput)]
        public bool DstAlpha { get; set; }

        [Input("Don't copy metadata", 4, GroupOutput)]
        public bool DstNoMetadata { get; set; }

        [Input("Copy color interpretation", 5, GroupOutput)]
        public bool CopyColorIntepretation { get; set; }


        [Input("Source projection", 0, GroupSource)]
        public string SourceProjection { get; set; }

        [Input("Source no data value", 1, GroupSource)]
        public string SourceNoDataValue { get; set; }

        [Input("Source overview level", 2, GroupSource)]
        public string SourceOverviewLevel { get; set; }


        [Input("Memory for warping, MB", 0, GroupAdvanced)]
        public string MemoryLimitMb { get; set; }

        [Input("Working pixels type", 1, GroupAdvanced)]
        [ControlHint(ControlHint.Combo)]
        public string WorkingPixelsType { get; set; }

        [Input("Thin plate spline transformer", 2, GroupAdvanced)]
        public bool TpsTransformer { get; set; }

        [Input("Rational polynomial coefficients", 3, GroupAdvanced)]
        public bool RpcCoefficients { get; set; }

        [Input("Geolocation array", 4, GroupAdvanced)]
        public bool GeolocationArrays { get; set; }

        [Input("Error threshhold", 5, GroupAdvanced)]
        public bool ErrorThreshhold { get; set; }

        [Input("Refine GCPs", 6, GroupAdvanced)]
        public bool RefineGcp { get; set; }

        [Input("Use multithreading", 7, GroupAdvanced)]
        public bool UseMultithreading { get; set; }
    }
}