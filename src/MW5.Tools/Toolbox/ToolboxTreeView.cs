using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Tools.Properties;
using MW5.UI.Controls;

namespace MW5.Tools.Toolbox
{
    public class ToolboxTreeView: TreeViewBase
    {
        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            yield return Resources.img_toolbox16;
            yield return Resources.img_tool16;
        }

        public IGisTool SelectedTool
        {
            get { return SelectedNode.Tag as IGisTool; }
        }
    }
}
