using System;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class TableEditorPresenter : ComplexPresenter<ITableEditorView, TableEditorCommand, ILayer>
    {
        private readonly IAppContext _context;
        private readonly RowManager _rowManager;
        private ILayer _layer;
        private Shapefile _shapefile;

        public TableEditorPresenter(IAppContext context, ITableEditorView view, RowManager rowManager) 
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (rowManager == null) throw new ArgumentNullException("rowManager");

            _context = context;
            _rowManager = rowManager;
            View.SelectionChanged += ViewSelectionChanged;
        }

        public bool ViewVisible
        {
            get { return View.Visible; }
        }

        public bool HasLayer(int layerHandle)
        {
            return ViewVisible && _layer.Handle == layerHandle;
        }

        public void UpdateSelection()
        {
            View.UpdateView();
        }

        public bool CheckAndSaveChanges(bool withCancel)
        {
            if (_shapefile.EditingTable)
            {
                string msg = "Save attribute table changes?";

                bool saveChanges;
                if (withCancel)
                {
                    var dialogResult = MessageService.Current.AskWithCancel(msg);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return false;
                    }
                    saveChanges = dialogResult == DialogResult.Yes;
                }
                else
                {
                    saveChanges = MessageService.Current.Ask(msg);
                }

                if (saveChanges)
                {
                    RunCommand(TableEditorCommand.SaveChanges);
                    return true;
                }
            }

            return true;
        }

        public override void Init(ILayer layer)
        {
            _layer = layer;

            var sf = _layer.FeatureSet.InternalObject as Shapefile;
            _shapefile = sf;

            View.SetDatasource(sf);
        }

        public override void RunCommand(TableEditorCommand command)
        {
            if (HandleSelection(command))
            {
                return;
            }

            if (HandleFields(command))
            {
                return;
            }

            switch (command)
            {
                case TableEditorCommand.StartEdit:
                    if (!_shapefile.Table.EditingTable)
                    {
                        _shapefile.Table.StartEditingTable();
                    }
                    View.UpdateView();
                    break;
                case TableEditorCommand.SaveChanges:
                    if (_shapefile.Table.EditingTable)
                    {
                        _shapefile.Table.StopEditingTable();
                    }
                    View.UpdateView();
                    break;
                case TableEditorCommand.Close:
                    _layer = null;
                    View.Hide();
                    break;
            }
        }

        private bool HandleFields(TableEditorCommand command)
        {
            switch (command)
            {
                case TableEditorCommand.CalculateField:
                    if (_context.Container.Run<CalculateFieldPresenter, IFeatureSet>(_layer.FeatureSet, ViewHandle))
                    {
                        View.UpdateDatasource();
                    }
                    return true;
                case TableEditorCommand.AddField:
                    if (_context.Container.Run<AddFieldPresenter, IAttributeTable>(_layer.FeatureSet.Table, ViewHandle))
                    {
                        View.UpdateDatasource();
                    }
                    return true;
                case TableEditorCommand.RemoveField:
                    if (_context.Container.Run<DeleteFieldsPresenter, IAttributeTable>(_layer.FeatureSet.Table, ViewHandle))
                    {
                        View.UpdateDatasource();
                    }
                    return true;
                case TableEditorCommand.RenameField:
                    if (_context.Container.Run<RenameFieldPresenter, IAttributeTable>(_layer.FeatureSet.Table, ViewHandle))
                    {
                        View.UpdateDatasource();
                    }
                    return true;
            }
            
            return false;
        }

        private bool HandleSelection(TableEditorCommand command)
        {
            switch (command)
            {
                case TableEditorCommand.ShowSelected:
                    if (_rowManager.Filtered)
                    {
                        _rowManager.ClearFilter();
                    }
                    else
                    {
                        _rowManager.FilterSelected(_shapefile);
                    }
                    View.UpdateView();
                    return true;

                case TableEditorCommand.ZoomToSelected:
                    _context.Map.ZoomToSelected(_layer.Handle);
                    return true;

                case TableEditorCommand.SelectAll:
                    _shapefile.SelectAll();
                    View.UpdateView();
                    _context.Map.Redraw();
                    _context.View.Update();
                    return true;

                case TableEditorCommand.ClearSelection:
                    _shapefile.SelectNone();
                    View.UpdateView();
                    _context.Map.Redraw();
                    _context.View.Update();
                    return true;

                case TableEditorCommand.InvertSelection:
                    _shapefile.InvertSelection();
                    View.UpdateView();
                    _context.Map.Redraw();
                    _context.View.Update();
                    return true;
            }
            return false;
        }

        private void ViewSelectionChanged()
        {
            _context.Map.Redraw();
            _context.View.Update();
        }

        public override bool ViewOkClicked()
        {
            if (CheckAndSaveChanges(true))
            {
                RunCommand(TableEditorCommand.Close);
            }
            return false;   // we actually want to hide and not to close the form
        }
    }
}
