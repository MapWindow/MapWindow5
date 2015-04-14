using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.DebugWindow.Views
{
    public class DebugPresenter: IDockPanelPresenter
    {
        private readonly DebugDockPanel _debugDockPanel;

        public DebugPresenter(DebugDockPanel debugDockPanel)
        {
            if (debugDockPanel == null) throw new ArgumentNullException("debugDockPanel");
            _debugDockPanel = debugDockPanel;
        }

        public Control GetInternalObject()
        {
            return _debugDockPanel;
        }
    }
}
