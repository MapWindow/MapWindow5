using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Services
{
    public interface IErrorService
    {
        void Report(Exception ex);
    }
}
