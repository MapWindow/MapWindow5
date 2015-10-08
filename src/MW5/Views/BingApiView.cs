using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class BingApiView : MapWindowView, IBingApiView
    {
        public BingApiView(IConfigService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            InitializeComponent();

            textBox1.Text = service.Config.BingApiKey;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private void OnlinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "http://www.microsoft.com/maps/create-a-bing-maps-key.aspx";
            PathHelper.OpenUrl(url);
        }

        public string Key
        {
            get { return textBox1.Text; }
        }
    }
}
