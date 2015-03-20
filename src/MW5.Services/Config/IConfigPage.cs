using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Services.Config
{
    public interface IConfigPage
    {
        string PageName { get; }
        void Save();
    }
}
