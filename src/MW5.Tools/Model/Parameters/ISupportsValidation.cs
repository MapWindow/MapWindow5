using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    interface ISupportsValidation
    {
        bool Validate(out string errorMessage);
    }
}
