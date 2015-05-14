using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    public abstract class SubViewBase<TModel> : UserControl
    {
        public TModel Model { get; private set; }

        public void Initialize(TModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            Model = model;

            var subView = this as ISubView;
            if (subView != null)
            {
                subView.Initialize();
            }
        }
    }
}
