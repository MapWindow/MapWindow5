// -------------------------------------------------------------------------------------------
// <copyright file="TranslateRasterTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;
using System.Text;
using MW5.Api.Concrete;
using MW5.Api.Static;
using MW5.Gdal.Model;
using MW5.Gdal.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Gdal.Tools
{
    [GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(GdalConvertPresenter))]
    public class TranslateRasterTool : GdalRasterTool
    {
        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Converts raster data between different formats."; }
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Translate raster"; }
        }

        [Input("No data value", 3, true)]
        public string NoData { get; set; }

        [Input("Output type", 1, true)]
        [ControlHint(ControlHint.Combo)]
        public override string OutputType { get; set; }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        [Input("Spatial reference", 8, true)]
        public bool SpatialReference { get; set; }

        [Input("Statistics", 5, true)]
        public bool Stats { get; set; }

        [Input("Strict", 6, true)]
        public bool Strict { get; set; }

        [Input("Subdatasets", 4, true)]
        public bool SubDatasets { get; set; }

        /// <summary>
        /// Gets a value indicating whether current tool can specify driver creation options.
        /// </summary>
        public override bool SupportDriverCreationOptions
        {
            get { return true; }
        }

        public override string TaskName
        {
            get { return "Translate: " + Path.GetFileName(Output.Filename); }
        }

        [Input("Unscale", 7, true)]
        public bool Unscale { get; set; }

        /// <summary>
        /// Gets command line options.
        /// </summary>
        public override string CompileOptions(bool mainOnly = false)
        {
            var s = base.CompileOptions(mainOnly);

            var sb = new StringBuilder(s);

            sb.AppendFormat("-of {0} ", OutputFormat.Name);

            return sb.ToString();
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            string options = GetOptions();

            bool result = GdalUtils.Instance.TranslateRaster(InputFilename, Output.Filename, options);

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

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected override bool DriverFilter(DatasourceDriver driver)
        {
            return driver.IsRaster && driver.MatchesFilter(Api.Enums.DriverFilter.Create) ||
                   driver.MatchesFilter(Api.Enums.DriverFilter.CreateCopy);
        }

        protected override void InitCommandLine(CommandLineMapping mapping)
        {
            _commandLine.Get<TranslateRasterTool>()
                .SetKey(t => t.OutputType, "-ot")
                .SetKey(t => t.NoData, "-a_nodata")
                .SetKey(t => t.SubDatasets, "-sds")
                .SetKey(t => t.Stats, "-stats")
                .SetKey(t => t.Strict, "-strict")
                .SetKey(t => t.SpatialReference, "-a-srs")
                .SetKey(t => t.Unscale, "-unscale");
        }
    }
}