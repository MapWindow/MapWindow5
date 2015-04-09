using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
{
    public class RepositoryItemCollection : IEnumerable<IRepositoryItem>
    {
        private readonly TreeNodeAdvCollection _nodes;

        internal RepositoryItemCollection(TreeNodeAdvCollection nodes)
        {
            if (nodes == null) throw new ArgumentNullException("nodes");
            _nodes = nodes;
        }

        public void Remove(IRepositoryItem item)
        {
            _nodes.Remove(item.GetInternalObject());
        }

        public IEnumerator<IRepositoryItem> GetEnumerator()
        {
            foreach (TreeNodeAdv node in _nodes)
            {
                yield return RepositoryItem.Get(node);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IRepositoryItem AddItem(RepositoryItemType type)
        {
            if (type == RepositoryItemType.Folder || type == RepositoryItemType.Vector)
            {
                throw new InvalidOperationException("Use specific methods to create item of this type.");
            }

            var node = CreateNode(type);
            node.Text = type.EnumToString();

            _nodes.Add(node);

            return new RepositoryItem(node);
        }

        public IFolderItem AddFolder(string path, bool root)
        {
            var info = new DirectoryInfo(path);
            var node = CreateNode(RepositoryItemType.Folder);
            node.Text = root ? path : info.Name;
            node.TagObject = new FolderItemMetadata(path, root);

            _nodes.Add(node);

            return new FolderItem(node);
        }

        public IFileItem AddFileImage(string filename)
        {
            return CreateFileItem(filename, RepositoryItemType.Image);
        }

        public IFileItem AddFileVector(string filename)
        {
            return CreateFileItem(filename, RepositoryItemType.Vector);
        }

        private IFileItem CreateFileItem(string filename, RepositoryItemType itemType)
        {
            var node = CreateNode(itemType);
            node.TagObject = new FileItemMetadata(filename);
            node.ExpandedOnce = true;
            node.Text = Path.GetFileName(filename);

            if (itemType == RepositoryItemType.Vector && filename.ToLower().EndsWith(".shp"))
            {
                var type = ShapefileHelper.GetGeometryType(filename);
                node.LeftImageIndices = new[] { GetVectorIcon(type) };
            }

            _nodes.Add(node);

            return new FileItem(node);
        }

        private static TreeNodeAdv CreateNode(RepositoryItemType type)
        {
            return new TreeNodeAdv
            {
                Tag = type,
                LeftImageIndices = new[] { GetIconIndex(type) }
            };
        }

        private static int GetVectorIcon(GeometryType type)
        {
            switch (type)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return (int)RepositorIcon.Point;
                case GeometryType.Polyline:
                    return (int)RepositorIcon.Line;
                case GeometryType.Polygon:
                case GeometryType.None:
                    return (int)RepositorIcon.Polygon;
            }

            return (int)RepositorIcon.Polygon;
        }

        private static int GetIconIndex(RepositoryItemType type)
        {
            switch (type)
            {
                case RepositoryItemType.FileSystem:
                    return (int)RepositorIcon.FileSystem;
                case RepositoryItemType.Folder:
                    return (int)RepositorIcon.Folder;
                case RepositoryItemType.Vector:
                    return (int)RepositorIcon.Geometry;
                case RepositoryItemType.Image:
                    return (int)RepositorIcon.Raster;
                case RepositoryItemType.Databases:
                    return (int)RepositorIcon.Databases;
                case RepositoryItemType.PostGis:
                    return (int)RepositorIcon.PostGis;
                case RepositoryItemType.Database:
                    return (int)RepositorIcon.Database;
            }

            throw new ApplicationException("Unexpected repository item type.");
        }
    }
}
