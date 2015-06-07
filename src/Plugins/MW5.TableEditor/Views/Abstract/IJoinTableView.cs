using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views.Abstract
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
