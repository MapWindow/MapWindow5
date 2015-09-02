using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;

namespace MW5.Tools.Model.Parameters
{
    internal class VectorLayerParameter: LayerParameterBase<IFeatureSet>
    {
        public override DataSourceType DataSourceType
        {
            get { return DataSourceType.Vector; }
        }

        public override object Value
        {
            get { return new VectorLayerInfo(base.Datasource, SelectedOnly);  }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Path.GetFileName(Datasource.Filename));
        }
    }
}
