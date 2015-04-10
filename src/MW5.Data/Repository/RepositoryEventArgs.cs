using System;
using MW5.Data.Repository.Model;

namespace MW5.Data.Repository
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
