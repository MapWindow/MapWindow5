// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using MW5.Shared;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// The parameter control base.
    /// </summary>
    [TypeDescriptionProvider(typeof(ReplaceControlDescripterProvider<ParameterControlBase, UserControl>))]
    public abstract partial class ParameterControlBase : UserControl, IParameterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterControlBase"/> class.
        /// </summary>
        public ParameterControlBase()
        {
            InitializeComponent();
        }

        public string ParameterName { get; internal set; }

        /// <summary>
        /// The value changed.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public abstract string Caption { get; set; }

        /// <summary>
        /// The get table.
        /// </summary>
        public abstract TableLayoutPanel GetTable();

        /// <summary>
        /// Gets the value.
        /// </summary>
        public abstract object GetValue();

        /// <summary>
        /// Sets the value.
        /// </summary>
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