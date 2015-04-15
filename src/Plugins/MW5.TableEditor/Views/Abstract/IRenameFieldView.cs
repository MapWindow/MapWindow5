using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IRenameFieldView : IView<IAttributeTable>
    {
        int FieldIndex { get; }
        string NewName { get; }
    }
}
