using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Toolbox.Views.Abstract
{
    interface IImageRegistrationView : IComplexView<ImageRegistrationModel>
    {
        void AddSourceImage(IImageSource image);

        void RemoveTransformedImage();

        void LoadTransformedImage();

        event Action RecalculationNeeded;
    }
}
