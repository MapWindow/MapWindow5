using MW5.Api;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IAddFieldView: IView
    {
        string FieldName { get; }
        int FieldWidth { get;  }
        int FieldPrecision { get; }
        AttributeType FieldType { get; }
    }
}
