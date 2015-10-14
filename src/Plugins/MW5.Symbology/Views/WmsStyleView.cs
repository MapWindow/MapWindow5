using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Views
{
    public partial class WmsStyleView : WmsStyleViewBase, IWmsStyleView
    {
        public WmsStyleView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            txtLayerName.Text = Model.Name;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class WmsStyleViewBase : MapWindowView<ILegendLayer> { }
}
