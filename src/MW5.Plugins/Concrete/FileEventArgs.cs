using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Concrete
{
    public class FolderEventArgs
    {
        public FolderEventArgs(string path)
        {
            Path = path;
        }
        public string Path { get; private set; }
    }
}
