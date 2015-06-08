using System;
using System.Drawing;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface ITableEditorView : IMenuProvider
    {
        TablePanelCollection Panels { get; }
        Size DockingClientSize { get; }
        IFeatureSet ActiveFeatureSet { get; }
        int ActiveLayerHandle { get; }
        TableEditorGrid ActiveGrid { get; }
        void Initialize(IAppContext context);
        TableEditorGrid CreateGrid();
        void UpdateDatasource();
        void UpdateView();
        void ClearCurrentCell();
        void UpdatePanelCaption(int layerHandle);
        void OnActivateDockingPanel();
    }
}
