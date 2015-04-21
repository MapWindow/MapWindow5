using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class ServerItem : MetadataItem<ServerItemMetadata>, IServerItem
    {
        internal ServerItem(TreeNodeAdv node) : base(node)
        {
        }

        public GeoDatabaseType DatabaseType
        {
            get { return Metadata.DatabaseType; }
        }
    }
}
