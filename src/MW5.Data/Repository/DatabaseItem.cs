using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Concrete;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class DatabaseItem: MetadataItem<DatabaseItemMetadata>, IDatabaseItem
    {
        internal DatabaseItem(TreeNodeAdv node) : base(node)
        {
        }

        public DatabaseConnection Connection
        {
            get { return Metadata.Connection; }
        }

        public override void Expand()
        {
            if (_node.ExpandedOnce) return;

            var data = Metadata;

            using (var ds = new VectorDatasource())
            {
                if (ds.Open(data.Connection.ConnectionString))
                {
                    foreach (var layer in ds)
                    {
                        SubItems.AddDatabaseLayer(layer);
                    }
                }
            }

            _node.ExpandedOnce = true;
        }
    }
}
