using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Plugins.Symbology.Controls
{
    public class InfoTreeViewBase: MultiColumnTreeView
    {
        public InfoTreeViewBase()
        {
            Init();
        }

        private void Init()
        {
            Columns.Clear();

            var treeColumnAdv1 = new TreeColumnAdv();
            var treeColumnAdv2 = new TreeColumnAdv();

            treeColumnAdv1.Highlighted = false;
            treeColumnAdv1.Text = "Name";
            treeColumnAdv1.Width = 260;
            treeColumnAdv2.Highlighted = false;
            treeColumnAdv2.Text = "Value";
            treeColumnAdv2.Width = 200;
            Columns.AddRange(new[] {
            treeColumnAdv1,
            treeColumnAdv2});

            FullRowSelect = true;
            GutterSpace = 12;
        }

        protected TreeNodeAdv AddSubItems(TreeNodeAdvCollection nodes, NodeData data)
        {
            
            var node = GetNode(data);
            nodes.Add(node);

            foreach (var item in data.SubItems)
            {
                AddSubItems(node.Nodes, item);
            }

            return node;
        }

        protected TreeNodeAdv GetNode(NodeData data)
        {
            var node = new TreeNodeAdv(data.Name);
            node.SubItems.Add(new TreeNodeAdvSubItem(data.Value));
            return node;
        }
    }
}
