using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Config;
using MW5.UI;
using MW5.UI.Forms;
using MW5.Views.Abstract;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Views
{
    public partial class ConfigView : MapWindowView, IConfigView
    {
        private bool _initialized = false;
        private readonly List<IConfigPage> _pages = new List<IConfigPage>();
        private static string _lastPageName = string.Empty;

        public event Action OpenFolderClicked;
        public event Action SaveClicked;

        public ConfigView()
        {
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            FormClosed += (s, e) =>
            {
                var page = SelectedPage;
                if (page != null)
                {
                    _lastPageName = page.PageName;
                }
            };
        }

        public List<IConfigPage> Pages
        {
            get { return _pages; }
        }

        public void Initialize()
        {
            if (_initialized)
            {
                throw new ApplicationException("The view was already initialized");
            }

            TreeNodeAdv selectedNode = null;
            foreach (var page in _pages)
            {
                var node = new TreeNodeAdv(page.PageName) { Tag = page };
                
                _treeViewAdv1.Nodes.Add(node);
                if (page.PageName == _lastPageName)
                {
                    selectedNode = node;
                }
            }
            
            _treeViewAdv1.AfterSelect += treeViewAdv1_AfterSelect;
            _treeViewAdv1.SelectedNode = selectedNode ?? _treeViewAdv1.Nodes[0];
            _initialized = true;

            btnOpenFolder.Click += (s, e) => Invoke(OpenFolderClicked);
            btnSave.Click += (s, e) => Invoke(SaveClicked);
        }

        void treeViewAdv1_AfterSelect(object sender, EventArgs e)
        {
            Control control = null;
            if (panel1.Controls.Count > 0)
            {
                control = panel1.Controls[0];
            }

            var page = SelectedPage as Control;
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                panel1.Controls.Add(page);
                page.BringToFront();
            }

            if (control != null)
            {
                panel1.Controls.Remove(control);
            }
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

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public void Initialize(object param)
        {
            
        }
    }
}
