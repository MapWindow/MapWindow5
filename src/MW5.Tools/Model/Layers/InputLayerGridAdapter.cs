using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public class InputLayerGridAdapter
    {
        private readonly IDatasourceInput _source;

        public InputLayerGridAdapter(IDatasourceInput source)
        {
            if (source == null) throw new ArgumentNullException("source");
            _source = source;
        }

        public InputLayerGridAdapter(ILayer layer)
        {
            _source = new LayerInput(layer);
        }

        public InputLayerGridAdapter(string filename)
        {
            _source = new DatasourceInput(filename);
        }

        [Browsable(false)]
        public IDatasourceInput Source
        {
            get { return _source; } 
        }

        public string Description
        {
            get
            {
                string s = _source.Name;
                var ds = _source.Datasource;
                s += ds != null ? " " + ds.SizeInfo : string.Empty;
                return s;
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
