using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.UI.Controls
{
    public class TwoColumnTreeView: MultiColumnTreeView
    {
        public TwoColumnTreeView()
        {
            CreateImageList();
        }
        
        public void CreateColumns()
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

        public TreeNodeAdv AddSubItems(TreeNodeAdvCollection nodes, NodeData data)
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

            if (data.ImageIndex != -1)
            {
                node.LeftImageIndices = new[] { data.ImageIndex };
            }
            node.SubItems.Add(new TreeNodeAdvSubItem(data.Value));
            
            node.Expanded = data.Expanded;
            
            node.Tag = data.Metadata;

            if (data.LargerHeight)
            {
                var brush = new BrushInfo(Color.White);
                node.Height += 10;
                node.Background = brush;

                foreach (TreeNodeAdvSubItem item in node.SubItems)
                {
                    item.Background = brush;
                }
            }

            return node;
        }

        protected virtual IEnumerable<Bitmap> OnCreateImageList()
        {
            yield break;
        }

        private void CreateImageList()
        {
            var icons = OnCreateImageList();

            var list = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };

            const int size = 16;
            foreach (var icon in icons)
            {
                var bmp = new Bitmap(icon, new Size(size, size));
                list.Images.Add(bmp);
            }

            LeftImageList = list;
        }
    }
}
