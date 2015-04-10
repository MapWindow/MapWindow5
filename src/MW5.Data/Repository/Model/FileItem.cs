using System;
using System.Drawing;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository.Model
{
    internal class FileItem: RepositoryItem, IFileItem
    {
        internal FileItem(TreeNodeAdv node) : base(node)
        {
        }

        private FileItemMetadata Metadata
        {
            get
            {
                var data = _node.TagObject as FileItemMetadata;
                if (data == null)
                {
                    throw new InvalidCastException("VectorItemMetadata object must be stored in the tag.");
                }

                return data;
            }
        }

        public string Filename
        {
            get
            {
                return Metadata.Filename;
            }
        }

        public IFolderItem Folder
        {
            get { return Get(_node.Parent) as IFolderItem; }
        }

        public bool AddedToMap
        {
            get 
            { 
                return Metadata.AddedToMap;
            }
            set
            {
                Metadata.AddedToMap = value;
                _node.Font = new Font(_node.Font, value ? FontStyle.Bold : FontStyle.Regular);
            }
        }
    }
}
