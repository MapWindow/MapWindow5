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

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class FixShapefileTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_fix.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Fix shapefile"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Creates a new shapefile by fixing invalid geometries of the current one."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (!Input.Datasource.HasInvalidShapes())
            {
                MessageService.Current.Info("Input shapefile doesn't have invalid shapes.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            IFeatureSet result;

            if (Output.MemoryLayer)
            {
                result = Input.Datasource.FixUpShapes();
            }
            else
            {
                var fs = CreateOutput();

                if (Input.Datasource.FixUpShapes(Input.SelectedOnly, fs));
                {
                    result = fs;
                }
            }

            if (result == null)
            {
                Log.Info("Failed to fix shapefile.");
            }

            Output.Result = result;
            
            return Output.Result != null;
        }
        
        private IFeatureSet CreateOutput()
        {
            // TODO: move to output manager
            var fs = Input.Datasource.Clone();

            if (File.Exists(Output.Filename))
            {
                if (Output.Overwrite)
                {
                    if (!GeoSource.Remove(Output.Filename))
                    {
                        Log.Info("Failed to overwrite.");
                        return null;
                    }
                }
                else
                {
                    Log.Info("Overwrite options isn't selected.");
                    return null;
                }
            }

            if (!fs.SaveAsEx(Output.Filename, true))
            {
                Log.Info("Failed to save resulting datasource: " + fs.LastError);
                return null;
            }

            fs.StartAppendMode();

            return fs;
        }

        public override bool AfterRun()
        {
            if (Output.MemoryLayer)
            {
                return base.AfterRun();
            }
            
            var fs = Output.Result as IFeatureSet;
            if (fs != null)
            {
                fs.StopAppendMode();
                fs.Dispose();

                if (Output.AddToMap)
                {
                    fs = new FeatureSet(Output.Filename);
                    OutputManager.AddToMap(fs);
                }
            }

            return true;
        }
    }
}
