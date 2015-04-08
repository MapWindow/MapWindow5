using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
{
    internal class VectorItem: RepositoryItem, IVectorItem
    {
        internal VectorItem(TreeNodeAdv node) : base(node)
        {
        }

        public string GetFilename()
        {
            return _node.Tag as string;
        }
    }
}
