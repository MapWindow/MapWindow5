using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    internal interface IRecalculateFieldsView: IView<IAttributeTable>
    {
        IEnumerable<RecalculateFieldWrapper> Fields { get; }

        void UpdateField(RecalculateFieldWrapper wrapper);
    }
}
