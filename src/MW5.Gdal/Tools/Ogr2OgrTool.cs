using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
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
    public partial class Ogr2OgrTool: GdalTool
    {
        private DatasourceDriver _outputFormat;

        [Input("Input filename", 0)]
        [ParameterType(ParameterType.VectorFilename)]
        public string InputFilename { get; set; }

        [Output("Output format", 0)]
        [ParameterType(ParameterType.Combo)]
        public DatasourceDriver OutputFormat
        {
            get
            {
                return _outputFormat;
            }
            set
            {
                _outputFormat = value;
            }
        }

        [Output("Output", 1)]
        [OutputLayer("{input}_conv.shp", LayerType.Shapefile, false)]
        public override OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Initializes the command line options.
        /// </summary>
        protected override void InitCommandLine(CommandLineMapping mapping)
        {
            // TODO: implement
            mapping.Get<Ogr2OgrTool>()
                .SetKey(t => t.OutputFormat, "-f");
        }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, MW5.Tools.Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var drivers = GetDrivers().ToList();
            var sf = drivers.FirstOrDefault(f => f.Name.ToLower() == GdalFormats.Shapefile);

            configuration.Get<Ogr2OgrTool>()
                 .AddComboList(t => t.OutputFormat, drivers)
                 .SetDefault(t => t.OutputFormat, sf);
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
            get { return "Convert vector"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Converts simple features data between file formats."; }
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected override bool DriverFilter(DatasourceDriver driver)
        {
            return driver.IsVector;
        }

        /// <summary>
        /// Gets command line options.
        /// </summary>
        public override string GetOptions(bool mainOnly = false)
        {
            string s = base.GetOptions(mainOnly);

            return string.Format("-f {0} {1}", OutputFormat.Name, s);
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            string options = GetOptions();
            bool result = GdalUtils.Instance.Ogr2Ogr(InputFilename, Output.Filename, options);
            return result;
        }
    }
}
