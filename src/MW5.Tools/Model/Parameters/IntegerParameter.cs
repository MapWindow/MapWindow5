using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public class IntegerParameter: NumericParameter<int>
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Value);
        }
    }
}
