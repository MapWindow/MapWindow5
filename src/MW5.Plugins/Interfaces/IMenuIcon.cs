
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IMenuIcon
    {
        Image Image { get; }
        bool UseNativeSize { get; }
    }
}
