using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterStylePresenter: ComplexPresenter<IRasterStyleView, RasterCommand, ILayer>
    {
        public RasterStylePresenter(IRasterStyleView view) : base(view)
        {
        }

        public override void RunCommand(RasterCommand command)
        {
            switch (command)
            {
                
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }

        public override void Init(ILayer model)
        {
            
        }
    }
}
