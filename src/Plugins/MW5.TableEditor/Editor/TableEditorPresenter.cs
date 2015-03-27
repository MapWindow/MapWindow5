using System;
using System.Diagnostics;
using System.Linq;
using MapWinGIS;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views;

namespace MW5.Plugins.TableEditor.Editor
{
    public class TableEditorPresenter : ComplexPresenter<ITableEditorView, TableEditorCommand, ILayer>
    {
        private readonly IAppContext _context;
        private readonly ITableEditorView _view;
        private readonly RowManager _rowManager;
        private readonly IMessageService _messageService;
        private ILayer _layer;
        private Shapefile _shapefile;

        public TableEditorPresenter(IAppContext context, ITableEditorView view, RowManager rowManager, IMessageService messageService) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (view == null) throw new ArgumentNullException("view");
            if (rowManager == null) throw new ArgumentNullException("rowManager");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _context = context;
            _view = view;
            _rowManager = rowManager;
            _messageService = messageService;
            _view.SelectionChanged += ViewSelectionChanged;
        }

        public bool ViewVisible
        {
            get { return _view.Visible; }
        }

        public bool HasLayer(int layerHandle)
        {
            return ViewVisible && _layer.Handle == layerHandle;
        }

        public bool HasChanges
        {
            get { return false; }
        }

        private ILayer Layer
        {
            get { return _layer; }
            set
            {
                if (value == null)
                {
                    _layer = null;
                    return;
                }

                if (_layer != null && _layer.Handle == value.Handle)
                {
                    return;     // it's the same layer
                }
                
                _layer = value;
                
                var sf = _layer.FeatureSet.InternalObject as Shapefile;
                _shapefile = sf;

                _view.SetDatasource(sf);
            }
        }

        public void UpdateSelection()
        {
            _view.UpdateView();
        }

        public bool CheckAndSaveChanges()
        {
            return true; 
        }

        public override bool Run(ILayer layer, bool modal = true)
        {
            Layer = layer;
            _view.ShowView(modal);
            return true;
        }

        public override void RunCommand(TableEditorCommand command)
        {
            switch (command)
            {
                case TableEditorCommand.StartEdit:
                    if (!_shapefile.Table.EditingTable)
                    {
                        _shapefile.Table.StartEditingTable();
                    }
                    _view.UpdateView();
                    break;
                case TableEditorCommand.AddField:
                    var p = _context.Container.GetInstance<AddFieldPresenter>();
                    if (p.Run(_layer.FeatureSet))
                    {
                        _view.SetDatasource(_shapefile);
                    }
                    break;
                case TableEditorCommand.RemoveField:
                    break;
                case TableEditorCommand.RenameField:
                    break;
                case TableEditorCommand.Close:
                    Layer = null;
                    _view.Hide();
                    break;
                case TableEditorCommand.SaveChanges:
                    _messageService.Info("Not implemented");
                    break;
                case TableEditorCommand.ShowSelected:
                    if (_rowManager.Filtered)
                    {
                        _rowManager.ClearFilter();
                    }
                    else
                    {
                        _rowManager.FilterSelected(_shapefile);    
                    }
                    _view.UpdateView();
                    break;
                case TableEditorCommand.ZoomToSelected:
                    _context.Map.ZoomToSelected(_layer.Handle);
                    break;

            }
        }

        protected override void CommandNotFound(string itemName)
        {
            _messageService.Info("No handler found for item: " + itemName);
        }

        private void ViewSelectionChanged()
        {
            _context.Map.Redraw();
            _context.View.Update();
        }
    }
}
