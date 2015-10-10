using System;
using System.Windows.Forms;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Tiles.Views
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
