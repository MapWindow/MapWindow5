// -------------------------------------------------------------------------------------------
// <copyright file="TranslateRasterTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Static;
using MW5.Gdal.Helpers;
using MW5.Gdal.Model;
using MW5.Gdal.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Services;

namespace MW5.Gdal.Tools
{
    [GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(GdalRasterPresenter))]
    public class TranslateRasterTool : GdalRasterTool
    {
        [Input("Output type", 1, true)]
        [ParameterType(ParameterType.Combo)]
        public string OutputType { get; set; }

        [Input("No data value", 3, true)]
        public string NoData { get; set; }

        [Input("Subdatasets", 4, true)]
        public bool SubDatasets { get; set; }

        [Input("Statistics", 5, true)]
        public bool Stats { get; set; }

        [Input("Strict", 6, true)]
        public bool Strict { get; set; }

        [Input("Unscale", 7, true)]
        public bool Unscale { get; set; }

        [Input("Spatial reference", 8, true)]
        public bool SpatialReference { get; set; }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected override bool DriverFilter(DatasourceDriver driver)
        {
            return driver.IsRaster && driver.MatchesFilter(Api.Enums.DriverFilter.Create) ||
                                      driver.MatchesFilter(Api.Enums.DriverFilter.CreateCopy);
        }

        protected override void InitCommandLine()
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


        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Translate raster"; }
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

        public override bool SupportsBatchExecution
        {
            get { return true; }
        }

        public override bool SupportsCancel
        {
            get { return false; }
        }

        public override string TaskName
        {
            get { return "Translate: " + Path.GetFileName(Output.Filename); }
        }

        public override bool SupportDriverCreationOptions
        {
            get { return true; }
        }
        
        public override string GetOptions(bool mainOnly = false)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("-of {0} ", OutputFormat.Name);

            _commandLine.Complile(this);

            sb.Append(DriverOptions + @" ");

            if (!mainOnly)
            {
                sb.Append(@" " + AdditionalOptions);
            }

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
    }
}