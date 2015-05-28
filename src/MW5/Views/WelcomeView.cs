using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class WelcomeView : WelcomeViewBase, IWelcomeView
    {
        public WelcomeView()
        {
            InitializeComponent();

            KeyPreview = true;

            Init();

            Shown += (s, e) => Focus();
        }

        private void Init()
        {
            lbProject1.Tag = 0;
            lbProject2.Tag = 1;
            lbProject3.Tag = 2;
            ProjectId = -1;

            lbGettingStarted.Click += (s, e) => Invoke(GettingStartedClicked);
            lbHelpFile.Click += (s, e) => Invoke(DocumentsClicked);
            lbPaypal.Click += (s, e) => Invoke(DonateClicked);
            lbAddData.Click += (s, e) => Invoke(OpenLayerClicked);
            lbOpenProject.Click += OpenProjectClick;
            picureLogo.Click += (s, e) => Invoke(LogoClicked);

            var asm = Assembly.GetExecutingAssembly();
            lblVersion.Text = "version " + asm.GetName().Version;
        }

        public void Initialize()
        {
            var list = new List<LinkLabelEx>()
            {
                lbProject1,
                lbProject2,
                lbProject3
            };

            foreach (var item in list)
            {
                item.Visible = false;
            }

            for (int i = 0; i < Math.Min(Model.RecentProjects.Count, 3); i++)
            {
                string text = "-  " + Path.GetFileName(Model.RecentProjects[i]);
                list[i].SetText(text, 3, text.Length - 1);
                list[i].Visible = true;
            }
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = false,
                    Sizable = false
                };
            }
        }

        public int ProjectId { get; private set; }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        public event Action GettingStartedClicked;
        public event Action DocumentsClicked;
        public event Action DonateClicked;
        public event Action OpenLayerClicked;
        public event Action OpenProjectClicked;
        public event Action LogoClicked;

        private void OpenProjectClick(object sender, EventArgs e)
        {
            ProjectId = -1;
            Invoke(OpenProjectClicked);
        }

        private void OnRecentProjectClick(object sender, EventArgs e)
        {
            var label = sender as LinkLabel;
            if (label != null)
            {
                ProjectId = (int)label.Tag;
                Invoke(OpenProjectClicked);
            }
        }

        private void cbShowDlg_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.ShowWelcomeDialog = chkShowDlg.Checked;
        }

        private void WelcomeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }

    public class WelcomeViewBase : MapWindowView<WelcomeViewModel> { }
}
