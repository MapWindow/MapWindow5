// -------------------------------------------------------------------------------------------
// <copyright file="ElementsDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
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

        public void UpdateSelectionFromMap()
        {
            layoutListBox1.UpdateSelectionFromMap();

            bool hasSelection = layoutListBox1.LayoutControl.SelectedLayoutElements.Any();
            toolRemove.Enabled = hasSelection;
            toolMoveUp.Enabled = hasSelection;
            toolMoveDown.Enabled = hasSelection;
        }
    }
}