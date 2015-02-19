using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.Interfaces;
using BL.BO;
using LayerControl.LegendControl;

namespace MapWindowControls.LegendControl
{
    public partial class LegendControl : UserControl, ILayerControl
    {
        public delegate void DropLayerHandler(LegendDroppedEventArgs e);

        public delegate void CheckedHandler(CheckedEventArgs e);

        public delegate void ColapseExandHandler(ColapseExpandEventArgs e);

        [Category("Action")]
        [Description("Fires when a layer is dropped on the treeview.")]
        public event DropLayerHandler LayerDropped;

        [Category("Action")]
        [Description("Fires when the Checkbox changed.")]
        public event CheckedHandler Checked;

        [Category("Action")]
        [Description("Fires when the Checkbox changed.")]
        public event ColapseExandHandler ColapseExand;
        
//        public EventHandler afterCollapse = new EventHandler(treeView1_AfterExpand);

        public LegendControl()
        {
            InitializeComponent();
        }

        public void AddLayer(LayerCollection collectionLayer)
        {
            // disable events temporarily
            treeView1.AfterCollapse -= treeView1_AfterCollapse;
            treeView1.AfterExpand -= treeView1_AfterExpand;

            treeView1.Nodes.Clear();

            TreeNode groupNode = null;
            List<TreeNode> groupNodes = new List<TreeNode>();

            foreach (LayerGroup layerGroup in collectionLayer.OrderByDescending(elm => elm.Position))
            {
                var group = groupNodes.FirstOrDefault(elm => elm.Text == layerGroup.Group.Name);
                if (group == null)
                {
                    // group toevoegen
                    groupNode = new TreeNode(layerGroup.Group.Name);
                    groupNodes.Add(groupNode);

                    if (layerGroup.Group.Expanded)
                    {
                        groupNode.Expand();
                    }
                }

                // layer toevoegen
                TreeNode layerNode = new TreeNode();
                layerNode.Text = layerGroup.Name;
                layerNode.Checked = layerGroup.LayerVisible;
                layerNode.Tag = layerGroup.Handle;

                groupNode.Nodes.Add(layerNode);
            }

            treeView1.Nodes.AddRange(groupNodes.ToArray());

            // Enable events again
            treeView1.AfterCollapse += treeView1_AfterCollapse;
            treeView1.AfterExpand += treeView1_AfterExpand;

        }

        protected virtual void OnChecked(string itemName, bool isChecked, int handle)
        {
            if (Checked != null)
            {
                CheckedEventArgs args = new CheckedEventArgs(itemName, isChecked, handle);

                Checked(args);
            }
        }

        protected virtual void OnLayerDropped(string destinationNode, string movingNode)
        {
            if (LayerDropped != null)
            {
                LegendDroppedEventArgs args = new LegendDroppedEventArgs(destinationNode, movingNode);

                LayerDropped(args);
            }
        }

        protected virtual void OnColapseExpand(string nodeName, bool isExpaned)
        {
            if(ColapseExand != null)
            {
                ColapseExpandEventArgs args = new ColapseExpandEventArgs(nodeName, isExpaned);

                ColapseExand(args);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  OnSubmitClicked();
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));

            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

            TreeNode destNode = ((TreeView)sender).GetNodeAt(loc);

            if (destNode != null)
            {
                OnLayerDropped(destNode.Text, node.Text);
            }

            //if (node.Parent == null)
            //{
            //    node.TreeView.Nodes.Remove(node);
            //}
            //else
            //{
            //    node.Parent.Nodes.Remove(node);
            //}


            //if (destNode.Parent == null)
            //{
            //    destNode.TreeView.Nodes.Insert(destNode.Index + 1, node);
            //}
            //else
            //{
            //    destNode.Parent.Nodes.Insert(destNode.Index + 1, node);
            //}
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            OnChecked(e.Node.Text, e.Node.Checked, Convert.ToInt32(e.Node.Tag));
            if (e.Node.Parent != null)
            {

            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
           
            //sender.
            OnColapseExpand(e.Node.Text, true);
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            OnColapseExpand(e.Node.Text, false);  
        }

    }
}
