// -------------------------------------------------------------------------------------------
// <copyright file="EventManager.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    /// <summary>
    /// Adds event handlers to the parameters controls based on configuration info.
    /// </summary>
    public class EventManager
    {
        private readonly List<ParameterControlBase> _controls = new List<ParameterControlBase>();
        private Dictionary<string, ParameterControlBase> _dict;

        public event EventHandler<ParameterControlEventArgs> ControlValueChanged;

        /// <summary>
        /// Adds control to the event manager.
        /// </summary>
        public void AddControl(ParameterControlBase control)
        {
            _controls.Add(control);
            control.ValueChanged += (s, e) => FireControlValueChanged(s as ParameterControlBase);
        }

        /// <summary>
        /// Applies configuration values to the controls stored be event manager.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void ApplyConfig(ToolConfiguration config)
        {
            _dict = _controls.ToDictionary(p => p.ParameterName);

            BindOutput();

            BindFields(config);

            AssignLayers(config);
        }

        /// <summary>
        /// Assigns list of layers to the input controls
        /// </summary>
        private void AssignLayers(ToolConfiguration config)
        {
            foreach (var control in _controls.OfType<LayerParameterControl>())
            {
                control.SetLayers(config.Layers);
            }
        }

        /// <summary>
        /// Binds field controls to the corresponding input layer controls.
        /// </summary>
        private void BindFields(ToolConfiguration config)
        {
            foreach (var f in config.Fields)
            {
                var layer = GetControl(f.LayerName) as LayerParameterControl;

                if (layer == null)
                {
                    continue;
                }

                var field = GetControl(f.FieldName) as IInputListener;
                if (field != null)
                {
                    layer.SelectedLayerChanged += (s, e) => field.OnLayerChanged(e.Datasource);
                }
            }
        }

        /// <summary>
        /// Binds output filename to the input name.
        /// </summary>
        private void BindOutput()
        {
            var output = _controls.OfType<IOuputputParameterControl>().FirstOrDefault();
            if (output == null)
            {
                return;
            }

            var input = _controls.OfType<IInputParameterControl>().FirstOrDefault();
            if (input != null)
            {
                if (input is FilenameParameterControl)
                {
                    input.ValueChanged += (s, e) => output.OnFilenameChanged(input.GetValue() as string);
                }

                if (input is LayerParameterControl)
                {
                    input.ValueChanged += (s, e) => output.OnDatasourceChanged(input.GetValue() as IDatasourceInput);
                }
            }
        }

        /// <summary>
        /// Fires the control value changed event.
        /// </summary>
        private void FireControlValueChanged(ParameterControlBase control)
        {
            var handler = ControlValueChanged;
            if (handler != null)
            {
                ControlValueChanged(control, new ParameterControlEventArgs(control));
            }
        }

        private ParameterControlBase GetControl(string key)
        {
            return _dict[key];
        }
    }
}