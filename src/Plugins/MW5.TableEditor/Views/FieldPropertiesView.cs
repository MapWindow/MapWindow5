// -------------------------------------------------------------------------------------------
// <copyright file="FieldPropertiesView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Views
{
    /// <summary>
    /// Displays and edits properties of a field.
    /// </summary>
    internal partial class FieldPropertiesView : FieldPropertiesViewBase, IFieldPropertiesView
    {
        public FieldPropertiesView()
        {
            InitializeComponent();

            InitControls();
        }

        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        public void Initialize()
        {
            var fld = Model.Field;
            txtName.Text = fld.Name;
            txtAlias.Text = fld.Alias;
            chkVisible.Checked = fld.Visible;
            cboDataType.SetValue(fld.Type);
            udPrecision.SetValue(fld.Precision);
            udWidth.SetValue(fld.Width);
            txtExpression.Text = fld.Expression;

            RefreshControls();
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IAttributeField NewField
        {
            get
            {
                var fld = new AttributeField
                              {
                                  Name = txtName.Text,
                                  Alias = txtAlias.Text,
                                  Visible = chkVisible.Checked,
                                  Type = cboDataType.GetValue<AttributeType>(),
                                  Precision = (int)udPrecision.Value,
                                  Width = (int)udWidth.Value
                              };

                return fld;
            }
        }

        private void InitControls()
        {
            cboDataType.AddItemsFromEnum<AttributeType>();
        }

        private void RefreshControls()
        {
            var type = cboDataType.GetValue<AttributeType>();

            txtName.Enabled = Model.AllowEditing || Model.AddField;
            cboDataType.Enabled = Model.AddField;
            udPrecision.Enabled = Model.AddField && type == AttributeType.Double;
            udWidth.Enabled = Model.AddField;

            if (Model.AddField)
            {
                var value = cboDataType.GetValue<AttributeType>();
                switch (value)
                {
                    case AttributeType.String:
                        udWidth.Maximum = 255;
                        udWidth.Value = 50;
                        udPrecision.Value = 0;
                        break;
                    case AttributeType.Integer:
                        // 10 is will be reopened as double (dbfopen.c)
                        // integer must have width < 10 and precision = 0
                        udWidth.Maximum = 9;
                        udWidth.Value = 9;        
                        udPrecision.Value = 0;
                        break;
                    case AttributeType.Double:
                        udWidth.Maximum = 40;
                        udWidth.Value = 20;
                        udPrecision.Value = 10;
                        break;
                }
            }
        }

        private void cboDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }
    }

    internal class FieldPropertiesViewBase : MapWindowView<FieldPropertiesModel>
    {
    }
}