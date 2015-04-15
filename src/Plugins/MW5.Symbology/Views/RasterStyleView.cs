using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView : MapWindowView, IRasterStyleView
    {
        public RasterStyleView(IAppContext context):
            base(context.View)
        {
            InitializeComponent();
        }

        public void UpdateView()
        {

        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<ToolStripItemCollection> Toolstrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        private void cboMinScale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
