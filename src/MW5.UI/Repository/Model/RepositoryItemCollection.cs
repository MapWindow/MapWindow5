using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
{
    public class RepositoryItemCollection : IEnumerable<IRepositoryItem>
    {
        private readonly TreeNodeAdvCollection _nodes;

        internal RepositoryItemCollection(TreeNodeAdvCollection nodes)
        {
            if (nodes == null) throw new ArgumentNullException("nodes");
            _nodes = nodes;
        }

        public void Add(IRepositoryItem item, bool expand)
        {
            var node = item.GetInternalObject() as TreeNodeAdv;
            if (node != null)
            {
                _nodes.Add(node);
                if (expand)
                {
                    node.Expanded = true;
                }
            }
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
    }
}
