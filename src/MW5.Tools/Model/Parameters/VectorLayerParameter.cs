using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;

namespace MW5.Tools.Model.Parameters
{
    public class VectorLayerParameter: LayerParameterBase<IFeatureSet>
    {
        public override DataSourceType DataSourceType
        {
            get { return DataSourceType.Vector; }
        }
    }
}
