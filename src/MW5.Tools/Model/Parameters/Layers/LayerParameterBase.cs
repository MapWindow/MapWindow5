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
        public abstract DataSourceType DataSourceType {get; }

        public abstract ILayerSource Datasource { get; }

        public override bool HasDatasource
        {
            get { return true; }
        }

        public override string ToString()
        {
            var ds = Datasource;
            string filename = ds != null ? Path.GetFileName(Datasource.Filename) : string.Empty;
            return string.Format("{0}: {1}", DisplayName, filename);
        }

        public IEnumerable<ILayerInfo> BatchModeList
        {
            get
            {
                var blpc = Control as BatchLayerParameterControl;
                if (blpc != null)
                {
                    return blpc.Layers;
                }

                return new List<ILayerInfo>();
            }
        }
    }
}