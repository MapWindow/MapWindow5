using MW5.Plugins.ImageRegistration.Services;
using MW5.Plugins.ImageRegistration.Views;
using MW5.Plugins.ImageRegistration.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.ImageRegistration
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IImageRegistrationView, ImageRegistrationView>()
                     .RegisterService<ILeastSquaresSolver, GaussEliminationSolver>();
        }
    }
}
