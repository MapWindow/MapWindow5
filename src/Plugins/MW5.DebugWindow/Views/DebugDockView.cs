// -------------------------------------------------------------------------------------------
// <copyright file="DebugDockView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using MW5.Plugins.DebugWindow.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Services.Concrete;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Plugins.DebugWindow.Views
{
    public partial class DebugDockView : DockPanelControlBase, IDebugView
    {
        private readonly IAppContext _context;
        private readonly BindingListView<ILogEntry> _entries;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDockView"/> class.
        /// </summary>
        public DebugDockView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            _entries = new BindingListView<ILogEntry>(new SortableBindingList<ILogEntry>());

            InitGrid();

            InitCombo();

            txtFilter.TextChanged += UpdateFilter;

            VisibleChanged += OnVisibleChanged;
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return toolStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        public void Clear()
        {
            _entries.DataSource.Clear();
        }

        private void InitCombo()
        {
            comboBoxAdv1.Items.Clear();
            comboBoxAdv1.AddItemsFromEnum<LogLevel>();
            comboBoxAdv1.SetValue(LogLevel.All);
            comboBoxAdv1.SelectedIndexChanged += UpdateFilter;
        }

        private void InitGrid()
        {
            grid.SetDatasource(_entries);
            Logger.Current.EntryAdded += OnEntryAdded;
        }

        private void OnEntryAdded(object sender, LogEventArgs e)
        {
            if (!IsDockVisible || !grid.IsHandleCreated)
            {
                // do nothing records will be added on the next display of the panel
                return;
            }

            lock (grid)
            {
                Action action = () =>
                    {
                        _entries.DataSource.Add(e.Entry as LogEntry);
                        e.Entry.Displayed = true;
                    };

                grid.SafeInvoke(action);
            }
        }

        /// <summary>
        /// Adds all undisplayed records to the grid.
        /// </summary>
        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (Visible && Logger.Current.Entries.Any(item => !item.Displayed))
            {
                var list = Logger.Current.Entries.Where(item => !item.Displayed).ToList();

                var target = _entries.DataSource as BindingList<ILogEntry>;
                if (target != null)
                {
                    target.RaiseListChangedEvents = false;

                    foreach (var item in list)
                    {
                        target.Add(item);
                        item.Displayed = true;
                    }

                    target.RaiseListChangedEvents = true;

                    target.ResetBindings();
                }
            }
        }

        private void UpdateFilter(object sender, EventArgs e)
        {
            grid.UpdateFilter(comboBoxAdv1.GetValue<LogLevel>(), txtFilter.Text);
        }
    }
}