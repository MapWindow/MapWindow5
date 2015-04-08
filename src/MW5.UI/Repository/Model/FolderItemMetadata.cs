using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Repository.Model
{
    public class FolderItemMetadata
    {
        public FolderItemMetadata(string path, bool root)
        {
            Path = path;
            Root = root;
        }

        public string Path { get; private set; }

        public bool Root { get; private set; }
    }
}
