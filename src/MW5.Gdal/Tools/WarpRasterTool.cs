// -------------------------------------------------------------------------------------------
// <copyright file="WarpRasterTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MW5.Api.Concrete;
using MW5.Api.Static;
using MW5.Gdal.Helpers;
using MW5.Gdal.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Services;

namespace MW5.Gdal.Tools
{
    [GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(TranslateRasterPresenter))]
    public partial class WarpRasterTool : GdalTool
    {
        [Input("Additional options", -1)]
        [ParameterType(ParameterType.MultiLineString)]
        public override string AdditionalOptions { get; set; }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Image reprojection and warping utility."; }
        }

        // The UI for them will be generated dynamically depending on driver
        public string DriverOptions { get; set; }

        [ParameterType(ParameterType.RasterFilename)]
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Warp raster"; }
        }

        [Output("Output filename", 1)]
        [OutputLayer("{input}_tr.tif", Api.Enums.LayerType.Image, false)]
        public OutputLayerInfo Output { get; set; }

        [Output("Output format", 0)]
        [ParameterType(ParameterType.Combo)]
        public DatasourceDriver OutputFormat { get; set; }

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
            get { return "Warp: " + Path.GetFileName(Output.Filename); }
        }

        /// <summary>
        /// Can be used to save results of the processing or display messages.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            return OutputManager.HandleGdalOutput(Output);
        }

        public override string GetOptions(bool mainOnly = false)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("-of {0} ", OutputFormat.Name);

            if (OutputType != GdalDriverHelper.SameAsInputDataType)
            {
                sb.AppendFormat("-ot {0} ", OutputType);
            }

            //if (!string.IsNullOrWhiteSpace(NoData))
            //{
            //    sb.AppendFormat("-a_nodata {0} ", NoData);
            //}

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
            var utils = new GdalUtils { Callback = task.Callback };

            string options = GetOptions();

            bool result = utils.WarpRaster(InputFilename, Output.Filename, options);

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
        /// Configures the specified context.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var drivers = GetWritableRasterDrivers().ToList();
            var gtiff = drivers.FirstOrDefault(f => f.Name.ToLower() == "gtiff");

            configuration.Get<TranslateRasterTool>()
                .AddComboList(t => t.OutputFormat, drivers)
                .SetDefault(t => t.OutputFormat, gtiff);
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        private IEnumerable<DatasourceDriver> GetWritableRasterDrivers()
        {
            var manager = new DriverManager();
            var drivers =
                manager.Where(
                    d =>
                    d.IsRaster &&
                    (d.MatchesFilter(Api.Enums.DriverFilter.Create) ||
                     d.MatchesFilter(Api.Enums.DriverFilter.CreateCopy)));
            return drivers.OrderBy(n => n.Name).ToList();
        }
    }
}