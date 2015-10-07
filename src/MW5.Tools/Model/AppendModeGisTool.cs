using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Tools.Helpers;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents a GIS tool that writes shapefile output in the append mode.
    /// </summary>
    public abstract class AppendModeGisTool: GisTool
    {
        /// <summary>
        /// Validates the values of parameters.
        /// </summary>
        public override bool Validate()
        {
            bool result = base.Validate();

            // in append mode we have to create datasource before the run;
            // the native methods return failure if the file already exists
            OutputManager.DeleteOutputs(this);

            return result;
        }

        /// <summary>
        /// A method called after the main IGisTool.Run method is successfully finished.
        /// Is executed on the UI thread. Typically used to save output datasources.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            var output = this.GetOutputs().FirstOrDefault();

            if (output != null && !output.MemoryLayer)
            {
                // the append mode will close the append mode and datasource,
                // so we only need to add it to the map if it's requested by user
                if (output.AddToMap)
                {
                    var fs = new FeatureSet(output.Filename);
                    OutputManager.AddToMap(fs);
                    return true;
                }

                return true;
            }

            return base.AfterRun();
        }
    }
}
