using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Projections.Services;
using MW5.Projections.Services.Abstract;
using MW5.Projections.Views;
using MW5.Projections.Views.Abstract;

namespace MW5.Projections
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IProjectionDatabase, ProjectionDatabase>()
                .RegisterService<IReprojectingService, ReprojectingService>()
                .RegisterService<IProjectionMismatchService, ProjectionMismatchService>()
                .RegisterView<IProjectionMismatchView, ProjectionMismatchView>()
                .RegisterView<IProjectionInfoView, ProjectionInfoView>();
        }
    }
}
