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

        public void Write(string prefix, string message)
        {
            if (this.Visible)
            {
                this.DebugTextbox.AppendText(string.Format("[{0}]: {1}{2}", prefix, message, Environment.NewLine));
            }
        }
    }
}