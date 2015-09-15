// -------------------------------------------------------------------------------------------
// <copyright file="CompositionRoot.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Gdal.Views;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Gdal
{
    /// <summary>
    /// The composition root.
    /// </summary>
    internal static class CompositionRoot
    {
        /// <summary>
        /// Composes the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<ITranslateRasterCustomView, TranslateRasterCustomView>()
                     .RegisterView<IGdalOptionsView, GdalOptionsView>()
                     .RegisterView<ITranslateRasterView, TranslateRasterView>();

        }
    }
}