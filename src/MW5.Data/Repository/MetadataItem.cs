using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class MetadataItem<T>: RepositoryItem 
        where T: class, IItemMetadata
    {
        internal MetadataItem(TreeNodeAdv node) : base(node)
        {
        }

        protected T Metadata
        {
            get
            {
                var data = _node.TagObject as IItemMetadata;
                if (data == null)
                {
                    throw new InvalidCastException("FolderItemMetadata object is expected");
                }

                return data as T;
            }
        }
    }
}
