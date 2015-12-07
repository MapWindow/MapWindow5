using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Tools.Raster
{
    [CustomLayout]
    [GisTool(GroupKeys.Raster)]
    public class CreateGridProxyTool: GisTool
    {
        [Input("Input grid filename", 0)]
        [ControlHint(ControlHint.Filename)]
        [DataTypeHint(DataSourceType.Raster)]
        public string Input { get; set; }               // probably grid filename will be more appropriate

        [Input("Proxy format", 1)]
        [ControlHint(ControlHint.Combo)]
        public GridProxyFormat ProxyFormat { get; set; }

        [Input("Color scheme", 2)]
        [ControlHint(ControlHint.Combo)]
        public PredefinedColors ColorScheme { get; set; }

        [Input("Use built in color scheme", 3)]
        public bool UseBuiltInColorScheme { get; set; }

        [Output("Add to map", 0)]
        public bool AddToMap { get; set; }

        [Output("Output", -1)]
        public OutputLayerInfo Output { get; set; }
        

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            Output = new OutputLayerInfo() { SkipValidation = true };

            var formats = EnumHelper.GetValues<GridProxyFormat>();
            var colors = EnumHelper.GetValues<PredefinedColors>();

            configuration.Get<CreateGridProxyTool>()
                .AddComboList(t => t.ProxyFormat, formats)
                .AddComboList(t => t.ColorScheme, colors);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Create grid proxy"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Creates an RGB image file to be used for fast visualisation of the grid."; }
        }

        public override string TaskName
        {
            get { return "Proxy: " + Path.GetFileName(Input); }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            using (var grid = new GridSource(Input))
            {
                RasterColorScheme rcs = null;

                if (UseBuiltInColorScheme)
                {
                    rcs = grid.RetrieveColorScheme(GridSchemeRetrieval.Auto);
                    if (rcs == null)
                    {
                        Log.Error("No predefined color scheme was found.", null);
                        return false;
                    }
                }
                else
                {
                    rcs = grid.GenerateColorScheme(GridSchemeGeneration.Gradient, ColorScheme);
                }

                MapConfig.GridProxyFormat = ProxyFormat;

                Output.Result = grid.CreateImageProxy(rcs);
            }

            return Output.Result != null;
        }

        /// <summary>
        /// Can be used to save results of the processing or display messages.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            if (AddToMap)
            {
                var img = Output.Result as IImageSource;
                if (OutputManager.AddToMap(img))
                {
                    Output.Filename = img.Filename;
                    Output.DatasourcePointer = new DatasourcePointer(img.Filename);
                    return true;
                }
            }

            Output.Result.Dispose();

            return true;
        }
    }
}
