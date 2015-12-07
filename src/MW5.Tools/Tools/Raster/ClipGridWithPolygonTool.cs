using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Raster
{
    [GisTool(GroupKeys.Raster)]
    public class ClipGridWithPolygonTool: GisTool
    {
        [Input("Input grid filename", 0)]
        [DataTypeHint(DataSourceType.Raster)]
        public IRasterInput Input { get; set; }

        [Input("Polygon vector layer", 1)]
        public IVectorInput Vector { get; set; }

        [Input("Keep grid extents", 2)]
        public bool KeepExtents { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_clipped.{ext}", LayerType.Image, false)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Clip grid with polygon"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Clips grid with a selected polygon: removes rows and columns that are outside polygon extents and " +
                         "sets to no data value pixels that are not within polygon. "; }
        }

        protected override bool BeforeRun()
        {
            if (Vector.Datasource.GeometryType != GeometryType.Polygon)
            {
                MessageService.Current.Info("Invalid type of vector layer. Polygon layer is expected.");
                return false;
            }

            if (Vector.Datasource.NumFeatures != 1 && Vector.Datasource.NumSelected != 1)
            {
                MessageService.Current.Info(
                    "Polygon layer must have exactly one polygon or multiple polygons but only one of them selected.");
                return false;
            }

            return true;
        }

        public override bool SupportsBatchExecution
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        private IGeometry GetPolygon()
        {
            if (Vector.Datasource.NumFeatures == 1)
            {
                return Vector.Datasource.GetGeometry(0);
            }

            if (Vector.Datasource.NumSelected == 1)
            {
                var ft = Vector.Datasource.Features.FirstOrDefault(f => f.Selected);
                return ft != null ? ft.Geometry : null;
            }

            return null;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var poly = GetPolygon();
            if (poly == null)
            {
                Log.Warn("Failed to extract the clip polygon.", null);
                return false;
            }

            if (Output.Overwrite)
            {
                if (!GeoSource.Remove(Output.Filename))
                {
                    Log.Warn("Failed to remove file: " + Output.Filename, null);
                    return false;
                }
            }   

            return GisUtils.Instance.ClipGridWithPolygon(Input.Datasource.Filename, poly, Output.Filename, KeepExtents);
        }

        /// <summary>
        /// A method called after the main IGisTool.Run method is successfully finished.
        /// Is executed on the UI thread. Typically used to save output datasources.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            if (Output.AddToMap && File.Exists(Output.Filename))
            {
                Log.Info("Adding the resulting datasource to the map");

                var raster = BitmapSource.Open(Output.Filename, true);

                OutputManager.AddToMap(raster);
            }

            return true;
        }
    }
}
