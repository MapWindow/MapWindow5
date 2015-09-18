// -------------------------------------------------------------------------------------------
// <copyright file="DistanceParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Tools.Model;
using MW5.UI.Helpers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control for entering distance in specified length units.
    /// </summary>
    public partial class DistanceParameterControl : ParameterControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public DistanceParameterControl()
        {
            InitializeComponent();

            comboBoxAdv1.AddItemsFromEnum<LengthUnits>();
            comboBoxAdv1.SetValue(LengthUnits.Kilometers);
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return doubleTextBox1; }
        }

        /// <summary>
        /// Gets the selected length units.
        /// </summary>
        public LengthUnits Units
        {
            get { return comboBoxAdv1.GetValue<LengthUnits>(); }
        }

        /// <summary>
        /// Gets the value of control.
        /// </summary>
        /// <returns>Instance of Distance class.</returns>
        public override object GetValue()
        {
            return new Distance(doubleTextBox1.DoubleValue, Units);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">Either double or Distance value is expected.</param>
        public override void SetValue(object value)
        {
            if (value is Distance)
            {
                doubleTextBox1.DoubleValue = (value as Distance).Value;
                comboBoxAdv1.SetValue((value as Distance).Units);
            }
            else
            {
                doubleTextBox1.DoubleValue = Convert.ToDouble(value);
            }
        }
    }
}