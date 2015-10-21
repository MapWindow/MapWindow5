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

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageService.Current.Info("Server name is empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageService.Current.Info("URL is empty.");
                return false;
            }

            return true;
        }

        public void ApplyChanges()
        {
            Model.Name = txtName.Text;
            Model.Url = txtUrl.Text;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class WmsServerViewBase : MapWindowView<WmsServer> { }
}
