using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Data.Enums;
using MW5.Plugins.Concrete;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
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
            return AddNode(node);
        }

        public IFolderItem AddFolder(string path, bool root)
        {
            var info = new DirectoryInfo(path);
            var node = CreateNode(RepositoryItemType.Folder);
            node.Text = root ? path : info.Name;
            node.TagObject = new FolderItemMetadata(path, root);
            return AddNode(node) as IFolderItem;
        }

        public IDatabaseItem AddDatabase(DatabaseConnection connection)
        {
            var node = CreateNode(RepositoryItemType.Database);
            node.Text = connection.Name;
            node.TagObject = new DatabaseItemMetadata(connection);
            return AddNode(node) as IDatabaseItem;
        }

        public IDatabaseLayerItem AddDatabaseLayer(IVectorLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            var node = CreateNode(RepositoryItemType.DatabaseLayer);
            node.LeftImageIndices = new[] { GetVectorIcon(layer.GeometryType) };
            node.Text = layer.Name;
            node.TagObject = new DatabaseLayerMetadata(layer);
            node.ExpandedOnce = true;
            return AddNode(node) as IDatabaseLayerItem;
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

            return AddNode(node) as IFileItem;
        }

        private static TreeNodeAdv CreateNode(RepositoryItemType type)
        {
            return new TreeNodeAdv
            {
                Tag = type,
                LeftImageIndices = new[] { GetIconIndex(type) }
            };
        }
        private IRepositoryItem AddNode(TreeNodeAdv node)
        {
            _nodes.Add(node);
            return RepositoryItem.Get(node);
        }

        private static int GetVectorIcon(GeometryType type)
        {
            switch (type)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return (int)RepositoryIcon.Point;
                case GeometryType.Polyline:
                    return (int)RepositoryIcon.Line;
                case GeometryType.Polygon:
                case GeometryType.None:
                    return (int)RepositoryIcon.Polygon;
            }

            return (int)RepositoryIcon.Polygon;
        }

        private static int GetIconIndex(RepositoryItemType type)
        {
            switch (type)
            {
                case RepositoryItemType.FileSystem:
                    return (int)RepositoryIcon.FileSystem;
                case RepositoryItemType.Folder:
                    return (int)RepositoryIcon.Folder;
                case RepositoryItemType.Vector:
                case RepositoryItemType.DatabaseLayer:
                    return (int)RepositoryIcon.Geometry;
                case RepositoryItemType.Image:
                    return (int)RepositoryIcon.Raster;
                case RepositoryItemType.Databases:
                    return (int)RepositoryIcon.Databases;
                case RepositoryItemType.PostGis:
                    return (int)RepositoryIcon.PostGis;
                case RepositoryItemType.Database:
                    return (int)RepositoryIcon.Database;
            }

            throw new ApplicationException("Unexpected repository item type.");
        }

        public void UpdateState(Dictionary<string, string> filenames)
        {
            foreach (var item in this)
            {
                var file = item as IFileItem;
                if (file != null)
                {
                    bool selected = filenames.ContainsKey(file.Filename.ToLower());
                    file.AddedToMap = selected;
                }

                var folder = item as IFolderItem;
                if (folder != null)
                {
                    folder.SubItems.UpdateState(filenames);
                }
            }
        }
    }
}
