// -------------------------------------------------------------------------------------------
// <copyright file="OptionsParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Model.Parameters
{
    public abstract class OptionsParameter: BaseParameter
    {
        public abstract object OptionsSource { get; }
    }

    /// <summary>
    /// The options parameter.
    /// </summary>
    public class OptionsParameter<T> : OptionsParameter
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
        public new T Value
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

        public override object OptionsSource
        {
            get { return _options; }
        }
    }
}