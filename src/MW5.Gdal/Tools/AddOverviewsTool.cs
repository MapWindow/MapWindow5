using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Static;
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
    [GisTool(GroupKeys.GdalTools, ToolIcon.Hammer, typeof(GdalPresenter))]
    public class AddOverviewsTool: GdalTool
    {
        [ControlHint(ControlHint.Filename)]
        [DataTypeHint(DataSourceType.Raster)]
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        [Input("Band", 1)]
        public string BandIndex { get; set; }

        [Input("Read only (external overviews)", 2)]
        public bool ReadOnly { get; set; }

        [Input("Remove existing overviews", 3)]
        public bool Clean { get; set; }

        [Input("Resampling", 0, true)]
        [ControlHint(ControlHint.Combo)]
        public string Resampling { get; set; }

        [Output("Overview levels", 1)]
        public string Levels { get; set; }

        /// <summary>
        /// Initializes the command line options.
        /// </summary>
        protected override void InitCommandLine(CommandLineMapping mapping)
        {
            mapping.Get<AddOverviewsTool>()
                .SetKey(t => t.Resampling, "-r")
                .SetKey(t => t.BandIndex, "-b")
                .SetKey(t => t.ReadOnly, "-ro")
                .SetKey(t => t.Clean, "-clean");
        }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var resampling = new[]  { "", "nearest", "average", "gauss", "cubic", "cubicspline", "lanczos", "average_mp",
                               "average_magphase", "mode" };

            configuration.Get<AddOverviewsTool>()
                .AddComboList(t => t.Resampling, resampling);
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected override bool DriverFilter(DatasourceDriver driver)
        {
            return driver.IsRaster;
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Add overviews"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Builds or rebuilds overview images for raster datasources."; }
        }

        /// <summary>
        /// Gets the name to be displayed as a name of the task.
        /// </summary>
        public override string TaskName
        {
            get { return "Overviews: " + InputFilename; }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            string options = GetOptions();

            return GdalUtils.Instance.GdalAddOverviews(InputFilename, options, Levels);
        }

        public override bool AfterRun()
        {
            // do nothing
            return true;
        }
    }
}
