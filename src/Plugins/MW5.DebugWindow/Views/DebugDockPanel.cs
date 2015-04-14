// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDockWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The sample dock window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Plugins.DebugWindow.Views
{
    public partial class DebugDockPanel : DockPanelControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDockPanel"/> class.
        /// </summary>
        public DebugDockPanel()
        {
            InitializeComponent();

            _listControl.BorderStyle = BorderStyle.None;
            _listControl.ReadOnly = true;
            _listControl.WrapText = true;
            _listControl.HotTracking = true;

            _listControl.DataSource = Logger.Current.Entries;
            _listControl.AdjustRowHeights();
            _listControl.AutoAdjustRowHeights = true;
        }
    }
}