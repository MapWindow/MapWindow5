using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views
{
    public interface IAddFieldView: IView
    {
        string FieldName { get; }
        int FieldWidth { get;  }
        int FieldPrecision { get; }
        AttributeType FieldType { get; }
        event Action OkClicked;
    }
}
