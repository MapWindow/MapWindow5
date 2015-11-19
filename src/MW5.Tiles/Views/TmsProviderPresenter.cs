using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Model;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    public class TmsProviderPresenter: BasePresenter<ITmsProviderView, TmsProvider>
    {
        public TmsProviderPresenter(ITmsProviderView view)
            : base(view)
        {
            View.ChooseProjection += OnChooseProjection;

        }

        private void OnChooseProjection()
        {
            MessageService.Current.Info("Not implemented");
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(View.ProviderName))
            {
                MessageService.Current.Info("The name of the provider is empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(View.Url))
            {
                MessageService.Current.Info("URL of the provider is empty.");
                return false;
            }

            if (View.MinZoom == -1 || View.MaxZoom == -1)
            {
                MessageService.Current.Info("Minimum or maximum zoom is not defined.");
                return false;
            }

            if (View.MinZoom > View.MaxZoom)
            {
                MessageService.Current.Info("Maximum zoom must be larger or equal than minimum.");
                return false;
            }

            if (View.MinLat > View.MaxLat || View.MinLng > View.MaxLng)
            {
                MessageService.Current.Info("Invalid bounding box. Minimum value is larger than maximum.");
            }

            if (View.Id < TmsProvider.MinId)
            {
                MessageService.Current.Info("Invalid provider ID. Only values larger than 1000 are accepted.");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            if (!Model.IsCustom) return true;
            
            if (!Validate())
            {
                return false;
            }

            Model.Id = View.Id;
            Model.Name = View.ProviderName;
            Model.Projection = View.Projection;
            Model.Url = View.Url;
            Model.MinZoom = View.MinZoom;
            Model.MaxZoom = View.MaxZoom;
            Model.Bounds = new Envelope(View.MinLng, View.MaxLng, View.MinLat, View.MaxLat);
            Model.UseBounds = View.UseBounds;
            Model.Description = View.Description;

            return true;
        }
    }
}
