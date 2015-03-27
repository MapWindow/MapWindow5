using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IRenameFieldView: IView
    {
        int FieldIndex { get; }
        string NewName { get; }
        void Init(IAttributeTable table);
    }
}
