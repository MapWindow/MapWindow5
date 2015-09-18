// -------------------------------------------------------------------------------------------
// <copyright file="ComboParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections;
using System.Windows.Forms;
using MW5.Tools.Controls.Parameters.Interfaces;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents as ComboBox control to display OptionsParameter.
    /// </summary>
    public partial class ComboParameterControl : ParameterControlBase, IOptionsParameterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboParameterControl"/> class.
        /// </summary>
        public ComboParameterControl()
        {
            InitializeComponent();

            buttonAdv1.Visible = false;

            comboBoxAdv1.SelectedValueChanged += (s, e) => FireValueChanged();
        }

        /// <summary>
        /// Gets or sets control caption.
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
            get { return comboBoxAdv1; }
        }

        /// <summary>
        /// Sets the options for ComboBox control.
        /// </summary>
        public void SetOptions(object options)
        {
            // comboBoxAdv.DataSource raises SelectedIndex changed event twice on first assignment
            // presumably because of a _bug, so let's put some extra lines here, rather than
            // hunting for bugs afterwards
            //comboBoxAdv1.DataSource = options;
            comboBoxAdv1.Items.Clear();

            var list = options as IList;

            if (list == null)
            {
                return;
            }

            foreach (var item in list)
            {
                comboBoxAdv1.Items.Add(item);
            }

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the value. Value type must match the type of parameter the control was generated for.
        /// </summary>
        public override object GetValue()
        {
            return comboBoxAdv1.SelectedItem;
        }

        /// <summary>
        /// Sets the value. Value type must match the type of parameter the control was generated for.
        /// </summary>
        /// <param name="value"></param>
        public override void SetValue(object value)
        {
            foreach (var item in comboBoxAdv1.Items)
            {
                if (item == value || Equals(item.ToString(), value))
                {
                    comboBoxAdv1.SelectedItem = item;
                    return;
                }
            }
        }
    }
}