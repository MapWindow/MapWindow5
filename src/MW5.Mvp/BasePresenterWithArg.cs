using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Mvp
{
    public abstract class PresenterWithArg<TView, TCommand, TArg> : AbstractPresenter<TView, TCommand>, IPresenter<TArg>
        where TCommand : struct, IConvertible
        where TView : IView
    {
        protected PresenterWithArg(TView view)
            : base(view)
        {
        }

        public void Run(TArg argument)
        {
            View.ShowView();
        }
    }
}
