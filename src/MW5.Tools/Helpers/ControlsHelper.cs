// -------------------------------------------------------------------------------------------
// <copyright file="ControlsHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension methods to work with list of controls associated with tool parameters.
    /// </summary>
    internal static class ControlsHelper
    {
        /// <summary>
        /// Substitutes each layer input with datasource input .
        /// </summary>
        /// <remarks>
        /// Must be done immediately before the async execution when validation was passed.
        /// Layer inputs can't be accessed from background thread, since they are bound to map control.</remarks>
        public static void ExtractDatasources(this IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters.OfType<LayerParameterBase>())
            {
                var input = p.Value as LayerInput;
                if (input != null)
                {
                    var dsInput = new DatasourceInput(input.Layer);
                    p.SetToolValue(dsInput);
                    input.Dispose();
                }
            }
        }

        /// <summary>
        /// Copies values from controls to the properties of the tool.
        /// </summary>
        public static void SaveControlValues(this IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters.Where(p => p.Control != null))
            {
                p.SetToolValue(p.Value);
            }
        }

        /// <summary>
        /// Detaches controls from parameters.
        /// </summary>
        public static void DetachControls(this IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters.Where(p => p.Control != null))
            {
                p.Control = null;
            }
        }

        /// <summary>
        /// Sets default values and list of options to the controls.
        /// </summary>
        public static void SetControlDefaults(this IEnumerable<BaseParameter> parameters)
        {
            parameters = parameters.ToList();

            SetOptionsToControls(parameters);

            SetControlDefaultsCore(parameters);
        }

        /// <summary>
        /// Sets the defaults values to controls. Can be specified as: 
        /// a) attributes, 
        /// b) configuration, 
        /// c) values of the previous run.
        /// </summary>
        private static void SetControlDefaultsCore(this IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters)
            {
                var init = p.InitialValue;
                if (init != null && p.Control != null)
                {
                    p.Control.SetValue(init);
                }
            }
        }

        /// <summary>
        /// Sets list of options for OptionsParameter controls.
        /// </summary>
        private static void SetOptionsToControls(this IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters)
            {
                var op = p as OptionsParameter;
                if (op == null || op.Options == null)
                {
                    continue;
                }

                var ctrl = op.Control as IOptionsParameterControl;
                if (ctrl != null)
                {
                    ctrl.SetOptions(op.Options);
                }
            }
        }
    }
}