using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Model;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class TmsItem : MetadataItem<TmsItemMetadata>, ITmsItem
    {
        private bool _active;

        internal TmsItem(TreeNodeAdv node)
            : base(node)
        {
        }

        public TmsProvider Provider
        {
            get { return Metadata.Provider; }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                _node.Font = new Font(_node.Font, value ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        public string Serialize()
        {
            return "TmsProvider|" + Provider.Id;
        }
    }
}
