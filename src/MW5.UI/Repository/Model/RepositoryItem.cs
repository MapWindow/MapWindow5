using System;
using System.IO;
using MW5.Api;
using MW5.Api.Helpers;
using MW5.Plugins.Helpers;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
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

        public static IRepositoryItem Get(TreeNodeAdv node)
        {
            var type = (RepositoryItemType) node.Tag;

            switch (type)
            {
                case RepositoryItemType.Folders:
                    return new RepositoryItem(node);
                case RepositoryItemType.Folder:
                    return new FolderItem(node);
                case RepositoryItemType.Vector:
                    return new VectorItem(node);
            }

            throw new ApplicationException("Invalid repository item type.");
        }

        public static IRepositoryItem CreateItem(RepositoryItemType type)
        {
            if (type == RepositoryItemType.Folder || type == RepositoryItemType.Vector)
            {
                throw new InvalidOperationException("Use specific methods to create item of this type.");
            }

            var node = CreateNode(type);
            node.Text = type.EnumToString();

            return new RepositoryItem(node);
        }

        public static IFolderItem CreateFolder(string path, bool root)
        {
            var info = new DirectoryInfo(path);
            var node = CreateNode(RepositoryItemType.Folder);
            node.Text = root ? path : info.Name;            
            node.TagObject = new FolderItemMetadata(path, root);
            return new FolderItem(node);
        }

        public static IVectorItem CreateVector(string filename)
        {
            var node = CreateNode(RepositoryItemType.Vector);
            node.TagObject = new VectorItemMetadata(filename);
            node.ExpandedOnce = true;
            node.Text = Path.GetFileName(filename);

            if (filename.ToLower().EndsWith(".shp"))
            {
                var type = ShapefileHelper.GetGeometryType(filename);
                node.LeftImageIndices =new[] { GetVectorIcon(type) };
            }

            return new VectorItem(node);
        }

        private static TreeNodeAdv CreateNode(RepositoryItemType type)
        {
            return new TreeNodeAdv
            {
                Tag = type, 
                LeftImageIndices = new[] {GetIconIndex(type)}
            };
        }

        private static int GetVectorIcon(GeometryType type)
        {
            switch (type)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return 2;
                case GeometryType.Polyline:
                    return 3;
                case GeometryType.Polygon:
                case GeometryType.None:
                    return 4;
            }

            return 4;
        }

        private static int GetIconIndex(RepositoryItemType type)
        {
            switch (type)
            {
                case RepositoryItemType.Folders:
                    return 0;
                case RepositoryItemType.Folder:
                    return 1;
                case RepositoryItemType.Vector:
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
