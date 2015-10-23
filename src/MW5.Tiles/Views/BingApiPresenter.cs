using System;
using MW5.Api.Static;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    internal class BingApiPresenter: BasePresenter<IBingApiView>
    {
        private readonly IConfigService _configService;

        public BingApiPresenter(IBingApiView view, IConfigService configService)
            : base(view)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            _configService = configService;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            string key = View.Key;

            if (string.IsNullOrWhiteSpace(key))
            {
                MessageService.Current.Info("Bing maps key is empty.");
                return false;
            }

            if (!MapConfig.TestBingApiKey(key))
            {
                MessageService.Current.Warn("Failed to initialize Bing maps provider.");
                return false;
            }
            
            MapConfig.BingApiKey = key;
            _configService.Config.BingApiKey = key;

            return true;
        }
    }
}
