using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Services.Config;
using MW5.Shared;
using MW5.UI.Controls;
using MW5.Views;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Controls
{
    public class ConfigTreeView: TreeViewBase
    {
        private ConfigViewModel _model;

        public void Initialize(ConfigViewModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _model = model;

            IconSize = 24;
            ApplyStyle = false;

            // usual call from constructor won't work here since list of icons is generated dynamically
            CreateImageList();      

            AddPages(Nodes, false);

            var node = NodeForPage(_model.GetPage(ConfigPageType.Plugins));
            if (node != null)
            {
                AddPages(node.Nodes, true);
                node.Expanded = true;
            }
        }

        private void AddPages(TreeNodeAdvCollection nodes, bool plugin)
        {
            int count = 0;

            foreach(var page in _model.Pages)
            {
                if (page.PluginPage != plugin) continue;

                var node = CreateNodeForPage(page, count++);
                page.Tag = node;
                nodes.Add(node);
            }
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            if (_model == null)
            {
                yield break;
            }

            foreach (var p in _model.Pages)
            {
                yield return p.Icon;
            }
        }

        public void RestoreSelectedNode(string lastPageName)
        {
            TreeNodeAdv selectedNode = null;

            foreach (var page in _model.Pages)
            {
                if (page.PageName.ContainsIgnoreCase(lastPageName))
                {
                    var node = page.Tag as TreeNodeAdv;
                    if (node != null)
                    {
                        selectedNode = node;
                    }
                }
            }

            SelectedNode = selectedNode ?? Nodes[0];
        }

        private TreeNodeAdv NodeForPage(IConfigPage page)
        {
            return page.Tag as TreeNodeAdv;
        }

        private TreeNodeAdv CreateNodeForPage(IConfigPage page, int index)
        {
            return new TreeNodeAdv(page.PageName)
            {
                Tag = page,
                LeftImageIndices = new[] { index }
            };
        }
    }
}
