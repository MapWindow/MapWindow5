using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Data.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Data.Views
{
    public partial class ImportLayerView : MapWindowView, IImportLayerView
    {
        public ImportLayerView()
        {
            InitializeComponent();
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }
}
