using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.UI.Repository.Model;

namespace MW5.UI.Repository
{
    public class RepositoryEventArgs: EventArgs
    {
        public RepositoryEventArgs(IRepositoryItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            Item = item;
        }

        public IRepositoryItem Item { get; private set; }
    }
}
