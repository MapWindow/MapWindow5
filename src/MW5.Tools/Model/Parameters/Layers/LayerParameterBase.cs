// -------------------------------------------------------------------------------------------
// <copyright file="GenericLayerParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Model.Parameters.Layers
{
    internal abstract class LayerParameterBase: BaseParameter
    {
        public abstract DataSourceType DataSourceType { get; }

        public abstract ILayerSource Datasource { get; }

        /// <summary>
        /// Gets or sets the pointer of the datasource that was used during tool execution.
        /// </summary>
        public DatasourcePointer ClosedPointer { get; set; }

        public override bool HasDatasource
        {
            get { return true; }
        }

        public override string ToString()
        {
            var info = Value as IDatasourceInput;
            return string.Format("{0}: {1}", DisplayName, info != null ? info.Name : string.Empty);
        }

        public IEnumerable<IDatasourceInput> BatchModeList
        {
            get
            {
                var blpc = Control as BatchLayerParameterControl;
                if (blpc != null)
                {
                    return blpc.Layers;
                }

                return new List<IDatasourceInput>();
            }
        }
    }
}