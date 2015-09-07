using System;
using System.ComponentModel;
using MW5.Api.Interfaces;

namespace MW5.Services.Views
{
    public class LayerItem
    {
        private readonly ILayer _layer;

        public LayerItem(ILayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            _layer = layer;
            Selected = false;
        }

        public string Name
        {
            get { return _layer.Name; }
        }

        [Browsable(false)]
        public ILayer Layer
        {
            get { return _layer; }
        }

        public string Description
        {
            get { return _layer.SizeInfo; }
        }

        public bool Selected { get; set; }
    }
}
