using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Views.Gdal;

namespace MW5.Tools.Tools.Gdal
{
    [GisTool(GroupKeys.GdalTools, Enums.ToolIcon.Hammer, typeof(TranslateRasterCustomPresenter))]
    public class TranslateRasterCustomTool: GisTool
    {
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        [Input("Output filename", 1)]
        public OutputLayerInfo Output { get; set; }

        [Input("Options", 2)]
        public string Options { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Translate raster (MW4 UI)"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Converts raster data between different formats."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        public override bool SupportsCancel
        {
            get { return false; }
        }

        public override string TaskName
        {
            get { return "GDAL Translate: " + Path.GetFileName(Output.Filename); }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var utils = new GeoProcessing { Callback = task.Callback };

            bool result = utils.TranslateRaster(InputFilename, Output.Filename, Options);

            if (!result)
            {
                Log.Error(@"The process did not finish successfully.", null);
                return false;
            }

            if (!File.Exists(Output.Filename))
            {
                Log.Info(@"The process did finish successfully. But the resulting file was not created.");
                return false;
            }

            return true;
        }

        public override bool AfterRun()
        {
            return OutputManager.HandleGdalOutput(Output);
        }
    }
}
