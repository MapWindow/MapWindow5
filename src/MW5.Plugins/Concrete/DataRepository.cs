using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Concrete
{
    /// <summary>
    /// A model for repository dock panel
    /// </summary>
    public class DataRepository: IRepository
    {
        private readonly List<string> _folders;

        public DataRepository()
        {
            _folders = new List<string>();
        }

        public IEnumerable<string> Folders
        {
            get { return _folders; }
        }

        public void AddFolderLink(string path)
        {
            if (Directory.Exists(path) && !HasFolder(path))
            {
                _folders.Add(path);
                FireEvent(FolderAdded, path);
            }
        }

        public void RemoveFolderLink(string path)
        {
            if (!HasFolder(path)) return;

            if (_folders.Remove(GetFolder(path)))
            {
                FireEvent(FolderRemoved, path);
            }
        }

        private bool HasFolder(string path)
        {
            return GetFolder(path) != null;
        }

        private string GetFolder(string path)
        {
            return _folders.FirstOrDefault(f => f.EqualsIgnoreCase(path));
        }

        public event EventHandler<FolderEventArgs> FolderAdded;
        public event EventHandler<FolderEventArgs> FolderRemoved;

        private void FireEvent(EventHandler<FolderEventArgs> handler, string path) 
        {
            if (handler != null)
            {
                handler(this, new FolderEventArgs(path));
            }
        }
    }
}
