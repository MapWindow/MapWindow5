using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class IntersectionTool: GisToolBase
    {
        [Input("First layer", 0)]
        public VectorLayerParameter InputLayer { get; set; }

        [Input("Second layer", 1)]
        public VectorLayerParameter InputLayer2 { get; set; }

        [Input("Save results as", 2), DefaultValue("intersection")]
        public OutputLayerParameter Output { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Intersection"; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Calculates intersection of 2 vector layers."; }
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run()
        {
            var fs = InputLayer.Value;

            var fs2 = InputLayer2.Value;

            var result = fs.Intersection(false, fs2, false, Api.Enums.GeometryType.None);

            if (result != null)
            {
                return HandleOutput(result, Output.Value);
            }

            return false;
        }
    }
}
