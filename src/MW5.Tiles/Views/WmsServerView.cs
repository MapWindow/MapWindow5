using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Tiles.Views
{
    public partial class WmsServerView : WmsServerViewBase, IWmsServerView
    {
        public WmsServerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            txtName.Text = Model.Name;
            txtUrl.Text = Model.Url;
        }

        public string ServerName
        {
            get { return txtName.Text; }
        }

        public string Url
        {
            get
            {
                string s = txtUrl.Text.Trim().ToLower();

                if (!s.StartsWith("http"))
                {
                    s = "http://" + s;
                }

                return s;
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class WmsServerViewBase : MapWindowView<WmsServer> { }
}
