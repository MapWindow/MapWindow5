// -------------------------------------------------------------------------------------------
// <copyright file="ITableEditorView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

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
        int ActiveColumnIndex { get; }

        IFeatureSet ActiveFeatureSet { get; }

        TableEditorGrid ActiveGrid { get; }

        int ActiveLayerHandle { get; }

        TablePanelCollection Panels { get; }

        void ClearCurrentCell();

        TablePanelInfo CreateTablePanel(ILegendLayer layer);

        void GetLayoutSpecs(TableEditorLayout layout, out int size, out DockPanelState state);

        void Initialize(IAppContext context);

        void OnActivateDockingPanel();

        void UpdateDatasource();

        void UpdatePanelCaption(int layerHandle);

        void UpdateView();

        void OnSelectionChanged();
    }
}