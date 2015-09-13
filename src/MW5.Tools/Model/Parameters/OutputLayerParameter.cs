using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model.Parameters
{
    public class OutputLayerParameter: BaseParameter
    {
        public LayerType LayerType { get; set; }

        public bool SupportInMemory { get; set; }

        public OutputLayerInfo GetValue()
        {
            return Value as OutputLayerInfo;
        }

        public override string ToString()
        {
            var info = GetValue();
            return string.Format("{0}: {1}", DisplayName, info != null ? info.Filename : string.Empty);
        }
    }
}
