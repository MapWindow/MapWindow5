using System;
using System.Collections.Generic;
using MW5.Attributes.Model;
using MW5.Plugins.Mvp;

namespace MW5.Attributes.Views.Abstract
{
    public interface IJoinTableView : IView<JoinViewModel>
    {
        event Action OpenClicked;
        event Action TryJoin;
        FieldWrapper FieldFrom { get; }
        FieldWrapper FieldTo { get; }
        IEnumerable<FieldWrapper> SelectedFields { get; }
        void SetRowCount(int rowCount, int joinRowCount);
        void SetDatasource();
    }
}
