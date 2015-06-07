using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IJoinsView: IView<IAttributeTable>, IMenuProvider
    {
        FieldJoin SelectedJoin { get; }
        event Action JoinDoubleClicked;
    }
}
