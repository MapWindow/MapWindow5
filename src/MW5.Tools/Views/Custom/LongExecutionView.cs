using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Views.Custom.Abstract;
using MW5.UI.Forms;

namespace MW5.Tools.Views.Custom
{
    public partial class LongExecutionView : LongExecutionViewBase, ILongExecutionView
    {
        public LongExecutionView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            
        }

        public ButtonBase OkButton
        {
            get { return btnRun; }
        }

        public double SecondsPerStep
        {
            get { return txtSecondsPerStep.DoubleValue; }
        }

        public bool RunInBackground
        {
            get { return chkBackground.Checked; }
        }

        public ProgressBar Progress
        {
            get { return progressBar1; }
        }

        public void DisableButtons()
        {
            btnClose.Enabled = false;
            btnRun.Enabled = false;
        }
    }

    public class LongExecutionViewBase : MapWindowView<ToolViewModel> { }
}
