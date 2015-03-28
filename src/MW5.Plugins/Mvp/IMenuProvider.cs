using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public interface IMenuProvider
    {
        IEnumerable<ToolStripItemCollection> ToolStrips { get; }
        IEnumerable<Control> Buttons { get; }
        IEnumerable<IToolbar> Toolbars { get; }
    }
}
