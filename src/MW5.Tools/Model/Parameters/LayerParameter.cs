using System;
using System.Collections.Generic;
using MW5.Api.Interfaces;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public class LayerParameter: BaseParameter
    {
        private IEnumerable<ILayer> _layers;

        public LayerParameterControl LayerControl
        {
            get { return Control as LayerParameterControl; }
        }

        public ILayer Value
        {
            get { return LayerControl.GetValue() as ILayer; }
        }

        public void SetLayers(IEnumerable<ILayer> layers)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            _layers = layers;
        }

        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new LayerParameterControl(_layers));
        }
    }
}
