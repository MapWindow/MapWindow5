using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
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

        public ConfigTreeView()
        {
            AfterExpand += ConfigTreeView_AfterExpand;
        }

        private void ConfigTreeView_AfterExpand(object sender, TreeViewAdvNodeEventArgs e)
        {
            foreach (TreeNodeAdv node in Nodes)
            {
                if (node != e.Node)
                {
                    node.Expanded = false;
                }
            }

            SelectedNode = e.Node;
        }

        public void Initialize(ConfigViewModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _model = model;

            IconSize = 24;
            ApplyStyle = false;

            // usual call from constructor won't work here since list of icons is generated dynamically
            CreateImageList();

            AddAllPages();
        }

        private void AddAllPages()
        {
            AddPages(Nodes, ConfigPageType.None);

            foreach (var page in _model.Pages.Where(p => p.ParentPage == ConfigPageType.None))
            {
                var node = NodeForPage(page);
                AddPages(node.Nodes, page.PageType);
            }
        }

        private void AddPages(TreeNodeAdvCollection nodes, ConfigPageType parent)
        {
            foreach(var page in _model.Pages)
            {
                if (page.ParentPage != parent) continue;

                var node = CreateNodeForPage(page);
                page.Tag = node;
                node.Expanded = false;
                nodes.Add(node);
            }
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            if (_model == null)
            {
                yield break;
            }

            var pages = _model.Pages.ToList();
            for (int i = 0; i < pages.Count(); i++)
            {
                var p = pages[i];
                p.ImageIndex = i;
                yield return p.Icon;
            }
        }

        public void SetSelectedPage(ConfigPageType type)
        {
            TreeNodeAdv selectedNode = null;

            var page = _model.Pages.FirstOrDefault(p => p.PageType == type);
            if (page != null)
            {
                var node = NodeForPage(page);
                if (node != null)
                {
                    selectedNode = node;
                }
            }

            SelectedNode = selectedNode ?? Nodes[0];
        }


        public void RestoreSelectedNode(string lastPageName)
        {
            TreeNodeAdv selectedNode = null;

            if (lastPageName == null)
            {
                lastPageName = string.Empty;
            }

            foreach (var page in _model.Pages)
            {
                if (page.PageName.ContainsIgnoreCase(lastPageName))
                {
                    var node = NodeForPage(page);
                    if (node != null)
                    {
                        selectedNode = node;
                        if (selectedNode.Parent != null)
                        {
                            selectedNode.Parent.Expand();
                        }

                        break;
                    }
                }
            }

            SelectedNode = selectedNode ?? Nodes[0];
        }

        private TreeNodeAdv NodeForPage(IConfigPage page)
        {
            return page.Tag as TreeNodeAdv;
        }

        private TreeNodeAdv CreateNodeForPage(IConfigPage page)
        {
            return new TreeNodeAdv(page.PageName)
            {
                Tag = page,
                LeftImageIndices = new[] { page.ImageIndex }
            };
        }
    }
}
