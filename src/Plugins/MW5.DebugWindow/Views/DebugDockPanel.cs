// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDockWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The sample dock window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.UI.Controls;

namespace MW5.Plugins.DebugWindow.Views
{
    #region

    

    #endregion

    /// <summary>
    /// The sample dock window.
    /// </summary>
    public partial class DebugDockPanel : DockPanelControlBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDockPanel"/> class.
        /// </summary>
        public DebugDockPanel()
        {
            InitializeComponent();
        }

        #endregion

        public void Write(string prefix, string message)
        {
            if (Visible)
            {
                DebugTextbox.AppendText(string.Format("[{0}]: {1}{2}", prefix, message, Environment.NewLine));
            }
        }
    }
}