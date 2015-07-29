// -------------------------------------------------------------------------------------------
// <copyright file="BaseParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The base parameter.
    /// </summary>
    public abstract class BaseParameter
    {
        private ParameterControlBase _control;
        protected object _defaultValue;

        /// <summary>
        /// The value changed.
        /// </summary>
        public event Action ValueChanged;

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        public ParameterControlBase Control
        {
            get { return _control; }

            set
            {
                _control = value;
                _control.ValueChanged += OnValueChanged;
            }
        }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseParameter"/> is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The control value changed.
        /// </summary>
        private void OnValueChanged(object sender, EventArgs e)
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler();
            }
        }

        public void SetDefaultValue(object value)
        {
            _defaultValue = value;
        }

        public object GetDefaultValue()
        {
            return _defaultValue;
        }
    }
}