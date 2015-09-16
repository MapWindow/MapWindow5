using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
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
        [ParameterType(ParameterType.RasterFilename)]
        [Input("Input filename", 0)]
        public string InputFilename { get; set; }

        [Output("Output format", 0)]
        [ParameterType(ParameterType.Combo)]
        public virtual DatasourceDriver OutputFormat { get; set; }

        [Output("Output filename", 1)]
        [OutputLayer("{input}_tr.tif", LayerType.Image, false)]
        public override OutputLayerInfo Output { get; set; }

        public virtual string OutputType { get; set; }

        /// <summary>
        /// Configures the specified context.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var drivers = GetDrivers().ToList();
            var gtiff = drivers.FirstOrDefault(f => f.Name.ToLower() == GdalFormats.GTiff);

            configuration.Get<GdalRasterTool>()
                .AddComboList(t => t.OutputFormat, drivers)
                .SetDefault(t => t.OutputFormat, gtiff);
        }
    }
}
