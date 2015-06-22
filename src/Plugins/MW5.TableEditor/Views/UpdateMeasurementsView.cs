// -------------------------------------------------------------------------------------------
// <copyright file="UpdateMeasurementsView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class UpdateMeasurementsView : UpdateMeasurementsViewBase, IUpdateMeasurementsView
    {
        public UpdateMeasurementsView()
        {
            InitializeComponent();

            InitControls();
        }

        public void Initialize()
        {
            var fields = Model.Fields.Where(f => f.Type == AttributeType.Double).ToList();
            cboAreaField.DataSource = fields.ToList();
            cboLengthField.DataSource = fields.ToList();

            txtLengthField.Text = GetLengthFieldDefaultName();

            if (Model.GeometryType != GeometryType.Polygon)
            {
                optAreaIgnore.Checked = true;
                optAreaExisting.Enabled = false;
                optAreaIgnore.Enabled = false;
                optAreaNew.Enabled = false;
            }

            RestoreConfig();

            GuessFields();
        }

        public override void BeforeClose()
        {
            SaveConfig();
        }

        public MeasurementInfo AreaInfo
        {
            get
            {
                var fld = cboAreaField.SelectedItem as IAttributeField;
                int fieldIndex = fld != null ? fld.Index : -1;

                var type = UpdateMeasurementType.Ignore;

                if (optAreaExisting.Checked)
                {
                    type = UpdateMeasurementType.ExistingField;
                }
                else if (optAreaNew.Checked)
                {
                    type = UpdateMeasurementType.NewField;
                }

                return new MeasurementInfo(
                    type,
                    txtAreaField.Text,
                    Convert.ToInt32(udAreaWidth.Value),
                    Convert.ToInt32(udAreaPrecision.Value),
                    fieldIndex);
            }
        }

        public AreaUnits AreaUnits
        {
            get { return cboAreaUnits.GetValue<AreaUnits>(); }
        }

        public LengthUnits LengthUnits
        {
            get { return cboLengthUnits.GetValue<LengthUnits>(); }
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
                    type = UpdateMeasurementType.ExistingField;
                }
                else if (optLengthNew.Checked)
                {
                    type = UpdateMeasurementType.NewField;
                }

                return new MeasurementInfo(
                    type,
                    txtLengthField.Text,
                    Convert.ToInt32(udLengthWidth.Value),
                    Convert.ToInt32(udLengthPrecision.Value),
                    fieldIndex);
            }
        }

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

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private string GetLengthFieldDefaultName()
        {
            return Model.GeometryType == GeometryType.Polygon ? "Perimeter" : "Length";
        }

        private void GuessFields()
        {
            if (TryGuessField(new[] { txtLengthField.Text, GetLengthFieldDefaultName() }, cboLengthField))
            {
                optLengthExisting.Checked = true;
            }
            else
            {
                optLengthNew.Checked = true;
            }

            if (Model.GeometryType == GeometryType.Polygon)
            {
                if (TryGuessField(new[] { txtAreaField.Text, "Area" }, cboAreaField))
                {
                    optAreaExisting.Checked = true;
                }
                else
                {
                    optAreaNew.Checked = true;
                }
            }
        }

        private void InitControls()
        {
            var lengthUnits = new List<LengthUnits>
                                  {
                                      LengthUnits.Meters,
                                      LengthUnits.Kilometers,
                                      LengthUnits.Feet,
                                      LengthUnits.Miles
                                  };

            cboLengthUnits.AddItemsFromEnum(lengthUnits);

            var areaUnits = new List<AreaUnits>
                                {
                                    AreaUnits.SquareMeters,
                                    AreaUnits.Hectares,
                                    AreaUnits.SquareKilometers,
                                    AreaUnits.SquareFeet,
                                    AreaUnits.Acres,
                                    AreaUnits.SquareMiles
                                };

            cboAreaUnits.AddItemsFromEnum(areaUnits);

            cboLengthUnits.SetValue(LengthUnits.Meters);
            cboAreaUnits.SetValue(AreaUnits.Hectares);

            optAreaExisting.CheckedChanged += (s, e) => UpdateView();
            optLengthExisting.CheckedChanged += (s, e) => UpdateView();
            optAreaNew.CheckedChanged += (s, e) => UpdateView();
            optLengthNew.CheckedChanged += (s, e) => UpdateView();
            optLengthIgnore.CheckedChanged += (s, e) => UpdateView();
            optAreaIgnore.CheckedChanged += (s, e) => UpdateView();

            UpdateView();
        }

        private void RestoreConfig()
        {
            try
            {
                var config = AppConfig.Instance;
                udAreaPrecision.SetValue(config.MeasurementsAreaPrecision);
                udAreaWidth.SetValue(config.MeasurementsAreaWidth);
                udLengthPrecision.SetValue(config.MeasurementsLengthPrecision);
                udLengthWidth.SetValue(config.MeasurementsLengthWidth);
                txtAreaField.Text = config.MeasurementsAreaFieldName;
                txtLengthField.Text = config.MeasurementsLengthFieldName;
                cboAreaUnits.SetValue(config.MeasurementsAreaUnits);
                cboLengthUnits.SetValue(config.MeasurementsLengthUnits);

                if (Model.GeometryType == GeometryType.Polygon)
                {
                    txtLengthField.Text = config.MeasurementsPerimeterFieldName;
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to restore settings for Update measurements dialog.", ex);
            }
        }

        private void SaveConfig()
        {
            var config = AppConfig.Instance;
            config.MeasurementsAreaPrecision = Convert.ToInt32(udAreaPrecision.Value);
            config.MeasurementsAreaWidth = Convert.ToInt32(udAreaWidth.Value);
            config.MeasurementsLengthPrecision = Convert.ToInt32(udLengthPrecision.Value);
            config.MeasurementsLengthWidth = Convert.ToInt32(udLengthWidth.Value);
            config.MeasurementsAreaFieldName = txtAreaField.Text;
            config.MeasurementsAreaUnits = cboAreaUnits.GetValue<AreaUnits>();
            config.MeasurementsLengthUnits = cboLengthUnits.GetValue<LengthUnits>();

            if (Model.GeometryType == GeometryType.Polygon)
            {
                config.MeasurementsPerimeterFieldName = txtLengthField.Text;
            }
            else
            {
                config.MeasurementsLengthFieldName = txtLengthField.Text;
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

        private bool TryGuessField(IEnumerable<string> names, ComboBoxAdv fieldCombo)
        {
            foreach (var name in names)
            {
                int index = Model.Table.Fields.IndexByName(name);
                if (index == -1)
                {
                    continue;
                }

                foreach (var item in fieldCombo.Items)
                {
                    var fld = item as IAttributeField;
                    if (fld != null && fld.Index == index)
                    {
                        fieldCombo.SelectedItem = item;
                        return true;
                    }
                }
            }

            return false;
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

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            SetDefaults();

            GuessFields();
        }

        private void SetDefaults()
        {
            cboAreaUnits.SetValue(AreaUnits.SquareMeters);
            cboLengthUnits.SetValue(LengthUnits.Meters);
            udAreaPrecision.SetValue(3);
            udAreaWidth.SetValue(14);
            udLengthPrecision.SetValue(3);
            udLengthWidth.SetValue(14);
            txtAreaField.Text = "Area";
            txtLengthField.Text = GetLengthFieldDefaultName();
        }
    }

    public class UpdateMeasurementsViewBase : MapWindowView<IFeatureSet>
    {
    }
}