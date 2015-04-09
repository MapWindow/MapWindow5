using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
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
