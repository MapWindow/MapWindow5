// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositionRoot.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The composition root.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MW5.Plugins.Mvp;
using MW5.Plugins.Toolbox.Services;
using MW5.Plugins.Toolbox.Views;
using MW5.Plugins.Toolbox.Views.Abstract;

namespace MW5.Plugins.Toolbox
{
    /// <summary>
    /// The composition root.
    /// </summary>
    internal static class CompositionRoot
    {
        /// <summary>
        /// Composing the container
        /// </summary>
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IImageRegistrationView, ImageRegistrationView>()
                     .RegisterService<ILeastSquaresSolver, GaussEliminationSolver>();
        }
    }
}