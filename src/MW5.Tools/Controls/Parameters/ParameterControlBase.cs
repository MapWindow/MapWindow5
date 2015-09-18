// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using MW5.Shared;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Base class for parameter controls. Derived classes are used to provide UI for tool parameters.
    /// </summary>
    [TypeDescriptionProvider(typeof(ReplaceControlDescripterProvider<ParameterControlBase, UserControl>))]
    public abstract partial class ParameterControlBase : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterControlBase"/> class.
        /// </summary>
        protected ParameterControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The value changed.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets control caption.
        /// </summary>
        public abstract string Caption { get; set; }

        /// <summary>
        /// Gets the name of the parameter the control was generated for.
        /// </summary>
        public string ParameterName { get; internal set; }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public abstract Control ToolTipControl { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>Value type that must match the type of parameter the control was generated for.</returns>
        public abstract object GetValue();

        /// <summary>
        /// Sets the value. 
        /// </summary>
        /// <param name="value">Value type must match the type of parameter the control was generated for.</param>
        public abstract void SetValue(object value);

        /// <summary>
        /// The fire value changed.
        /// </summary>
        protected void FireValueChanged()
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}