using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Data.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Model;
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

        public void Clear()
        {
            _nodes.Clear();
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

        public IServerItem AddServer(GeoDatabaseType databaseType)
        {
            var node = CreateNode(RepositoryItemType.Server);
            node.LeftImageIndices = new[] { GetServerIcon(databaseType) };
            node.Text = databaseType.EnumToString();
            node.TagObject = new ServerItemMetadata(databaseType);
            node.ExpandedOnce = true;
            return AddNode(node) as IServerItem;
        }

        public IFolderItem AddFolder(string path, bool root)
        {
            var info = new DirectoryInfo(path);
            var node = CreateNode(RepositoryItemType.Folder);
            node.Text = root ? path : info.Name;
            node.TagObject = new FolderItemMetadata(path, root);
            return AddNode(node) as IFolderItem;
        }

        public ITmsItem AddTmsProvider(TmsProvider provider)
        {
            var node = CreateNode(RepositoryItemType.TmsSource);
            node.Text = provider.Name;
            node.TagObject = new TmsItemMetadata(provider);
            node.ExpandedOnce = true;
            return AddNode(node) as ITmsItem;
        }

        public IGroupItem AddGroup(RepositoryGroup group)
        {
            var node = CreateNode(RepositoryItemType.Group);
            node.Text = group.Name;
            node.TagObject = new GroupItemMetadata(group);
            return AddNode(node) as IGroupItem;
        }

        public IDatabaseItem AddDatabase(DatabaseConnection connection)
        {
            var node = CreateNode(RepositoryItemType.Database);
            node.Text = connection.Name;
            node.TagObject = new DatabaseItemMetadata(connection);
            return AddNode(node) as IDatabaseItem;
        }

        public IDatabaseLayerItem AddDatabaseLayer(IVectorLayer layer, bool multipleGeometries= false)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            Logger.Current.Debug("In AddDatabaseLayer " + layer.Name);

            var node = CreateNode(RepositoryItemType.DatabaseLayer);
            node.LeftImageIndices = new[] { GetVectorIcon(layer.ActiveGeometryType) };

            node.Text = layer.Name;
            if (multipleGeometries)
            {
                node.Text += @" [" + layer.ActiveGeometryType + @"]";
            }

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

            AssignCustomFileIcons(node, filename, itemType);

            return AddNode(node) as IFileItem;
        }

        private void AssignCustomFileIcons(TreeNodeAdv node, string filename, RepositoryItemType itemType)
        {
            if (itemType == RepositoryItemType.Vector && filename.ToLower().EndsWith(".shp"))
            {
                var type = ShapefileHelper.GetGeometryType(filename);
                node.LeftImageIndices = new[] { GetVectorIcon(type) };
            }

            if (filename.ToLower().EndsWith(".vrt"))
            {
                node.LeftImageIndices = new[] { (int)RepositoryIcon.VrtFile };
            }

            if (filename.ToLower().EndsWith(".sqlite"))
            {
                node.LeftImageIndices = new[] { (int)RepositoryIcon.Sqlite };
            }
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

        private static int GetServerIcon(GeoDatabaseType type)
        {
            switch (type)
            {
                case GeoDatabaseType.PostGis:
                    return (int)RepositoryIcon.PostGis;
                case GeoDatabaseType.SpatiaLite:
                    return (int)RepositoryIcon.Sqlite;
                case GeoDatabaseType.MsSql:
                    return (int) RepositoryIcon.MsSql;
                case GeoDatabaseType.MySql:
                    return (int)RepositoryIcon.MySql;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
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
                case RepositoryItemType.TmsRoot:
                    return (int)RepositoryIcon.TmsRoot;
                case RepositoryItemType.TmsSource:
                    return (int)RepositoryIcon.TmsItem;
                case RepositoryItemType.FileSystem:
                    return (int)RepositoryIcon.FileSystem;
                case RepositoryItemType.Folder:
                case RepositoryItemType.Group:
                    return (int)RepositoryIcon.Folder;
                case RepositoryItemType.Vector:
                case RepositoryItemType.DatabaseLayer:
                    return (int)RepositoryIcon.Geometry;
                case RepositoryItemType.Image:
                    return (int)RepositoryIcon.Raster;
                case RepositoryItemType.Databases:
                    return (int)RepositoryIcon.Databases;
                case RepositoryItemType.Database:
                case RepositoryItemType.Server:
                    return (int)RepositoryIcon.Database;
            }

            throw new ApplicationException("Unexpected repository item type.");
        }

        public void UpdateState(HashSet<LayerIdentity> filenames)
        {
            foreach (var item in this)
            {
                var file = item as ILayerItem;
                if (file != null)
                {
                    bool selected = filenames.Contains(file.Identity);
                    file.AddedToMap = selected;
                }

                var folder = item as IExpandableItem;
                if (folder != null)
                {
                    RefreshFolder(folder, filenames);

                    item.SubItems.UpdateState(filenames);
                }
            }
        }

        /// <summary>
        /// Forcing refresh for folders containing layer which triggered the update if
        /// this layer isn't yet present.
        /// </summary>
        private void RefreshFolder(IExpandableItem folder, IEnumerable<LayerIdentity> filenames)
        {
            // perhaps this can be done for all layers without checking ForceRefresh flag
            // but let's see its affect on performace first
            var layers = filenames.Where(layer => layer.ForceRefresh);
            
            foreach (var layer in layers)
            {
                if (folder.IsParentOf(layer))
                {
                    var subs = folder.SubItems.OfType<ILayerItem>();
                    var list = subs.Select(s => s.Identity).ToList();

                    if (!list.Contains(layer))
                    {
                        folder.Refresh();
                        break;
                    }
                }
            }
        }
    }
}
