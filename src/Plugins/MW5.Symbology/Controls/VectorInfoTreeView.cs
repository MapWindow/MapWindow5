using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Plugins.Symbology.Controls
{
    public class VectorInfoTreeView : TwoColumnTreeView
    {
        public void Initialize(ILayer layer)
        {
            CreateColumns();

            if (layer == null) return;

            Nodes.Clear();

            var root = VectorInfoHelper.GetFeatureSetInfo(layer.FeatureSet);

            var ogr = VectorInfoHelper.GetVectorLayerInfo(layer.VectorSource);
            root.AddSubItem(ogr);

            var node = AddSubItems(Nodes, root);

            node.ExpandAll();
        }
    }
}
