using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Tools.Controls
{
    /// <remarks>Syncfusion's TreeNodeAdv.CustomControl sets custom control height to the height of node.
    /// Therefore this ugly hack, to add some vertical padding.</remarks>
    public partial class ProgressBarWrapper : UserControl
    {
        public ProgressBarWrapper()
        {
            InitializeComponent();
        }

        public ProgressBar ProgressBar
        {
            get { return progressBar1; }
        }
    }
}
