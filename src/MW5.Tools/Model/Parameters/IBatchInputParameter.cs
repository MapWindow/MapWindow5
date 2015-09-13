using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    interface IBatchInputParameter
    {
        object BatchInputs { get; }

        bool HasBatchInputs { get; }
    }
}
