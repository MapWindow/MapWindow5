using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Model
{
    public interface IGdalTool
    {
        string GetOptions(bool mainOnly = false);

        string AdditionalOptions { get; set; }

        StringParameter AdditionalOptionsParameter { get; }
    }
}
