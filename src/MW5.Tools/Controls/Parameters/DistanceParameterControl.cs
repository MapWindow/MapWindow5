// -------------------------------------------------------------------------------------------
// <copyright file="DoubleParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
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

        public LengthUnits Units
        {
            get { return comboBoxAdv1.GetValue<LengthUnits>();  }
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
        /// The get table.
        /// </summary>
        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public override object GetValue()
        {
            return new Distance(doubleTextBox1.DoubleValue, Units);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            doubleTextBox1.DoubleValue = Convert.ToDouble(value);
        }
    }
}