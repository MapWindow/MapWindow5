using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class DatabaseLayerItem : MetadataItem<DatabaseLayerMetadata>, IDatabaseLayerItem
    {
        internal DatabaseLayerItem(TreeNodeAdv node) : base(node)
        {
        }

        public string Connection
        {
            get { return Metadata.Connection; }
        }

        public string Name
        {
            get { return Metadata.Name; }
        }

        public GeometryType GeometryType
        {
            get { return Metadata.GeometryType; }
        }

        public int NumFeatures
        {
            get { return Metadata.NumFeatures; }
        }

        public ISpatialReference Projection
        {
            get { return Metadata.Projection; }
        }
    }
}
