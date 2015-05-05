using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class MeasuringPresenter:  BasePresenter<IMeasuringView, IMeasuringSettings>
    {
        private readonly IAppContext _context;

        public MeasuringPresenter(IAppContext context, IMeasuringView view) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override bool ViewOkClicked()
        {
            View.UiToModel();
            _context.Map.Redraw(RedrawType.SkipDataLayers);
            return true;
        }
    }
}
