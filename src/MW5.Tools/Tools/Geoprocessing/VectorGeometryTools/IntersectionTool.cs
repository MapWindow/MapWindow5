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
        public override bool Run(ITaskHandle task)
        {
            IFeatureSet fs = null, fs2 = null;
            bool selected = false, selected2 = false;

            SendOrPostCallback action = p =>
                {
                    fs = InputLayer.Value;
                    fs2 = InputLayer2.Value;
                    selected = InputLayer.SelectedOnly;
                    selected2 = InputLayer2.SelectedOnly;
                };

            UiThread.Send(action, null);

            var result = fs.Intersection(selected, fs2, selected2, Api.Enums.GeometryType.None);

            if (result != null)
            {
                UiThread.Send(p => HandleOutput(result, Output.Value), null);
                return true;
            }

            return false;
        }
    }
}
