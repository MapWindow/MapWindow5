using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Repository.Services;
using MW5.Plugins.Repository.Views;

namespace MW5.Plugins.Repository
{
    [MapWindowPlugin()]
    public class RepositoryPlugin: BasePlugin
    {
        private RepositoryPresenter _repositoryPresenter;
        private DockPanelService _dockPanelService;
        private LegendListener _legendListener;

        public override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _repositoryPresenter = context.Container.GetSingleton<RepositoryPresenter>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
            _legendListener = context.Container.GetSingleton<LegendListener>();
        }

        public override void Terminate()
        {
            
        }
    }
}
