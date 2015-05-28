using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class WelcomePresenter: BasePresenter<IWelcomeView, WelcomeViewModel>
    {
        private readonly ILayerService _layerService;
        private readonly IProjectService _projectService;

        public WelcomePresenter(IWelcomeView view, ILayerService layerService, IProjectService projectService) : base(view)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (projectService == null) throw new ArgumentNullException("projectService");
            _layerService = layerService;
            _projectService = projectService;

            view.GettingStartedClicked += () => PathHelper.OpenUrl("https://mapwindow5.codeplex.com/documentation");
            view.DocumentsClicked += () => PathHelper.OpenUrl("https://mapwindow5.codeplex.com/documentation");
            view.DonateClicked += () => PathHelper.OpenUrl("http://www.mapwindow.org/pages/donate.php");
            view.LogoClicked += () => PathHelper.OpenUrl("http://mapwindow5.codeplex.com");
             
            view.OpenLayerClicked += OpenLayerClicked;
            view.OpenProjectClicked += OpenProjectClicked;
        }

        private void OpenLayerClicked()
        {
            if (_layerService.AddLayer(DataSourceType.All))
            {
                View.Close();    
            }
        }

        private void OpenProjectClicked()
        {
            if (View.ProjectId >= Model.RecentProjects.Count)
            {
                MessageService.Current.Info("Invalid project reference.");
                return;
            }

            // showing dialog
            if (View.ProjectId == -1)
            {
                if (_projectService.Open())
                {
                    View.Close();
                    return;
                }

            }

            // recent project
            string path = Model.RecentProjects[View.ProjectId];
            _projectService.Open(path);

            View.Close();
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
