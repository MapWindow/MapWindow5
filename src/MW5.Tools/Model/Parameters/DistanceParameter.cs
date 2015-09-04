using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Model.Parameters
{
    public class DistanceParameter: DoubleParameter
    {
        public override string ToString()
        {
            var distance = Value as Distance;
            return string.Format("{0}: {1:g3}", DisplayName, (distance != null) ? distance.Value : 0.0);
        }
    }
}
