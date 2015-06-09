using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Properties;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Controls;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class TableEditorView : DockPanelControlBase, ITableEditorView
    {
        private readonly TablePanelCollection _panels;
        private IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEditorView"/> class.
        /// </summary>
        public TableEditorView()
        {
            InitializeComponent();

            _panels = new TablePanelCollection(dockingManager1, this);

            InitMenu();
        }

        public void Initialize(IAppContext context)
        {
            _context = context;

            UpdateView();
        }

        private void InitMenu()
        {
            // handlers aren't attached to the items with not null tag
            toolEdit.Tag = 0;
            toolSelection.Tag = 0;
            toolFields.Tag = 0;
            toolTools.Tag = 0;
            toolLayout.Tag = 0;

            toolEdit.DropDownOpening += (s, e) => OnMenuOpening();
            toolSelection.DropDownOpening += (s, e) => OnMenuOpening();
            toolLayout.DropDownOpening += (s, e) => OnMenuOpening();
            toolFields.DropDownOpening += (s, e) => OnMenuOpening();
            toolTools.DropDownOpening += (s, e) => OnMenuOpening();
        }

        public Size DockingClientSize
        {
            get { return new Size(ClientSize.Width, ClientSize.Height - toolStripEx1.Height); }
        }

        public TablePanelCollection Panels
        {
            get { return _panels; }
        }

        public TableEditorGrid CreateGrid()
        {
            var grid = new TableEditorGrid {RowManager = new RowManager()};
            grid.DoubleBuffered(true);
            grid.CurrentCellBorderColor = Color.LightGreen;
            Controls.Add(grid);
            return grid;
        }

        public void ClearCurrentCell()
        {
            var grid = ActiveGrid;
            if (grid != null)
            {
                grid.CurrentCell = null;
            }
        }

        public void UpdateDatasource()
        {
            var grid = ActiveGrid;
            if (grid != null)
            {
                grid.TableSource = grid.TableSource;
            }

            UpdateView();
        }

        public void OnActivateDockingPanel()
        {
            UpdateEditingIcon();
        }

        public void UpdateView()
        {
            bool hasPanels = Panels.Any();

            lblNoLayers.Visible = !hasPanels;

            toolStripEx1.Enabled = hasPanels;

            DisableMenus();

            UpdateMenus();

            UpdateEditingIcon();

            UpdatePanelCaption(ActiveLayerHandle);

            var grid = ActiveGrid;
            if (grid != null)
            {
                grid.Invalidate();
            }
        }

        private void UpdateEditingIcon()
        {
            var fs = ActiveFeatureSet;
            if (fs == null)
            {
                return;
            }

            bool editing = fs.Table.EditMode;

            var img = editing ? Resources.icon_save1 : Resources.icon_layer_edit;
            
            toolEdit.Image = img;
        }

        public void UpdatePanelCaption(int layerHandle)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);
            if (layer == null)
            {
                return;
            }

            string msg = layer.Name;

            var fs = layer.FeatureSet;
            if (fs != null)
            {
                if (fs.EditingTable)
                {
                    msg += "*";
                }

                if (fs.NumSelected > 0)
                {
                    msg += string.Format(" - selected {0} from {1}", fs.NumSelected, fs.NumFeatures);
                }
            }

            var panel = Panels.FirstOrDefault(p => p.LayerHandle == layerHandle);
            if (panel != null)
            {
                panel.Caption = msg;    
            }
        }

        private void UpdateMenus()
        {
            var fs = ActiveFeatureSet;
            if (fs == null)
            {
                return;
            }

            bool editing = fs.Table.EditMode;

            mnuStartEdit.Enabled = !editing;
            mnuSaveChanges.Enabled = editing;

            mnuAddField.Enabled = editing;
            mnuRemoveField.Enabled = editing;
            mnuRenameField.Enabled = editing;
            mnuCalculateField.Enabled = editing;
            mnuUpdateMeasurements.Enabled = editing;
            mnuCopyShapeIDs.Enabled = editing;
            mnuGenerateOrUpdateShapeID.Enabled = editing;
            mnuImportExtData.Enabled = editing;
            mnuImportFieldDefinitions.Enabled = editing;
            mnuZoomToEdited.Enabled = editing;
            mnuReplace.Enabled = editing;

            bool hasSelection = fs.NumSelected > 0;
            mnuClearSelection.Enabled = hasSelection;
            mnuZoomToSelected.Enabled = hasSelection;
            mnuShowSelected.Enabled = hasSelection;
            mnuInvertSelection.Enabled = true;
            mnuSelectAll.Enabled = true;

            var grid = ActiveGrid;
            if (grid != null)
            {
                mnuShowSelected.Text = grid.RowManager.Filtered ? "Show All Shapes" : "Show Selected Shapes";
            }

            mnuExportFeatures.Enabled = true;
            mnuFind.Enabled = true;
            mnuQuery.Enabled = true;

            mnuLayoutHorizontal.Enabled = true;
            mnuLayoutVertical.Enabled = true;
            mnuLayoutTabbed.Enabled = true;

            var layout = AppConfig.Instance.TableEditorLayout;
            mnuLayoutHorizontal.Checked = layout == Enums.TableEditorLayout.Horizontal;
            mnuLayoutVertical.Checked = layout == Enums.TableEditorLayout.Vertical;
            mnuLayoutTabbed.Checked = layout == Enums.TableEditorLayout.Tabbed;
        }

        private void OnMenuOpening()
        {
            DisableMenus();

            UpdateMenus();
        }

        private void DisableMenus()
        {
            foreach (ToolStripItem item in toolStripEx1.Items)
            {
                var dropDown = item as ToolStripDropDownItem;
                if (dropDown != null)
                {
                    foreach (ToolStripItem subItem in dropDown.DropDownItems)
                    {
                        subItem.Enabled = false;
                    }
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }

        public int ActiveLayerHandle
        {
            get
            {
                var panel = Panels.ActivePanel;
                return panel != null ? panel.LayerHandle : -1;
            }
        }

        public TableEditorGrid ActiveGrid
        {
            get
            {
                var panel = Panels.ActivePanel;
                if (panel == null || panel.LayerHandle == -1) return null;

                return panel.Control as TableEditorGrid;
            }
        }

        public IFeatureSet ActiveFeatureSet
        {
            get
            {
                var panel = Panels.ActivePanel;
                if (panel == null || panel.LayerHandle == -1) return null;

                return _context.Legend.Layers.GetFeatureSet(panel.LayerHandle);
            }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return toolStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }
    }

    public class TableEditorViewBase : MapWindowView<ILayer> { }
}
