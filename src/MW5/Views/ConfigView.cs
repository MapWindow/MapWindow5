using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Abstract;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Config;
using MW5.UI;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Views
{
    public partial class ConfigView : MapWindowForm, IConfigView
    {
        private bool _initialized = false;
        private readonly PluginManager _manager;
        private readonly IConfigService _config;
        private List<IConfigPage> _pages = new List<IConfigPage>();
        
        public ConfigView()
        {
            InitializeComponent();
        }

        public ConfigView(IAppContext context): base(context)
        {
            InitializeComponent();
        }

        public List<IConfigPage> Pages
        {
            get { return _pages; }
        }

        public event Action OkClicked;

        public void Initialize()
        {
            if (_initialized)
            {
                throw new ApplicationException("The view was already initialized");
            }

            foreach (var page in _pages)
            {
                var node = new TreeNodeAdv(page.PageName) { Tag = page };
                treeViewAdv1.Nodes.Add(node);
            }

            treeViewAdv1.AfterSelect += treeViewAdv1_AfterSelect;
            treeViewAdv1.SelectedNode = treeViewAdv1.Nodes[0];
            _initialized = true;
        }

        void treeViewAdv1_AfterSelect(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var node = treeViewAdv1.SelectedNode;
            if (node != null)
            {
                var page = node.Tag as Control;
                if (page != null)
                {
                    page.Dock = DockStyle.Fill;
                    panel1.Controls.Add(page);
                }
            }
        }

        public void UpdateView()
        {
            
        }
    }
}
