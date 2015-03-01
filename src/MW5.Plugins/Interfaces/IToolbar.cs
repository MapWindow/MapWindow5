using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbar
    {
        string Name { get; set; }
        IMenuItemCollection Items { get; }
    }
}
