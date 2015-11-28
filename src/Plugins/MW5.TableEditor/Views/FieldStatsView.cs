// -------------------------------------------------------------------------------------------
// <copyright file="FieldStatsView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    internal partial class FieldStatsView : FieldStatsViewBase, IFieldStatsView
    {
        private readonly List<FieldStat> _list = new List<FieldStat>();

        public FieldStatsView()
        {
            InitializeComponent();

            btnCopy.Click += ButtonCopyClick;
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            PopulateFields();

            SetSelectedField();

            UpdateStats();

            cboField.SelectedIndexChanged += (s, e) => UpdateStats();
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        private void ButtonCopyClick(object sender, EventArgs e)
        {
            string s = string.Empty;

            foreach (var item in _list)
            {
                s += item + Environment.NewLine;
            }

            ClipboardHelper.SetText(s);
        }

        private void PopulateFields()
        {
            cboField.Items.Clear();

            var fields = Model.Table.Fields.Where(item => item.Type != AttributeType.String).ToList();
            cboField.DataSource = fields;
        }

        private void SetSelectedField()
        {
            foreach (var item in cboField.Items)
            {
                var fld = item as IAttributeField;
                if (fld != null && fld.Index == Model.FieldIndex)
                {
                    cboField.SelectedItem = fld;
                    break;
                }
            }

            if (cboField.SelectedIndex == -1 && cboField.Items.Count > 0)
            {
                cboField.SelectedIndex = 0;
            }
        }

        private void UpdateList()
        {
            _list.Clear();

            var fld = cboField.SelectedItem as IAttributeField;
            if (fld == null) return;

            var table = Model.Table;

            _list.Add(new FieldStat("Count", table.NumRows.ToString(CultureInfo.InvariantCulture)));
            _list.Add(new FieldStat("Minimum", table.get_MinValue(fld.Index).ToString()));
            _list.Add(new FieldStat("Maximum", table.get_MaxValue(fld.Index).ToString()));
            _list.Add(new FieldStat("Mean", table.get_MeanValue(fld.Index).ToString()));
            _list.Add(new FieldStat("Standard deviation", table.get_StandardDeviation(fld.Index).ToString(CultureInfo.InvariantCulture)));
        }

        private void UpdateStats()
        {
            UpdateList();

            fieldStatsGrid1.DataSource = null;

            fieldStatsGrid1.DataSource = _list;
        }
    }

    internal class FieldStatsViewBase : MapWindowView<FieldStatsModel>
    {
    }
}