// -------------------------------------------------------------------------------------------
// <copyright file="TranslateRasterCustomTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;
using MW5.Api.Static;
using MW5.Gdal.Legacy.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Gdal.Legacy
{
    //[GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(TranslateRasterCustomPresenter))]
    public class TranslateRasterCustomTool : GisTool
    {
        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Converts raster data between different formats."; }
        }

        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Translate raster (MW4 UI)"; }
        }

        [Input("Options", 2)]
        public string Options { get; set; }

        [Input("Output filename", 1)]
        public OutputLayerInfo Output { get; set; }

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

        public override bool AfterRun()
        {
            return OutputManager.HandleGdalOutput(Output);
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var utils = new GdalUtils { Callback = task.Callback };

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
    }
}