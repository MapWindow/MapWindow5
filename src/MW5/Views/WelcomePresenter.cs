using System;

using MW5.Plugins.Enums;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class WelcomePresenter : BasePresenter<IWelcomeView, WelcomeViewModel>
    {
        private readonly ILayerService _layerService;
        private readonly IProjectService _projectService;

        public WelcomePresenter(IWelcomeView view, ILayerService layerService, IProjectService projectService) : base(view)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (projectService == null) throw new ArgumentNullException("projectService");
            _layerService = layerService;
            _projectService = projectService;

            view.GettingStartedClicked += () => PathHelper.OpenUrl("http://www.mapwindow.org/documentation/mapwindow5/getting-started.html");
            view.DocumentsClicked += () => PathHelper.OpenUrl("https://mapwindow5.codeplex.com/documentation");
            view.DonateClicked += () => PathHelper.OpenUrl("http://www.mapwindow.org/documentation/mapwindow5/support.html");
            view.LogoClicked += () => PathHelper.OpenUrl("http://mapwindow5.codeplex.com");
             
            view.OpenLayerClicked += OpenLayerClicked;
            view.OpenProjectClicked += OpenProjectClicked;
        }

        public override bool ViewOkClicked()
        {
            return true;
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
            
            if (View.ProjectId == -1)
            {
                // showing file open dialog:
                if (_projectService.Open())
                {
                    View.Close();
                }

                return;    // it was cancelled, let the user go on working with form
            }

            // recent project
            string path = Model.RecentProjects[View.ProjectId];
            _projectService.Open(path);

            View.Close();
        }
    }
}
