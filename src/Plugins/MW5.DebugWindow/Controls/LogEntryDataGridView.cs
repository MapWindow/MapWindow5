// -------------------------------------------------------------------------------------------
// <copyright file="LogEntryDataGridView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using MW5.Plugins.DebugWindow.Properties;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.UI.Controls;

namespace MW5.Plugins.DebugWindow.Controls
{
    public partial class LogEntryDataGridView : StronglyTypedDataGridView<ILogEntry>, IItemFilter<ILogEntry>
    {
        private LogLevel _logLevel;
        private string _searchToken;

        public LogEntryDataGridView()
        {
            InitializeComponent();

            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            BackgroundColor = Color.White;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.DoubleBuffered(true);
        }

        /// <summary>
        /// Tests if the item should be included.
        /// </summary>
        public bool Include(ILogEntry item)
        {
            if (_logLevel != LogLevel.All && item.Level != _logLevel)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(_searchToken))
            {
                return item.DetailedMessage.ContainsIgnoreCase(_searchToken);
            }

            return true;
        }

        public Bitmap GetIcon(ILogEntry entry)
        {
            switch (entry.Level)
            {
                case LogLevel.Info:
                    return Resources.img_info;
                case LogLevel.Debug:
                    return Resources.img_debug16;
                case LogLevel.Warn:
                    return Resources.img_warning16;
                case LogLevel.Error:
                    return Resources.img_error16;
                case LogLevel.Fatal:
                    return Resources.img_critical16;
                case LogLevel.All:
                    break;
            }

            return null;
        }

        public void SetDatasource(BindingListView<ILogEntry> entries)
        {
            Adapter.SetDatasource(entries);

            // it seems that column generation is performed once again on adding first object,
            // but we are quite content to to have columns generated from the type of list
            AutoGenerateColumns = false;

            UpdateColumns();
        }

        public void UpdateFilter(LogLevel level, string filterToken)
        {
            var bs = Adapter.BindingSource;
            if (bs == null) return;

            _logLevel = level;
            _searchToken = filterToken;

            if (string.IsNullOrWhiteSpace(filterToken) && level == LogLevel.All)
            {
                bs.RemoveFilter();
                return;
            }

            bs.ApplyFilter(Include);
        }

        private void UpdateColumns()
        {
            var cmn1 = Adapter.GetColumn(e => e.Index);
            cmn1.DisplayIndex = 0;
            cmn1.Width = 40;

            var cmn2 = Adapter.GetColumn(e => e.Image);
            cmn2.DisplayIndex = 1;
            cmn2.Width = 40;
            Adapter.SetColumnIcon(e => e.Image, GetIcon);

            var cmn3 = Adapter.GetColumn(e => e.Level);
            cmn3.DisplayIndex = 2;
            cmn3.Width = 75;

            var cmn4 = Adapter.GetColumn(e => e.DetailedMessage);
            cmn4.DisplayIndex = 3;
            cmn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var cmn5 = Adapter.GetColumn(e => e.TimeStamp);
            cmn5.DefaultCellStyle.Format = "hh:mm:ss.fff";
            cmn5.DisplayIndex = 4;
            cmn5.Width = 150;
        }
    }
}