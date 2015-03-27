using System;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Editor
{
    public interface ITableEditorView: IComplexView
    {
        void SetDatasource(Shapefile sf);
        event Action SelectionChanged;
        void Hide();
    }
}
