using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.UI.Controls
{
    public class MultiColumnTreeViewFixed: MultiColumnTreeView
    {
        private bool _initialized = false;

        public MultiColumnTreeViewFixed()
        {
            VisibleChanged +=MultiColumnTreeViewFixed_VisibleChanged;
        }

        void MultiColumnTreeViewFixed_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !_initialized)
            {
                Parent.MouseEnter += Parent_MouseEnter;
            }
        }

        void Parent_MouseEnter(object sender, EventArgs e)
        {
            foreach (TreeColumnAdv cmn in Columns)
            {
                cmn.Highlighted = false;
            }
        }
    }
}
