using System.Collections.Generic;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IDeleteFieldsView : IView<IAttributeTable>
    {
        IEnumerable<int> FieldsToRemove { get; }
    }
}
