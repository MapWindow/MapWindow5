using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views
{
    public class FindReplaceModel
    {
        private readonly string _layerName;

        public FindReplaceModel(TableEditorGrid grid, ILegendLayer layer, bool replace)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            if (layer == null) throw new ArgumentNullException("layer");

            Grid = grid;
            Replace = replace;
            Table = layer.FeatureSet.Table;
            SearchInfo = new SearchInfo();
            _layerName = layer.Name;
        }

        public IAttributeTable Table { get; private set; }
        public TableEditorGrid Grid { get; private set; }
        public bool Replace { get; private set; }
        public SearchInfo SearchInfo { get; private set; }

        public string DialogCaption
        {
            get
            {
                string s = Replace ? "Find and replace" : "Find";
                s += " in " + _layerName; 
                return s;
            }
        }
    }
}
