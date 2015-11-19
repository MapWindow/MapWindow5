using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Model;

namespace MW5.Data.Repository
{
    internal class GroupItemMetadata : IItemMetadata
    {
        public GroupItemMetadata(RepositoryGroup group)
        {
            if (@group == null) throw new ArgumentNullException("group");
            Group = group;
        }

        public RepositoryGroup Group { get; set; }
    }
}
