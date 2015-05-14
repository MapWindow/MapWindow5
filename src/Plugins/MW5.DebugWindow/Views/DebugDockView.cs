// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDockWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The sample dock window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MW5.Plugins.DebugWindow.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Services.Concrete;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using MW5.Shared.Log;
using MW5.UI.Helpers;
using Syncfusion.Grouping;

namespace MW5.Plugins.DebugWindow.Views
{
    public partial class DebugDockView : DockPanelControlBase, IDebugView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDockView"/> class.
        /// </summary>
        public DebugDockView()
        {
            InitializeComponent();

            InitGrid();

            InitCombo();

            watermarkTextbox1.TextChanged += (s, e) => UpdateFilter();
        }

        private void InitCombo()
        {
            comboBoxAdv1.Items.Clear();
            comboBoxAdv1.AddItemsFromEnum<LogLevel>();
            comboBoxAdv1.SetValue(LogLevel.All);
            comboBoxAdv1.SelectedIndexChanged += (s, e) => UpdateFilter();
        }

        private void UpdateFilter()
        {
            _listControl.Adapter.ClearFilter();
            
            var level = comboBoxAdv1.GetValue<LogLevel>();
            if (level != LogLevel.All)
            {
                _listControl.Adapter.AddFilterMatch(entry => entry.Level, level);
            }

            _listControl.Adapter.AddFilterLike(entry => entry.DetailedMessage, watermarkTextbox1.Text);
        }

        private void InitGrid()
        {
            _listControl.BorderStyle = BorderStyle.None;

            var adapter = _listControl.Adapter;
            adapter.ReadOnly = true;
            adapter.WrapText = true;
            adapter.HotTracking = true;

            _listControl.DataSource = Logger.Current.Entries;
            Logger.Current.EntryAdded += Current_EntryAdded;

            adapter.GetColumnStyle(r => r.TimeStamp).Format = "hh:mm:ss.fff";

            var style = adapter.GetColumnStyle(r => r.Level);
            style.ImageList = imageList1;
            style.ImageIndex = 0;

            adapter.AdjustColumnWidths();
            adapter.AdjustRowHeights();
            adapter.AutoAdjustRowHeights = true;

            adapter.SetColumnIcon(r => r.Level, GetIcon);
        }

        void Current_EntryAdded(object sender, LogEventArgs e)
        {
            // TODO: do it for the last row only
            _listControl.Adapter.AdjustRowHeights();
        }

        private int GetIcon(ILogEntry entry)
        {
            switch (entry.Level)
            {
                case LogLevel.Info:
                    return 0;
                case LogLevel.Debug:
                    return 1;
                case LogLevel.Warn:
                    return 2;
                case LogLevel.Error:
                    return 3;
                case LogLevel.Fatal:
                    return 3;
            }
            return -1;
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return toolStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }
    }
}