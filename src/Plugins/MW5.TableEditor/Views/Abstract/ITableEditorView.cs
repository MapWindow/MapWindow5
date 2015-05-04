using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface ITableEditorView : IComplexView<ILayer>
    {
        void UpdateDatasource();
        void SetDatasource(IFeatureSet fs);
        event Action SelectionChanged;
        void Hide();
    }
}
