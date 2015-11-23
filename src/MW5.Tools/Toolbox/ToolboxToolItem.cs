using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    internal class ToolBoxToolItem: IToolBoxToolItem
    {
        private readonly TreeNodeAdv _node;

        public ToolBoxToolItem(TreeNodeAdv node)
        {
            if (node == null) throw new ArgumentNullException("node");
            _node = node;
        }

        public ITool Tool
        {
            get  { return _node.Tag as ITool; }
        }

        public bool Visible 
        {
            get { return _node.Height != 0; }
            set
            {
                _node.Height = value ? ToolboxTreeView.TreeViewNodeHeight : 0;
                _node.IsSelectable = value;
            }
        }
    }
}
