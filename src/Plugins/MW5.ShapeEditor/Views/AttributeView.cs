using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.ShapeEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;

namespace MW5.Plugins.ShapeEditor.Views
{
    public partial class AttributeView : AttributesViewBase, IAttributeView
    {
        const double MaxRows = 15.0;

        public AttributeView()
        {
            InitializeComponent();

            Shown += AttributesForm_Shown;
        }

        public void Initialize()
        {
            Populate();
        }

        /// <summary>
        /// Gets values of fields with with field indices as keys.
        /// </summary>
        public Dictionary<int, string> Values
        {
            get
            {
                var dict = new Dictionary<int, string>();

                var list = tableLayoutPanel1.Controls.OfType<TextBox>().Where(t => t.Enabled);

                foreach (var txt in list)
                {
                    int fieldIndex = (int) txt.Tag;
                    dict.Add(fieldIndex, txt.Text);
                }

                return dict;
            }
        }

        public void FocusInvalidTextBox(int fieldIndex)
        {
            var txt = tableLayoutPanel1.Controls.OfType<TextBox>().FirstOrDefault(t => (int)t.Tag == fieldIndex);
            if (txt != null)
            {
                txt.Focus();
            }
        }

        private void Populate()
        {
            var fs = Model.Layer.FeatureSet;
            var table = fs.Table;
            int numFields = table.Fields.Count(f => f.Visible);

            tableLayoutPanel1.SuspendLayout();

            PrepareTableLayout(fs, numFields);

            AddFields(fs);

            tableLayoutPanel1.ResumeLayout();
        }

        private void PrepareTableLayout(IFeatureSet fs, int numFields)
        {
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.AutoSize = true;

            tableLayoutPanel1.RowCount = numFields;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            int columCount = (int)Math.Ceiling(numFields / MaxRows);
            tableLayoutPanel1.ColumnCount = columCount * 3;

            for (int n = 0; n < columCount; n++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            }
        }

        private void AddFields(IFeatureSet fs)
        {
            bool editing = fs.InteractiveEditing;
            int padding = editing ? 5 : 0;
            var table = fs.Table;

            int numFields = table.Fields.Count;

            int count = 0;
            for (int i = 0; i < numFields; i++)
            {
                var field = table.Fields[i];
                if (!field.Visible)
                {
                    continue;
                }
                
                int cmnIndex = (int)(Math.Floor(count / MaxRows) * 3);
                int rowIndex = count % (int)MaxRows;
                count++;
                

                string name = field.DisplayName.ToUpper();
                var fieldType = field.Type;

                var lbl = new Label
                {
                    Text = name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    Padding = new Padding(padding),
                    BackColor = Color.White
                };

                tableLayoutPanel1.Controls.Add(lbl, cmnIndex, rowIndex);

                lbl = new Label
                {
                    Text = editing ? GetShortFieldType(fieldType) : "",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    Padding = new Padding(0, padding, 0, padding)
                };

                tableLayoutPanel1.Controls.Add(lbl, cmnIndex + 2, rowIndex);

                var value = fs.Table.CellValue(i, Model.ShapeIndex) ?? GetDefaultValue(fieldType);
                var control = new TextBox() { ReadOnly = !editing, Text = value.ToString() }; ;
                control.Dock = DockStyle.Fill;
                control.Padding = new Padding(padding);
                control.Tag = i;
                tableLayoutPanel1.Controls.Add(control, cmnIndex + 1, rowIndex);

                control.Enabled = name.ToLower() != ShapefileHelper.MWShapeIdField && name.ToLower() != OgrFidName.ToLower();
            }
        }

        private string OgrFidName
        {
            get
            {
                var layer = Model.Layer.VectorSource;
                return layer == null ? string.Empty : layer.FidColumnName;
            }
        }

        private object GetDefaultValue(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Integer:
                    return 0;
                case AttributeType.Double:
                    return 0.0;
                case AttributeType.String:
                default:
                    return "";
            }
        }

        private string GetShortFieldType(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Integer:
                    return "i";
                case AttributeType.Double:
                    return "d";
                case AttributeType.String:
                default:
                    return "s";
            }
        }


        private void AttributesForm_Shown(object sender, EventArgs e)
        {
            if (!Model.Layer.FeatureSet.InteractiveEditing)
            {
                btnOk.Focus();
            }
            else
            {
                var box = Win32Api.GetFocusedControl() as TextBox;
                if (box != null)
                {
                    box.SelectAll();
                }
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class AttributesViewBase : MapWindowView<AttributeViewModel> { }
}
