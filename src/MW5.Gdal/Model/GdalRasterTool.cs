using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Gdal.Tools;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Services;

namespace MW5.Gdal.Model
{
    /// <summary>
    /// A base tool for translate raster and warp raster.
    /// </summary>
    public abstract class GdalRasterTool: GdalTool
    {
        // The UI for them will be generated dynamically depending on driver
        public string DriverOptions { get; set; }

        [ParameterType(ParameterType.RasterFilename)]
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        public virtual string OutputType { get; set; }

        [Output("Output format", 0)]
        [ParameterType(ParameterType.Combo)]
        public DatasourceDriver OutputFormat { get; set; }

        [Output("Output filename", 1)]
        [OutputLayer("{input}_tr.tif", Api.Enums.LayerType.Image, false)]
        public OutputLayerInfo Output { get; set; }

        [Input("Additional options", -1)]
        [ParameterType(ParameterType.MultiLineString)]
        public override string AdditionalOptions { get; set; }

        /// <summary>
        /// Configures the specified context.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var drivers = GetRasterDrivers().ToList();
            var gtiff = drivers.FirstOrDefault(f => f.Name.ToLower() == "gtiff");

            configuration.Get<GdalRasterTool>()
                .AddComboList(t => t.OutputFormat, drivers)
                .SetDefault(t => t.OutputFormat, gtiff);
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        private IEnumerable<DatasourceDriver> GetRasterDrivers()
        {
            var result = new List<DatasourceDriver>();

            var manager = new DriverManager();
            var drivers = manager.Where(d => d.IsRaster).ToList();
            var filters = GetRasterFilters().ToList();

            foreach (var d in drivers)
            {
                foreach (var filter in filters)
                {
                    if (d.MatchesFilter(filter))
                    {
                        result.Add(d);
                        break;
                    }
                }
            }

            return result.OrderBy(n => n.Name).ToList();
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected abstract IEnumerable<DriverFilter> GetRasterFilters();

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
