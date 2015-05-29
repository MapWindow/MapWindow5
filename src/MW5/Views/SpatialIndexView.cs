using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class SpatialIndexView : MapWindowView, ISpatialIndexView
    {
        public SpatialIndexView()
        {
            InitializeComponent();
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        public event Action ButtonClicked;

        public bool DontShowAgain
        {
            get { return chkDontShow.Checked; }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Invoke(ButtonClicked);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Invoke(ButtonClicked);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Invoke(ButtonClicked);
        }
    }
}
