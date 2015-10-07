using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Tools.Helpers;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents a GIS tool that writes shapefile output in the append mode.
    /// </summary>
    public abstract class AppendModeGisTool: GisTool
    {
        /// <summary>
        /// Tries to save output if we are running in the append mode.
        /// </summary>
        protected bool TrySaveForAppendMode(OutputLayerInfo output, IFeatureSet fsNew)
        {
            if (!output.MemoryLayer)
            {
                if (!OutputManager.SaveAppendModeFeatureSet(fsNew, output, Log))
                {
                    fsNew.Dispose();
                    return false;
                }
            }

            return true;
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
                if (output.Result != null)
                {
                    var fs = output.Result as IFeatureSet;
                    if (fs != null)
                    {
                        fs.StopAppendMode();
                        fs.Dispose();
                    }

                    output.Result = null;
                }

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
