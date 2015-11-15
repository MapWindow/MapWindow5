using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tiles.Views;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles
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
            container.RegisterView<ITmsProviderView, TmsProviderView>()
                     .RegisterView<IBingApiView, BingApiView>()
                     .RegisterView<IWmsServerView, WmsServerView>()
                     .RegisterView<IWmsCapabilitiesView, WmsCapabilitiesView>()
                     .RegisterView<IProvidersView, TmsListView>();
        }
    }
}
