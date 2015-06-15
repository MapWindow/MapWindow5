using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class FieldCalculatorPresenter: BasePresenter<IFieldCalculatorView, FieldCalculatorModel>
    {
        public FieldCalculatorPresenter(IFieldCalculatorView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
