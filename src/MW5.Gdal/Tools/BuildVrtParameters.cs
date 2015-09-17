using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Gdal.Tools
{
    public partial class BuildVrtTool
    {
        [Input("Tile index", 0, true)]
        public string TileIndex { get; set; }

        [Input("Resolution", 1, true)]
        [ControlHint(ControlHint.Combo)]
        public string Resolution { get; set; }

        [Input("Target resolution", 2, true)]
        public string TartetResolution { get; set; }

        [Input("Target extents", 3, true)]
        public string TargetExtents { get; set; }

        [Input("Source no data value", 4, true)]
        public string SrcNoData { get; set; }

        [Input("Band index", 5, true)]
        public string BandIndex { get; set; }

        [Input("Subdataset index", 6, true)]
        public string SubdatasetIndex { get; set; }

        [Input("Output no data value", 7, true)]
        public string VrtNoDataValue { get; set; }

        [Input("Override projection of output file", 8, true)]
        public string TargetProjection { get; set; }

        [Input("Resampling", 9, true)]
        [ControlHint(ControlHint.Combo)]
        public string Resampling { get; set; }

        [Input("Add alpha channel", 10, true)]
        public bool AddAlpha { get; set; }

        [Input("Hide no data values", 11, true)]
        public bool HideNoData { get; set; }

        [Input("Align pixels to target resolution", 12, true)]
        public bool AlignPixelsToResolution { get; set; }

        [Input("Separate stack band for each file", 13, true)]
        public bool Separate { get; set; }

        [Input("Allow projection difference", 14, true)]
        public bool AllowProjectionDifference { get; set; }
    }
}
