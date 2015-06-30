// -------------------------------------------------------------------------------------------
// <copyright file="OptionsParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The options parameter.
    /// </summary>
    public class OptionsParameter<T> : BaseParameter
    {
        private IEnumerable<T> _options;

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public IEnumerable<T> Options
        {
            get { return _options; }

            set
            {
                _options = value;
                var control = Control as ComboParameterControl;
                if (control != null)
                {
                    control.SetOptions(Options);
                }
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value
        {
            get
            {
                var control = Control as ComboParameterControl;
                if (control == null)
                {
                    return default(T);
                }

                var value = control.GetValue();
                if (value != null)
                {
                    return (T)value;
                }

                return default(T);
            }
        }

        /// <summary>
        /// Create the control.
        /// </summary>
        /// <returns>The <see cref="ParameterControlBase" />.</returns>
        public override ParameterControlBase CreateControl()
        {
            if (Control != null)
            {
                return Control;
            }

            var control = new ComboParameterControl { ButtonVisible = false };
            control.SetOptions(_options); // ensure that previously specified options are applied
            Control = control;

            return Control;
        }
    }
}