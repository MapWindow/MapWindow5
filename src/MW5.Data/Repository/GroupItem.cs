using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Model;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class GroupItem : MetadataItem<GroupItemMetadata>, IGroupItem
    {
        internal GroupItem(TreeNodeAdv node)
            : base(node)
        {
        }

        public bool ExpandedOnce { get; private set; }

        public bool IsParentOf(LayerIdentity identity)
        {
            return false;
        }

        public RepositoryGroup Group
        {
            get { return Metadata.Group; }
        }
    }
}
