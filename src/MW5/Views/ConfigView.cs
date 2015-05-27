using System;
using System.Windows.Forms;
using MW5.Services.Config;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class ConfigView : ConfigViewBase, IConfigView
    {
        private static string _lastPageName = string.Empty;

        public event Action OpenFolderClicked;
        public event Action SaveClicked;
        public event Action PageShown;

        public ConfigView()
        {
            InitializeComponent();

            btnOpenFolder.Click += (s, e) => Invoke(OpenFolderClicked);
            btnSave.Click += (s, e) => Invoke(SaveClicked);

            FormClosed += ConfigView_FormClosed;
        }

        public void Initialize()
        {
            _treeViewAdv1.Initialize(Model);
            _treeViewAdv1.AfterSelect += (s, e) => DisplaySelectedPage();
            _treeViewAdv1.RestoreSelectedNode(_lastPageName);
        }

        private IConfigPage SelectedPage
        {
            get 
            {
                var node = _treeViewAdv1.SelectedNode;
                if (node != null)
                {
                    return node.Tag as IConfigPage;
                }
                return null;
            }
        }

        private void ConfigView_FormClosed(object sender, FormClosedEventArgs e)
        {
            var page = SelectedPage;
            if (page != null)
            {
                _lastPageName = page.PageName;
            }
        }

        private void DisplaySelectedPage()
        {
            Control control = null;
            if (panelContent.Controls.Count > 0)
            {
                control = panelContent.Controls[0];
            }

            var page = SelectedPage as Control;
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                panelContent.Controls.Add(page);
                lblDescription.Text = SelectedPage.Description;
                pictureBox1.Image = SelectedPage.Icon;
                page.BringToFront();
                Invoke(PageShown);
            }

            if (control != null)
            {
                panelContent.Controls.Remove(control);
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class ConfigViewBase : MapWindowView<ConfigViewModel> { }
}
