using System;
using System.Drawing;
using MW5.Api.Concrete;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class FileItem : MetadataItem<FileItemMetadata>, IFileItem
    {
        internal FileItem(TreeNodeAdv node) : base(node)
        {
        }

        public LayerIdentity Identity
        {
            get { return new LayerIdentity(Filename); }
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
