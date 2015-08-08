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
            return string.Format("{0}: {1:g3}", DisplayName, Value.Value);
        }

        public new Distance Value
        {
            get { return Control.GetValue() as Distance; }
        }
    }
}
