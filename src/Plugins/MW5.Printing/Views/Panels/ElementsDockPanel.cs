// -------------------------------------------------------------------------------------------
// <copyright file="ElementsDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;

namespace MW5.Plugins.Printing.Views.Panels
{
    public partial class ElementsDockPanel : DockPanelControlBase, IMenuProvider
    {
        public ElementsDockPanel()
        {
            InitializeComponent();
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