// -------------------------------------------------------------------------------------------
// <copyright file="TableEditorView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Properties;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Controls;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    /// <summary>
    /// Table editor view representing menu and docking manager to host attribute tables for particular layers.
    /// </summary>
    [HasRegions]
    internal partial class TableEditorView : DockPanelControlBase, ITableEditorView
    {
        private readonly TablePanelCollection _panels;
        private IAppContext _context;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEditorView" /> class.
        /// </summary>
        public TableEditorView()
        {
            InitializeComponent();

            ActiveColumnIndex = -1;

            _panels = new TablePanelCollection(dockingManager1, this);

            InitMenu();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the index of the active column, i.e. the one for which context menu was displayed.
        /// </summary>
        public int ActiveColumnIndex { get; private set; }

        /// <summary>
        /// Gets currently active featureset.
        /// </summary>
        public IFeatureSet ActiveFeatureSet
        {
            get
            {
                var panel = Panels.ActivePanel;

                if (panel == null || panel.LayerHandle == -1)
                {
                    return null;
                }

                return _context.Legend.Layers.GetFeatureSet(panel.LayerHandle);
            }
        }

        /// <summary>
        /// Gets currently active grid.
        /// </summary>
        public TableEditorGrid ActiveGrid
        {
            get
            {
                var panel = Panels.ActivePanel;
                if (panel == null || panel.LayerHandle == -1)
                {
                    return null;
                }

                return panel.Control as TableEditorGrid;
            }
        }

        /// <summary>
        /// Gets the handle of the active layer.
        /// </summary>
        public int ActiveLayerHandle
        {
            get
            {
                var panel = Panels.ActivePanel;
                return panel != null ? panel.LayerHandle : -1;
            }
        }

        /// <summary>
        /// Gets buttons to wire up menu commands for.
        /// </summary>
        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        /// <summary>
        /// Gets the ok button.
        /// </summary>
        public ButtonBase OkButton
        {
            get { return null; }
        }

        /// <summary>
        /// Gets list of docking panels.
        /// </summary>
        public TablePanelCollection Panels
        {
            get { return _panels; }
        }

        /// <summary>
        /// Gets toolstrips to wire up menu commands for.
        /// </summary>
        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return toolStripEx1.Items;
                yield return contextMenuStripEx1.Items;
            }
        }

        /// <summary>
        /// Gets the size client area for docking panels.
        /// </summary>
        private Size DockingClientSize
        {
            get { return new Size(ClientSize.Width, ClientSize.Height - toolStripEx1.Height); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Clears the current cell.
        /// </summary>
        public void ClearCurrentCell()
        {
            var grid = ActiveGrid;
            if (grid != null)
            {
                grid.CurrentCell = null;
            }
        }

        /// <summary>
        /// Creates new table panel for the layer.
        /// </summary>
        public TablePanelInfo CreateTablePanel(ILegendLayer layer)
        {
            var grid = CreateGrid();

            grid.TableSource = layer.FeatureSet;

            grid.ColumnContextNeeded += (s, e) =>
                {
                    var ctrl = s as Control;
                    if (ctrl != null)
                    {
                        ActiveColumnIndex = e.ColumnIndex;
                        contextMenuStripEx1.Show(Cursor.Position);
                    }
                };

            var first = Panels.FirstOrDefault();

            var panel = Panels.Add(grid, layer.Handle);
            panel.Caption = layer.Name;

            int size;
            DockPanelState state;
            GetLayoutSpecs(AppConfig.Instance.TableEditorLayout, out size, out state);

            if (first != null)
            {
                panel.DockTo(first, state, size);
                panel.TabPosition = 0;
            }

            return new TablePanelInfo(grid, layer, panel);
        }

        /// <summary>
        /// Gets the size and docking state for a new docking panel.
        /// </summary>
        public void GetLayoutSpecs(TableEditorLayout layout, out int size, out DockPanelState state)
        {
            size = 0;
            state = DockPanelState.None;

            switch (layout)
            {
                case TableEditorLayout.Tabbed:
                    state = DockPanelState.Tabbed;
                    break;
                case TableEditorLayout.Horizontal:
                    state = DockPanelState.Right;
                    size = DockingClientSize.Width / _panels.Count();
                    break;
                case TableEditorLayout.Vertical:
                    state = DockPanelState.Bottom;
                    size = DockingClientSize.Height / _panels.Count();
                    break;
            }
        }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void Initialize(IAppContext context)
        {
            _context = context;

            UpdateView();
        }

        /// <summary>
        /// Performs necessary updates after a differnt dock panel was activated.
        /// </summary>
        public void OnActivateDockingPanel()
        {
            UpdateEditingIcon();
        }

        /// <summary>
        ///     Completely reloads the datasource applying all pending changes.
        /// </summary>
        public void UpdateDatasource()
        {
            var grid = ActiveGrid;
            if (grid != null)
            {
                grid.TableSource = grid.TableSource;
            }

            UpdateView();
        }

        /// <summary>
        /// Updates a caption text of the specified panel.
        /// </summary>
        public void UpdatePanelCaption(int layerHandle)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);
            if (layer == null)
            {
                return;
            }

            var msg = layer.Name;

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

        /// <summary>
        /// Updates the menus and invalidates the currently active grid.
        /// </summary>
        public void UpdateView()
        {
            var hasPanels = Panels.Any();

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

        #endregion

        #region Methods

        private TableEditorGrid CreateGrid()
        {
            var grid = new TableEditorGrid { RowManager = new RowManager() };
            grid.DoubleBuffered(true);
            grid.CurrentCellBorderColor = Color.LightGreen;
            Controls.Add(grid);
            return grid;
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

        private void OnMenuOpening()
        {
            DisableMenus();

            UpdateMenus();
        }

        private void UpdateEditingIcon()
        {
            var fs = ActiveFeatureSet;
            if (fs == null)
            {
                return;
            }

            var editing = fs.Table.EditMode;

            var img = editing ? Resources.icon_save1 : Resources.icon_layer_edit;

            toolEdit.Image = img;
        }

        private void UpdateMenus()
        {
            var fs = ActiveFeatureSet;
            if (fs == null)
            {
                return;
            }

            var editing = fs.Table.EditMode;

            mnuStartEdit.Enabled = !editing;
            mnuSaveChanges.Enabled = editing;

            mnuReloadTable.Enabled = true;
            mnuShowAliases.Enabled = true;
            mnuShowAllFields.Enabled = true;
            mnuShowAliases.Checked = AppConfig.Instance.TableEditorShowAliases;

            mnuAddField.Enabled = editing;
            mnuRemoveFields.Enabled = editing;
            mnuRemoveField.Enabled = editing;
            mnuUpdateMeasurements.Enabled = editing;
            mnuCopyShapeIDs.Enabled = editing;
            mnuGenerateOrUpdateShapeID.Enabled = editing;
            mnuImportExtData.Enabled = editing;
            mnuImportFieldDefinitions.Enabled = editing;
            mnuZoomToEdited.Enabled = editing;
            mnuReplace.Enabled = editing;

            var hasSelection = fs.NumSelected > 0;
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
            mnuLayoutHorizontal.Checked = layout == TableEditorLayout.Horizontal;
            mnuLayoutVertical.Checked = layout == TableEditorLayout.Vertical;
            mnuLayoutTabbed.Checked = layout == TableEditorLayout.Tabbed;
        }

        private void contextMenuStripEx1_Opening(object sender, CancelEventArgs e)
        {
            var fs = ActiveFeatureSet;
            if (fs == null)
            {
                return;
            }

            var editing = fs.Table.EditMode;
            mnuRemoveField.Enabled = editing;
            mnuCalculateField.Enabled = editing;
        }

        #endregion
    }

    public class TableEditorViewBase : MapWindowView<ILayer>
    {
    }
}