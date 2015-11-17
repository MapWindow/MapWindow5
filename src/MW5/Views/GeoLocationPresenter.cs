// -------------------------------------------------------------------------------------------
// <copyright file="GeoLocationPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Views.Abstract;

namespace MW5.Views
{
    internal class GeoLocationPresenter : BasePresenter<IGeoLocationView>
    {
        private readonly IAppContext _context;
        private readonly IGeoLocationService _geolocationService;

        public GeoLocationPresenter(IGeoLocationView view, IAppContext context, IGeoLocationService geolocationService)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (geolocationService == null) throw new ArgumentNullException("geolocationService");
            _context = context;
            _geolocationService = geolocationService;

            View.Search += () => ViewOkClicked();
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            if (View.UseGeoLocation)
            {
                FindLocation();
            }
            else
            {
                var extents = View.KnownExtents;
                if (extents != Api.Enums.KnownExtents.None)
                {
                    _context.Map.KnownExtents = View.KnownExtents;    
                }
            }

            // we don't want to close it after something is found
            return false;
        }

        private void FindLocation()
        {
            if (string.IsNullOrWhiteSpace(View.LocationQuery))
            {
                MessageService.Current.Info("Enter the name of location.");
                return;
            }

            string location = View.LocationQuery;

            View.StartWait();

            Task<IEnvelope>.Factory.StartNew(() => RunGeoLocation(location)).ContinueWith(t =>
                {
                    try
                    {
                        if (t.Result != null)
                        {
                            if (!_context.Map.SetGeographicExtents(t.Result))
                            {
                                MessageService.Current.Info("Failed to set geographic extents.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Info("Failed to find location.", ex);
                    }
                    finally
                    {
                        View.StopWait();
                        View.UpdateView();
                        View.SetInputFocus();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private IEnvelope RunGeoLocation(string locationQuery)
        {
            return _geolocationService.FindLocation(locationQuery);
        }
    }
}