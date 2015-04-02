using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Services
{
    public interface ITempFileService
    {
        void DeleteAll();
        void Register(string name);
        string GetTempFilename(string extensionWithDot);
    }
}
