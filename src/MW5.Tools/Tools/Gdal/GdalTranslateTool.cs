using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;
using MW5.Tools.Views.Gdal;

namespace MW5.Tools.Tools.Gdal
{
    [GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(GdalTranslatePresenter))]
    public class GdalTranslateTool: GdalTool
    {
        [ParameterType(ParameterType.RasterFilename)]
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        [Input("Output type", 2, true)]
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

        [Input("Additional options", 9, true)]
        [ParameterType(ParameterType.MultiLineString)]
        public override string AdditionalOptions { get; set; }

        [Output("Output format", 0)]
        [ParameterType(ParameterType.Combo)]
        public DatasourceDriver OutputFormat { get; set; }

        [Output("Output filename", 1)]
        [OutputLayer("{input}_tr.tif", Api.Enums.LayerType.Image, false)]
        public OutputLayerInfo Output { get; set; }

        // The UI for them will be generated dynamically depending on driver
        public string DriverOptions { get; set; }

        /// <summary>
        /// Configures the specified context.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var drivers = GetWritableRasterDrivers().ToList();
            var gtiff = drivers.FirstOrDefault(f => f.Name.ToLower() == "gtiff");

            configuration.Get<GdalTranslateTool>()
                .AddComboList(t => t.OutputFormat, drivers)
                .SetDefault(t => t.OutputFormat, gtiff);
            
            //.SetDefault(t => t.DisplayOptionsDialog, AppConfig.Instance.ToolShowGdalOptionsDialog);
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        private IEnumerable<DatasourceDriver> GetWritableRasterDrivers()
        {
            var manager = new DriverManager();
            var drivers = manager.Where(d => d.IsRaster && d.MatchesFilter(Api.Enums.DriverFilter.Create));
            return drivers.OrderBy(n => n.Name).ToList();
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "GDAL Translate"; }
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
            get { return "GDAL Translate: " + Path.GetFileName(Output.Filename); }
        }

        public override string GetOptions(bool mainOnly = false)
        {
             var sb = new StringBuilder();
             sb.AppendFormat("-of {0} ", OutputFormat.Name);

            if (OutputType != GdalDriverHelper.SameAsInputDataType)
            {
                sb.AppendFormat("-ot {0} ", OutputType);   
            }

            if (!string.IsNullOrWhiteSpace(NoData))
            {
                sb.AppendFormat("-a_nodata {0} ", NoData);
            }

            if (SubDatasets)  sb.Append("-sds " + SubDatasets);
            if (Stats)  sb.Append("-stats ");
            if (Strict)  sb.Append("-strict ");
            if (SpatialReference)  sb.Append("-a-srs ");
            if (Unscale) sb.Append("-unscale ");

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
            GeoProcessing.Callback = task.Callback;

            string options = GetOptions();

            bool result = GeoProcessing.TranslateRaster(InputFilename, Output.Filename, options);

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
        /// Can be used to save results of the processing or display messages.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            return OutputManager.HandleGdalOutput(Output);
        }
    }
}
