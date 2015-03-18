// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDockWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The sample dock window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Plugins.TemplatePlugin
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// The sample dock window.
    /// </summary>
    public partial class SampleDockWindow : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDockWindow"/> class.
        /// </summary>
        public SampleDockWindow()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Track if the window is already added to the panels
        /// </summary>
        public bool IsAddedAsPanel { get; set; }

        public void Write(string prefix, string message)
        {
            if (!this.IsAddedAsPanel)
            {
                // This window is not yet added to the panels:
                return;
            }

            this.DebugTextbox.AppendText(string.Format("[{0}]: {1}{2}", prefix, message, Environment.NewLine));
        }
    }
}