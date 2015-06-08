using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class TableEditorPresenter : CommandDispatcher<ITableEditorView, TableEditorCommand>, IDockPanelPresenter
    {
        private readonly Dictionary<int, TablePanelInfo> _tables;
        private readonly IAppContext _context;

        public TableEditorPresenter(IAppContext context, ITableEditorView view) 
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            _tables = new Dictionary<int, TablePanelInfo>();

            View.Initialize(context);
            
            View.Panels.BeforePanelClosed += (s, e) => CloseTable(e.LayerHandle);
            View.Panels.PanelActivated += (s, e) => View.OnActivateDockingPanel();
        }

        #region Properties

        public IFeatureSet FeatureSet
        {
            get { return View.ActiveFeatureSet; }
        }

        public IAttributeTable ActiveTable
        {
            get
            {
                var fs = FeatureSet;
                
                if (fs == null)
                {
                    return null;
                }

                return fs.Table;
            }
        }

        #endregion

        #region Public methods

        public void OpenTable(ILegendLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            if (_tables.ContainsKey(layer.Handle))
            {
                View.Panels.ActivatePanel(layer.Handle);
                return;
            }

            CreateNewTable(layer);

            View.UpdateView();
        }

        public bool HasLayer(int layerHandle)
        {
            return _tables.ContainsKey(layerHandle);
        }

        public void UpdateSelection(int layerHandle)
        {
            var info = GetTableInfo(layerHandle);
            if (info == null) return;

            info.Grid.Invalidate();

            View.UpdatePanelCaption(layerHandle);
        }

        public bool CheckAndSaveChanges(int layerHandle, bool withCancel)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);

            if (layer == null)
            {
                return true;
            }

            var fs = layer.FeatureSet;
            
            if (fs == null || !fs.EditingTable)
            {
                return true;    // nothing to save
            }

            var result = PromptSaveChanges(withCancel, layer.Name);

            switch (result)
            {
                case DialogResult.Cancel:
                    return false;
                case DialogResult.Yes:
                    RunCommand(TableEditorCommand.SaveChanges);
                    break;
            }

            return true;
        }

        public Control GetInternalObject()
        {
            return View as Control;
        }

        #endregion

        #region Handling commands

        public override void RunCommand(TableEditorCommand command)
        {
            if (HandleLayout(command))
            {
                return;
            }

            var table = ActiveTable;
            if (table == null)
            {
                return;
            }

            switch (command)
            {
                case TableEditorCommand.Join:
                    _context.Container.Run<JoinsPresenter, IAttributeTable>(table);
                    View.UpdateDatasource();
                    break;
                case TableEditorCommand.StartEdit:
                    if (!table.EditMode)
                    {
                        table.StartEditing();

                        var grid = View.ActiveGrid;
                        if (grid != null)
                        {
                            grid.ReadOnly = !table.EditMode;
                        }
                    }

                    View.UpdateView();
                    break;
                case TableEditorCommand.SaveChanges:
                    if (table.EditMode)
                    {
                        var result = MessageService.Current.AskWithCancel("Do you want to save attribute table changes?");
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        table.StopEditing(result == DialogResult.Yes);

                        var grid = View.ActiveGrid;
                        if (grid != null)
                        {
                            grid.ReadOnly = !table.EditMode;
                        }
                    }

                    View.UpdateView();
                    break;
                case TableEditorCommand.CalculateField:
                    if (_context.Container.Run<CalculateFieldPresenter, IFeatureSet>(FeatureSet))
                    {
                        View.UpdateDatasource();
                    }
                    break;
                case TableEditorCommand.AddField:
                    if (_context.Container.Run<AddFieldPresenter, IAttributeTable>(table))
                    {
                        View.UpdateDatasource();
                    }
                    break;
                case TableEditorCommand.RemoveField:
                    if (_context.Container.Run<DeleteFieldsPresenter, IAttributeTable>(table))
                    {
                        View.UpdateDatasource();
                    }
                    break;
                case TableEditorCommand.RenameField:
                    if (_context.Container.Run<RenameFieldPresenter, IAttributeTable>(table))
                    {
                        View.UpdateDatasource();
                    }
                    break;
                case TableEditorCommand.ShowSelected:
                    ShowSelected();
                    break;

                case TableEditorCommand.ZoomToSelected:
                    _context.Map.ZoomToSelected(View.ActiveLayerHandle);
                    break;

                case TableEditorCommand.SelectAll:
                    FeatureSet.SelectAll();
                    OnViewSelectionChanged(View.ActiveLayerHandle);
                    break;

                case TableEditorCommand.ClearSelection:
                    FeatureSet.ClearSelection();
                    OnViewSelectionChanged(View.ActiveLayerHandle);
                    break;

                case TableEditorCommand.InvertSelection:
                    FeatureSet.InvertSelection();
                    OnViewSelectionChanged(View.ActiveLayerHandle);
                    break;
            }
        }

        private void ShowSelected()
        {
            var grid = View.ActiveGrid;
            if (grid == null)
            {
                return;
            }

            var manager = grid.RowManager;

            if (manager.Filtered)
            {
                manager.ClearFilter();
            }
            else
            {
                View.ClearCurrentCell();
                manager.FilterSelected(FeatureSet);
            }

            grid.RowCount = 0;
            grid.RowCount = manager.Count;
            grid.Invalidate();

            View.UpdateView();
        }

        private bool HandleLayout(TableEditorCommand command)
        {
            if (command != TableEditorCommand.LayoutHorizontal &&
                command != TableEditorCommand.LayoutVertical &&
                command != TableEditorCommand.LayoutTabbed)
            {
                return false;
            }

            SaveLayoutOption(command);

            int size;
            DockPanelState state;

            GetLayoutSpecs(AppConfig.Instance.TableEditorLayout, out size, out state);

            var list = View.Panels.ToList().OrderBy(p => p.Caption);
            if (list.Count() < 2)
            {
                return true;
            }

            var panel = list.FirstOrDefault();

            foreach (var p in list.Where(p => p != panel))
            {
                p.DockTo(panel, state, size);
            }

            return true;
        }

        private void SaveLayoutOption(TableEditorCommand command)
        {
            switch (command)
            {
                case TableEditorCommand.LayoutTabbed:
                    AppConfig.Instance.TableEditorLayout = TableEditorLayout.Tabbed;
                    break;
                case TableEditorCommand.LayoutHorizontal:
                    AppConfig.Instance.TableEditorLayout = TableEditorLayout.Horizontal;
                    break;
                case TableEditorCommand.LayoutVertical:
                    AppConfig.Instance.TableEditorLayout = TableEditorLayout.Vertical;
                    break;
            }
        }

        #endregion

        #region Private methods

        private string GetLayerKey(int layerHandle)
        {
            return layerHandle.ToString();
        }

        private void CreateNewTable(ILegendLayer layer)
        {
            var grid = View.CreateGrid();

            grid.TableSource = layer.FeatureSet;
            grid.SelectionChanged += (s, e) => OnViewSelectionChanged(layer.Handle);

            var first = View.Panels.FirstOrDefault();

            var panel = View.Panels.Add(grid, GetLayerKey(layer.Handle));
            panel.Caption = layer.Name;

            int size;
            DockPanelState state;
            GetLayoutSpecs(AppConfig.Instance.TableEditorLayout, out size,  out state);

            if (first != null)
            {
                panel.DockTo(first, state, size);
                panel.TabPosition = 0;
            }

            var info = new TablePanelInfo(grid, layer, panel);
            _tables.Add(layer.Handle, info);
        }

        public void CloseTable(int layerHandle)
        {
            if (_tables.ContainsKey(layerHandle))
            {
                View.Panels.Remove(_tables[layerHandle].Panel);
                _tables.Remove(layerHandle);
            }

            View.UpdateView();
        }

        private void OnViewSelectionChanged(int layerHandle)
        {
            UpdateSelection(layerHandle);

            _context.Map.Redraw();
            _context.View.Update();
        }

        private DialogResult PromptSaveChanges(bool withCancel, string layerName)
        {
            string msg = "Save changes of the attribute table for the layer: " + layerName + "?";

            if (withCancel)
            {
                return MessageService.Current.AskWithCancel(msg);
            }

            return MessageService.Current.Ask(msg) ? DialogResult.Yes : DialogResult.No;
        }

        private TablePanelInfo GetTableInfo(int layerHandle)
        {
            TablePanelInfo info;
            _tables.TryGetValue(layerHandle, out info);

            return info;
        }

        private void GetLayoutSpecs(TableEditorLayout layout, out int size, out DockPanelState state)
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
                    size = View.DockingClientSize.Width / View.Panels.Count();
                    break;
                case TableEditorLayout.Vertical:
                    state = DockPanelState.Bottom;
                    size = View.DockingClientSize.Height / View.Panels.Count();
                    break;
            }
        }

        #endregion
    }
}
