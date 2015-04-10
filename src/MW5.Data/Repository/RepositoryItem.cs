using System;
using MW5.Data.Enums;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class RepositoryItem: IRepositoryItem
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
                case RepositoryItemType.Database:
                    return new DatabaseItem(node);
                case RepositoryItemType.DatabaseLayer:
                    return new DatabaseLayerItem(node);
            }

            throw new ApplicationException("Invalid repository item type.");
        }

        public void Refresh()
        {
            _node.ExpandedOnce = false;

            _node.Nodes.Clear();

            Expand();
        }

        public bool Loaded
        {
            get { return _node.ExpandedOnce; }
        }
    }
}
