using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class UpdateMeasurementsView : UpdateMeasurementsViewBase, IUpdateMeasurementsView
    {
        public UpdateMeasurementsView()
        {
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            cboLengthUnits.AddItemsFromEnum<UnitsOfMeasure>();
            cboAreaUnits.AddItemsFromEnum<AreaUnits>();

            cboLengthUnits.SetValue(UnitsOfMeasure.Meters);
            cboAreaUnits.SetValue(AreaUnits.Hectares);

            optAreaExisting.CheckedChanged += (s, e) => UpdateView();
            optLengthExisting.CheckedChanged += (s, e) => UpdateView();
            optAreaNew.CheckedChanged += (s, e) => UpdateView();
            optLengthNew.CheckedChanged += (s, e) => UpdateView();
            optLengthIgnore.CheckedChanged += (s, e) => UpdateView();
            optAreaIgnore.CheckedChanged += (s, e) => UpdateView();

            UpdateView();
        }

        public void Initialize()
        {
            var fields = Model.Fields.Where(f=> f.Type == AttributeType.Double).ToList();
            cboAreaField.DataSource = fields;
            cboLengthField.DataSource = fields;
        }

        #region Properties

        public MeasurementInfo AreaInfo
        {
            get
            {
                var fld = cboAreaField.SelectedItem as IAttributeField;
                int fieldIndex = fld != null ? fld.Index : -1;

                var type = UpdateMeasurementType.Ignore;

                if (optAreaExisting.Checked)
                {
                    type = UpdateMeasurementType.ExitingField;
                }
                else if (optAreaNew.Checked)
                {
                    type = UpdateMeasurementType.NewField;
                }

                return new MeasurementInfo(type,
                                           txtAreaField.Text,
                                           Convert.ToInt32(udAreaWidth.Value),
                                           Convert.ToInt32(udAreaPrecision.Value),
                                           fieldIndex);
            }
        }

        public MeasurementInfo LengthInfo
        {
            get
            {
                var fld = cboLengthField.SelectedItem as IAttributeField;
                int fieldIndex = fld != null ? fld.Index : -1;

                var type = UpdateMeasurementType.Ignore;

                if (optLengthExisting.Checked)
                {
                    type = UpdateMeasurementType.ExitingField;
                }
                else if (optLengthNew.Checked)
                {
                    type = UpdateMeasurementType.NewField;
                }

                return new MeasurementInfo(type,
                                           txtLengthField.Text,
                                           Convert.ToInt32(udLengthWidth.Value),
                                           Convert.ToInt32(udLengthPrecision.Value),
                                           fieldIndex);
            }
        }

        #endregion

        public override void UpdateView()
        {
            UpdateGroupBoxes(true);

            cboAreaField.Enabled = optAreaExisting.Checked;
            txtAreaField.Enabled = optAreaNew.Checked;
            udAreaPrecision.Enabled = optAreaNew.Checked;
            udAreaWidth.Enabled = optAreaNew.Checked;

            cboLengthField.Enabled = optLengthExisting.Checked;
            txtLengthField.Enabled = optLengthNew.Checked;
            udLengthPrecision.Enabled = optLengthNew.Checked;
            udLengthWidth.Enabled = optLengthNew.Checked;

            UpdateGroupBoxes(false);
        }

        private void UpdateGroupBoxes(bool value)
        {
            if (optAreaIgnore.Checked != value)
            {
                ToggleGroupBox(groupArea, value);
            }

            if (optLengthIgnore.Checked != value)
            {
                ToggleGroupBox(groupLength, value);
            }
        }

        private void ToggleGroupBox(GroupBox groupBox, bool enable)
        {
            foreach (Control ctrl in groupBox.Controls)
            {
                if (ctrl is RadioButton)
                {
                    continue;
                }
                
                ctrl.Enabled = enable;

                if (ctrl is PictureBox)
                {
                    (ctrl as PictureBox).Visible = enable;
                }
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class UpdateMeasurementsViewBase : MapWindowView<IAttributeTable> { }
}
