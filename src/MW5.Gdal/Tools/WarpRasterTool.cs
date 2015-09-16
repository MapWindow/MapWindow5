// -------------------------------------------------------------------------------------------
// <copyright file="WarpRasterTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
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
    public partial class WarpRasterTool : GdalRasterTool
    {
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var resampling = new[] { "", "near", "bilinear", "cubic", "cubicspline", "lanczos", "average", "mode", "max", "min", "med", "q1", "q3" };

            var dataTypes = GdalHelper.GetRasterDataTypes().ToList();
            dataTypes.Insert(0, "<autodetect>");

            configuration.Get<WarpRasterTool>()
                .AddComboList(t => t.DstResampling, resampling)
                .AddComboList(t => t.WorkingPixelsType, dataTypes);
        }

        protected override void InitCommandLine()
        {
            _commandLine.Get<WarpRasterTool>()
                .SetKey(t => t.AlignPixelsToResolution, "-tap")
                .SetKey(t => t.CopyColorIntepretation, "-setci")
                .SetKey(t => t.DstAlpha, "-dstalpha")
                .SetKey(t => t.DstNoDataValue, "-dstnodata")
                .SetKey(t => t.DstNoMetadata, "-nomd")
                .SetKey(t => t.DstResampling, "-r")
                .SetKey(t => t.ErrorThreshhold, "-et")
                .SetKey(t => t.GeolocationArrays, "-geoloc")
                .SetKey(t => t.MemoryLimitMb, "-mw")
                .SetKey(t => t.OutputType, "-ot")
                .SetKey(t => t.Quiet, "-q")
                .SetKey(t => t.RefineGcp, "-refine_gcps")
                .SetKey(t => t.RpcCoefficients, "-rpc")
                .SetKey(t => t.SourceNoDataValue, "-srcnodata")
                .SetKey(t => t.SourceOverviewLevel, "-ovr")
                .SetKey(t => t.SourceProjection, "-s_srs")
                .SetKey(t => t.TargetExtents, "-te")
                .SetKey(t => t.TargetExtentsProjection, "-te_srs")
                .SetKey(t => t.TargetProjection, "-t_srs")
                .SetKey(t => t.TargetResolution, "-tr")
                .SetKey(t => t.TargetSize, "-ts")
                .SetKey(t => t.TpsTransformer, "-tps")
                .SetKey(t => t.UseMultithreading, "-multi")
                .SetKey(t => t.WorkingPixelsType, "-wt");
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Image reprojection and warping utility."; }
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Warp raster"; }
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
            get { return "Warp: " + Path.GetFileName(Output.Filename); }
        }

        public override string GetOptions(bool mainOnly = false)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("-of {0} ", OutputFormat.Name);

            string options = _commandLine.Complile(this);
            sb.Append(options);

            sb.Append(DriverOptions + @" ");

            if (!mainOnly)
            {
                sb.Append(@" " + AdditionalOptions);
            }

            if (Output.Overwrite)
            {
                sb.Append("-overwrite ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            string options = GetOptions();

            bool result = GdalUtils.Instance.WarpRaster(InputFilename, Output.Filename, options);

            if (!result)
            {
                string s = string.Format("Failed to reprojected raster datasource {0}. Options: {1}", InputFilename, options);
                Log.Error(s, null);
                return false;
            }

            if (!File.Exists(Output.Filename))
            {
                Log.Info(@"The process did finish successfully. But the resulting file was not created.");
                return false;
            }

            Log.Info("Raster datasource was reprojected: " + Output.Filename);

            return true;
        }
    }
}