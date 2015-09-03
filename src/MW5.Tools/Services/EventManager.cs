using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Services
{
    /// <summary>
    /// Routes UI events for the tool to the interested controls.
    /// </summary>
    public class EventManager
    {
        private readonly List<ParameterControlBase> _controls = new List<ParameterControlBase>();

        public void AddControl(ParameterControlBase control)
        {
            _controls.Add(control);
        }

        public void Bind(ToolConfiguration config)
        {
            BindFields(config);
        }

        private void BindFields(ToolConfiguration config)
        {
            var dict = _controls.ToDictionary(p => p.ParameterName);

            foreach (var f in config.Fields)
            {
                var item = f;

                var layer = dict[item.LayerName] as LayerParameterControl;
                var field = dict[item.FieldName] as FieldParameterControl;
                if (layer != null && field != null)
                {
                    layer.SelectedLayerChanged += (s, e) => field.OnLayerChanged(e.Layer);
                    field.OnLayerChanged(layer.SelectedLayer);
                }
            }
        }
    }
}
