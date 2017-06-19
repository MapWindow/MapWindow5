using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class DatabaseItem: MetadataItem<DatabaseItemMetadata>, IDatabaseItem
    {
        private readonly VectorDatasource _datasource = new VectorDatasource();
        private SynchronizationContext _syncContext;

        internal DatabaseItem(TreeNodeAdv node) : base(node)
        {
        }

        public DatabaseConnection Connection
        {
            get { return Metadata.Connection; }
        }

        public bool Expanded
        {
            get { return _node.Expanded; }
        }

        public override void Expand()
        {
            if (_node.ExpandedOnce) return;

            var data = Metadata;
            
            ShowLoadingIndicator(_node);

            Application.DoEvents();

            _syncContext = SynchronizationContext.Current;
            Logger.Current.Trace("In Expand");

            Task.Factory.StartNew(d => LoadLayers(d as DatabaseItemMetadata), data).ContinueWith(t =>
                {
                    try
                    {
                        bool result = t.Result;
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Info("Failed to to load OGR layers.", ex);
                    }
                    finally
                    {
                        HideLoadingIndicator(_node);
                        _datasource.Close();
                        Logger.Current.Debug("Called _datasource.Close()");
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());

            _node.ExpandedOnce = true;
        }

        private bool LoadLayers(DatabaseItemMetadata data)
        {
            Logger.Current.Trace("Loading layers");
            
            if (!_datasource.Open(data.Connection.ConnectionString))
            {
                Logger.Current.Debug("Could not open connectionstring: " + data.Connection.ConnectionString);
                return false;
            }

            var it = _datasource.GetFastEnumerator();

            while (it.MoveNext())
            {
                var layer = it.Current;

                if (Metadata.Connection.DatabaseType == Plugins.Enums.GeoDatabaseType.MySql &&
                    string.IsNullOrWhiteSpace(layer.GeometryColumnName))
                {
                    // MySQL driver lists all tables as layers even if they don't have geometry column
                    continue;
                }
                
                if (layer.GeometryType == GeometryType.None)
                {
                    var types = layer.AvailableGeometryTypes.ToList();

                    bool multipleGeometries = types.Count > 1;

                    foreach (var type in types)
                    {
                        // layer reference doesn't stay opened,
                        // so spare adding another parameter to AddDatabaseLayer when it can be read from property
                        layer.SetActiveGeometryType(type.GeometryType, type.ZValueType);
                        AddLayerNode(new VectorLayerWrapper(layer, multipleGeometries));
                    }
                }
                else
                {
                    AddLayerNode(new VectorLayerWrapper(layer, false));
                }
            }

            return true;
        }

        private void AddLayerNode(VectorLayerWrapper layer)
        {
            Logger.Current.Trace("AddLayerNode (Post): " + layer.Layer.Name);
            _syncContext.Send(o =>
            {
                var l = o as VectorLayerWrapper;
                if (l != null)
                {
                    SubItems.AddDatabaseLayer(l.Layer, l.MultipleGeometries);
                    Logger.Current.Trace(l.Layer.Name + " added as node");
                }
                else
                {
                    Logger.Current.Trace("In AddLayerNode. l is null.");
                }
            }, layer);
        }

        public bool ExpandedOnce
        {
            get { return _node.ExpandedOnce; }
        }

        public bool IsParentOf(LayerIdentity identity)
        {
            if (identity.IdentityType != LayerIdentityType.OgrDatasource)
            {
                return false;
            }

            // it may be trickier than that since items in connection string
            // aren't necessarily in the same order
            return Connection.ConnectionString.EqualsIgnoreCase(identity.Connection);
        }

        private class VectorLayerWrapper
        {
            public VectorLayerWrapper(VectorLayer layer, bool multipleGeometries)
            {
                Layer = layer;
                MultipleGeometries = multipleGeometries;
            }

            public VectorLayer Layer { get; private set; }

            public bool MultipleGeometries { get; private set; }
        }
    }
}
