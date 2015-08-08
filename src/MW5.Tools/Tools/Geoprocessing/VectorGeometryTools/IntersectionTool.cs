using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class IntersectionTool: GisTool
    {
        [Input("First layer", 0)]
        public VectorLayerInfo InputLayer { get; set; }

        [Input("Second layer", 1)]
        public VectorLayerInfo InputLayer2 { get; set; }

        [Input("Save results as", 2), DefaultValue("intersection")]
        public OutputLayerInfo Output { get; set; }

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
        public override bool Run(ITaskHandle task)
        {
            var fs = InputLayer.Datasource;
            var fs2 = InputLayer2.Datasource;

            var result = fs.Intersection(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly, Api.Enums.GeometryType.None);

            if (result != null)
            {
                HandleOutput(result, Output);
                return true;
            }

            return false;
        }
    }
}
