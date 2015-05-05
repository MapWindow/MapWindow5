using System.Collections.Generic;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.ShapeEditor.Views.Abstract
{
    public interface IAttributeView: IView<AttributeViewModel>
    {
        void FocusInvalidTextBox(int fieldIndex);
        Dictionary<int, string> Values { get; }
    }
}
