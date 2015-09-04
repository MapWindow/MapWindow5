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
        private Dictionary<string, ParameterControlBase> _dict;

        public void AddControl(ParameterControlBase control)
        {
            _controls.Add(control);
        }

        public void Bind(ToolConfiguration config)
        {
            _dict = _controls.ToDictionary(p => p.ParameterName);

            AssignLayers(config);

            BindFields(config);

            BindComboLists(config);
        }

        private ParameterControlBase GetControl(string key)
        {
            return _dict[key];
        }

        private void AssignLayers(ToolConfiguration config)
        {
            foreach (var control in _controls.OfType<LayerParameterControl>())
            {
                control.SetLayers(config.Layers);
            }
        }

        private void BindComboLists(ToolConfiguration config)
        {
            foreach (var item in config.ComboLists)
            {
                var combo = GetControl(item.Key) as ComboParameterControl;
                if (combo != null)
                {
                    combo.SetOptions(item.Value);
                }
            }
        }

        private void BindFields(ToolConfiguration config)
        {
            foreach (var f in config.Fields)
            {
                var layer = GetControl(f.LayerName) as LayerParameterControl;
                var field = GetControl(f.FieldName) as FieldParameterControl;
                if (layer != null && field != null)
                {
                    layer.SelectedLayerChanged += (s, e) => field.OnLayerChanged(e.Layer);
                    field.OnLayerChanged(layer.SelectedLayer);
                }
            }
        }
    }
}
