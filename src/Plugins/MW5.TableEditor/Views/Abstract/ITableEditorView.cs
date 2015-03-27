using System;
using MapWinGIS;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface ITableEditorView: IComplexView
    {
        void SetDatasource(Shapefile sf);
        event Action SelectionChanged;
        void Hide();
    }
}
