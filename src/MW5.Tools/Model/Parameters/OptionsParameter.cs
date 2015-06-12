// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionsParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The options parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    #region

    using System.Collections.Generic;

    using MW5.Tools.Views.Controls;

    #endregion

    /// <summary>
    /// The options parameter.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class OptionsParameter<T> : BaseParameter
    {
        #region Fields

        private IEnumerable<T> _options;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        public IEnumerable<T> Options
        {
            get
            {
                return _options;
            }

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
                if (control != null)
                {
                    var value = control.GetValue();
                    if (value != null)
                    {
                        return (T)value;
                    }
                }

                return default(T);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create control.
        /// </summary>
        /// <returns>
        /// The <see cref="ParameterControlBase"/>.
        /// </returns>
        public override ParameterControlBase CreateControl()
        {
            if (Control == null)
            {
                var control = new ComboParameterControl { ButtonVisible = false };
                control.SetOptions(_options); // ensure that previously specified options are applied
                Control = control;
            }

            return Control;
        }

        #endregion
    }
}