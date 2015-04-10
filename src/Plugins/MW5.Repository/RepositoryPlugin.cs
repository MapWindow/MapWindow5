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

        public override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _repositoryPresenter = context.Container.GetInstance<RepositoryPresenter>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
        }

        public override void Terminate()
        {
            
        }
    }
}
