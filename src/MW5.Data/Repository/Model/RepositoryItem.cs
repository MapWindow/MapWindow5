using System;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository.Model
{
    public class RepositoryItem: IRepositoryItem
    {
        protected readonly TreeNodeAdv _node;

        internal RepositoryItem(TreeNodeAdv node)
        {
            if (node == null) throw new ArgumentNullException("node");
            _node = node;
        }

        public RepositoryItemType Type
        {
            get { return (RepositoryItemType)_node.Tag; }
        }

        public RepositoryItemCollection SubItems
        {
            get { return new RepositoryItemCollection(_node.Nodes); }
        }

        public object GetInternalObject()
        {
            return _node;
        }

        public virtual void Expand()
        {
            _node.Expanded = true;
        }

        public static IRepositoryItem Get(TreeNodeAdv node)
        {
            var type = (RepositoryItemType) node.Tag;

            switch (type)
            {
                case RepositoryItemType.FileSystem:
                case RepositoryItemType.Databases:
                case RepositoryItemType.PostGis:
                    return new RepositoryItem(node);
                case RepositoryItemType.Folder:
                    return new FolderItem(node);
                case RepositoryItemType.Vector:
                case RepositoryItemType.Image:
                    return new FileItem(node);
            }

            throw new ApplicationException("Invalid repository item type.");
        }
    }
}
