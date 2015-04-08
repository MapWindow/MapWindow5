using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IRepository
    {
        IEnumerable<string> Folders { get; }
        void AddFolderLink(string path);
        void RemoveFolderLink(string path);

        event EventHandler<FolderEventArgs> FolderAdded;
        event EventHandler<FolderEventArgs> FolderRemoved;
    }
}
