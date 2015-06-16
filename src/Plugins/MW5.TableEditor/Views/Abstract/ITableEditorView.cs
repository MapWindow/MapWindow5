using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    internal interface ITableEditorView : IMenuProvider
    {
        TablePanelCollection Panels { get; }
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
        TablePanelInfo CreateNewTable(ILegendLayer layer);
        void GetLayoutSpecs(TableEditorLayout layout, out int size, out DockPanelState state);
    }
}
