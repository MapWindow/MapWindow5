using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.ImageRegistration.Views.Abstract
{
    interface IImageRegistrationView : IComplexView<ImageRegistrationModel>
    {
        void AddSourceImage(IImageSource image);

        void RemoveTransformedImage();

        void LoadTransformedImage();

        event Action RecalculationNeeded;
    }
}
