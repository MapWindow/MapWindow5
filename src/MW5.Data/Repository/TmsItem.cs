using System;
using System.Collections.Generic;
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
        internal TmsItem(TreeNodeAdv node)
            : base(node)
        {
        }

        public TmsProvider Provider
        {
            get { return Metadata.Provider; }
        }
    }
}
