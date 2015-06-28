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

            int iconCount = 0;

            AddPages(Nodes, ref iconCount, false);

            var node = NodeForPage(_model.GetPage(ConfigPageType.Plugins));
            if (node != null)
            {
                AddPages(node.Nodes, ref iconCount, true);
                node.Expanded = true;
            }
        }

        private void AddPages(TreeNodeAdvCollection nodes, ref int iconCount, bool plugin)
        {
            foreach(var page in _model.Pages)
            {
                if (page.PluginPage != plugin) continue;

                var node = CreateNodeForPage(page, iconCount++);
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
