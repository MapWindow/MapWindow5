using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Mvp
{
    public abstract class SubViewPresenter<TView, TCommand, TModel> : CommandDispatcher<TCommand>
        where TCommand : struct, IConvertible
        where TView: SubViewBase<TModel>
        where TModel: class
    {
        protected TModel Model;
        public TView View { get; private set; }

        protected SubViewPresenter(TView subView)
        {
            if (subView == null) throw new ArgumentNullException("subView");
            View = subView;
            WireUpMenus(subView);
        }

        public void Initialize(TModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            Model = model;
            View.Initialize(model);
        }
    }
}
