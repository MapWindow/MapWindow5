using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
{
    public class FolderItem: RepositoryItem, IFolderItem
    {
        private const string SearchRegex = @"$(?<=\.(shp|kml))";

        public FolderItem(TreeNodeAdv node) : base(node)
        {
            
        }

        private FolderItemMetadata Metadata
        {
            get
            {
                var data = _node.TagObject as FolderItemMetadata;
                if (data == null)
                {
                    throw new InvalidCastException("FolderItemMetadata object is expected");
                }

                return data;
            }
        }

        public string GetPath()
        {
            return Metadata.Path;
        }

        public bool Loaded
        {
            get { return _node.ExpandedOnce; }
        }

        public bool Root
        {
            get { return Metadata.Root; }
        }

        public void Refresh()
        {
            _node.ExpandedOnce = false;

            _node.Nodes.Clear();

            Expand();
        }

        public void Expand()
        {
            if (_node.ExpandedOnce) return;
            
            string root = GetPath();
            var items = SubItems;
            
            foreach (var path in Directory.EnumerateDirectories(root))
            {
                var folder = CreateFolder(path, false);
                items.Add(folder, false);
            }

            var pattern = new Regex(SearchRegex, RegexOptions.IgnoreCase);
            var files = Directory.EnumerateFiles(root).Where(f => pattern.IsMatch(f));

            foreach (var f in files)
            {
                var vector = CreateVector(f);
                items.Add(vector, false);
            }

            _node.ExpandedOnce = true;
        }
    }
}
