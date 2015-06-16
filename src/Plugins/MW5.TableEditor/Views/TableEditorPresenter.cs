// -------------------------------------------------------------------------------------------
// <copyright file="TableEditorPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    [HasRegions]
    internal class TableEditorPresenter : CommandDispatcher<ITableEditorView, TableEditorCommand>, IDockPanelPresenter
    {
        private readonly IAppContext _context;

        private readonly Dictionary<int, TablePanelInfo> _tables;

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

        public IFeatureSet FeatureSet
        {
            get { return View.ActiveFeatureSet; }
        }

        #endregion

        #region Public Methods

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
                return true; // nothing to save
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

        public void CloseTable(int layerHandle)
        {
            if (_tables.ContainsKey(layerHandle))
            {
                var info = _tables[layerHandle];

                View.Panels.Remove(info.Panel);
                _tables.Remove(layerHandle);

                if (info.FindReplace != null)
                {
                    info.FindReplace.View.ForceClose();
                }
            }

            View.UpdateView();
        }

        public Control GetInternalObject()
        {
            return View as Control;
        }

        public bool HasLayer(int layerHandle)
        {
            return _tables.ContainsKey(layerHandle);
        }

        public void OnViewSelectionChanged(int layerHandle)
        {
            UpdateSelection(layerHandle);

            _context.Map.Redraw();
            _context.View.Update();
        }

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
                case TableEditorCommand.FieldSortAsc:
                    MessageService.Current.Info("Not implemented");
                    break;
                case TableEditorCommand.FieldSortDesc:
                    MessageService.Current.Info("Not implemented");
                    break;
                case TableEditorCommand.FieldStats:
                    MessageService.Current.Info("Not implemented");
                    break;
                case TableEditorCommand.FieldHide:
                    MessageService.Current.Info("Not implemented");
                    break;
                case TableEditorCommand.FieldProperties:
                    MessageService.Current.Info("Not implemented");
                    break;
                case TableEditorCommand.UpdateMeasurements:
                    _context.Container.Run<UpdateMeasurementsPresenter, IAttributeTable>(table);
                    View.UpdateDatasource();
                    break;
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
                        var result = MessageService.Current.AskWithCancel(
                            "Do you want to save attribute table changes?");
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
                    // TODO: choose current selected field
                    var model = new FieldCalculatorModel(table, table.Fields[0]);
                    if (_context.Container.Run<FieldCalculatorPresenter, FieldCalculatorModel>(model))
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
                case TableEditorCommand.Find:
                    Find(false);
                    break;
                case TableEditorCommand.Replace:
                    Find(true);
                    break;
            }
        }

        public void UpdateSelection(int layerHandle)
        {
            var info = GetTableInfo(layerHandle);
            if (info == null) return;

            info.Grid.Invalidate();

            View.UpdatePanelCaption(layerHandle);
        }

        #endregion

        #region Methods

        private void CreateNewTable(ILegendLayer layer)
        {
            var info = View.CreateTablePanel(layer);
            _tables.Add(layer.Handle, info);
            info.Grid.SelectionChanged += (s, e) => OnViewSelectionChanged(layer.Handle);
        }

        private void Find(bool replace)
        {
            var info = GetTableInfo(View.ActiveLayerHandle);
            if (info == null) return;

            if (info.FindReplace != null && info.FindReplace.Model.Replace != replace)
            {
                info.FindReplace.View.Close();
                info.FindReplace = null;
            }

            if (info.FindReplace == null)
            {
                info.FindReplace = _context.Container.GetInstance<FindReplacePresenter>();
            }

            var model = new FindReplaceModel(info.Grid, info.Layer, replace);

            info.FindReplace.Run(model);
        }

        private string GetLayerKey(int layerHandle)
        {
            return layerHandle.ToString();
        }

        private TablePanelInfo GetTableInfo(int layerHandle)
        {
            TablePanelInfo info;
            _tables.TryGetValue(layerHandle, out info);

            return info;
        }

        private bool HandleLayout(TableEditorCommand command)
        {
            if (command != TableEditorCommand.LayoutHorizontal && command != TableEditorCommand.LayoutVertical
                && command != TableEditorCommand.LayoutTabbed)
            {
                return false;
            }

            SaveLayoutOption(command);

            int size;
            DockPanelState state;

            View.GetLayoutSpecs(AppConfig.Instance.TableEditorLayout, out size, out state);

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

        private DialogResult PromptSaveChanges(bool withCancel, string layerName)
        {
            var msg = "Save changes of the attribute table for the layer: " + layerName + "?";

            if (withCancel)
            {
                return MessageService.Current.AskWithCancel(msg);
            }

            return MessageService.Current.Ask(msg) ? DialogResult.Yes : DialogResult.No;
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

        #endregion
    }
}