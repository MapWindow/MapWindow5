// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OverlayTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the Intersection Tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [CustomLayout]
    [GisTool(GroupKeys.Geoprocessing, ToolIcon.Hammer)]
    public class OverlayTool : GisTool
    {
        [Input("First layer", 0)]
        public IVectorInput InputLayer { get; set; }

        [Input("Second layer", 1)]
        public IVectorInput InputLayer2 { get; set; }

        [Input("Operation", 2)]
        [ControlHint(ControlHint.Combo)]
        public ClipOperation Operation { get; set; }

        [Output("Save results as")]
        [OutputLayer("{input}_overlay.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var operations = EnumHelper.GetValues<ClipOperation>();

            configuration.Get<OverlayTool>()
                .AddComboList(t => t.Operation, operations)
                .SetDefault(t => t.Operation, ClipOperation.Intersection);
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get
            {
                return "Performs overlay operation for 2 vector layers. " +
                       "Avaialable operations: clip, difference, intersection, symmetrical difference, union.";
            }
        }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Overlay (multiple operations)"; }
        }

        /// <summary>
        /// Gets the name to be displayed as a name of the task.
        /// </summary>
        public override string TaskName
        {
            get { return InputLayer.Name + ": " + GetShortOperationString(Operation); }
        }

        public override bool SupportsCancel
        {
            get  { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public override bool SupportsBatchExecution
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the short operation string.
        /// </summary>
        private string GetShortOperationString(ClipOperation operation)
        {
            switch (operation)
            {
                case ClipOperation.Difference:
                    return "diff";
                case ClipOperation.Intersection:
                    return "intersect";
                case ClipOperation.SymDifference:
                    return "sym dif.";
                case ClipOperation.Union:
                    return "union";
                case ClipOperation.Clip:
                    return "clip";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (InputHelper.InputsAreEqual(InputLayer, InputLayer2))
            {
                string msg = "The same datasource is used for both input parameters.";
                msg += "The operation is pointless.";
                MessageService.Current.Info(msg);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = InputLayer.Datasource;
            var fs2 = InputLayer2.Datasource;

            switch (Operation)
            {
                case ClipOperation.Difference:
                    Output.Result = fs.Difference(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly);
                    break;
                case ClipOperation.Intersection:
                    Output.Result = fs.Intersection(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly, GeometryType.None);
                    break;
                case ClipOperation.SymDifference:
                    Output.Result = fs.SymmDifference(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly);
                    break;
                case ClipOperation.Union:
                    Output.Result = fs.Union(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly);
                    break;
                case ClipOperation.Clip:
                    Output.Result = fs.Clip(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            return true;
        }
    }
}