using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public class InputSourceGridAdapter
    {
        private readonly InputSource _source;

        public InputSourceGridAdapter(InputSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            _source = source;
        }

        public InputSourceGridAdapter(ILayer layer)
        {
            _source = new InputSource(layer);
        }

        public InputSourceGridAdapter(string filename)
        {
            _source = new InputSource(filename);
        }

        public string Description
        {
            get { return _source.Description; }
        }

        public InputSource Source
        {
            get { return _source; } 
        }

        [Browsable(false)]
        public ILayer Layer
        {
            get { return _source.Layer; }
        }
    }
}
