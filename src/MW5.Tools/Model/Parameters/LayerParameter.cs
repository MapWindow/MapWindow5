using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Parameters
{
    public class LayerParameter: LayerParameterBase<ILayerSource>
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Value.Filename);
        }
    }
}
