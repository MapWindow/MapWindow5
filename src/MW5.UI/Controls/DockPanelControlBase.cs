using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Controls
{
    public class DockPanelControlBase: UserControl, IDockPanelView
    {
        private bool _shown = false;

        public DockPanelControlBase()
        {
            Load += (s, e) => _shown = true;
        }

        public bool IsDockVisible
        {
            get
            {
                // Visible property returns true before it was shown for the first time
                if (!_shown)
                {
                    return false;
                }

                return Visible;
            }
        }
    }
}
