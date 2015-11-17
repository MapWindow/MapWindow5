using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.Helpers;
using MW5.Properties;
using MW5.Shared;
using MW5.UI.Helpers;
using MW5.Views;

namespace MW5.Menu
{
    public class StatusBarListener
    {
        private readonly IAppContext _context;

        public StatusBarListener(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            
            _context = context;

            InitStatusBar();

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.StatusItemClicked += PluginManager_MenuItemClicked;
            }

            AddMapEventHandlers();
        }

        private void AddMapEventHandlers()
        {
            var map = _context.Map as IMap;
            if (map == null)
            {
                throw new InvalidCastException("Map must implement IMap interface");
            }

            map.ProjectionChanged += MapProjectionChanged;

            map.ExtentsChanged += map_ExtentsChanged;
        }
        
        private void InitStatusBar()
        {
            var bar = _context.StatusBar;

            var dropDown = bar.Items.AddSplitButton("Not defined", StatusBarKeys.ProjectionDropDown, Identity);
            dropDown.Icon = new MenuIcon(Resources.icon_crs_change);

            var items = dropDown.SubItems;
            items.AddButton("Choose projection", StatusBarKeys.ChooseProjection, Identity);
            items.AddButton("Projection properties", StatusBarKeys.ProjectionProperties, Identity);
            items.AddButton("Settings", StatusBarKeys.ProjectionConfig, Identity).BeginGroup = true; ;

            dropDown.Update();

            bar.Items.AddLabel("Map units: ", StatusBarKeys.MapUnits, Identity).BeginGroup = true;
            bar.Items.AddLabel("Selected: ", StatusBarKeys.SelectedCount, Identity).BeginGroup = true;
            

            bar.AlignNewItemsRight = true;

            bar.Items.AddLabel("", StatusBarKeys.MapScale, Identity);
            bar.Items.AddLabel("Tile provider", StatusBarKeys.TileProvider, Identity).BeginGroup = true;
            
            var progressMsg = bar.Items.AddLabel("Progress", StatusBarKeys.ProgressMsg, Identity);
            progressMsg.BeginGroup = true;
            progressMsg.Visible = false;

            bar.Items.AddProgressBar(StatusBarKeys.ProgressBar, Identity).Visible = false;

            bar.Update();
        }

        private void PluginManager_MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            var menuItem = sender as IMenuItem;
            if (menuItem == null)
            {
                throw new InvalidCastException("Invalid type of menu item. IMenuItem interface is expected");
            }

            switch (e.ItemKey)
            {
                case StatusBarKeys.ProjectionDropDown:
                    if (_context.Map.Projection.IsEmpty)
                    {
                        _context.ChangeProjection();
                    }
                    else
                    {
                        _context.ShowMapProjectionProperties();
                    }
                    break;
                case StatusBarKeys.ProjectionProperties:
                    _context.ShowMapProjectionProperties();
                    break;
                case StatusBarKeys.ChooseProjection:
                    _context.ChangeProjection();
                    break;
                case StatusBarKeys.ProjectionConfig:
                    var model = _context.Container.GetInstance<ConfigViewModel>();
                    model.UseSelectedPage = true;
                    model.SelectedPage = ConfigPageType.Projections;
                    _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    break;
                default:
                    MessageService.Current.Info("There is no handler for the item: " + e.ItemKey);
                    break;
            }
        }

        private PluginIdentity Identity
        {
            get { return PluginIdentity.Default; }
        }

        protected IMenuItem FindItem(string itemKey)
        {
            return _context.StatusBar.FindItem(itemKey, Identity);
        }

        public void Update()
        {
            var bar = _context.StatusBar;

            UpdateSelectionMessage();

            var statusUnits = bar.FindItem(StatusBarKeys.MapUnits, Identity);
            statusUnits.Text = "Units: " + _context.Map.MapUnits.EnumToString().ToLower();

            UpdateTmsProvider();
        }

        private void UpdateTmsProvider()
        {
            string msg = "Base Layer: ";

            if (_context.Map.TileProvider == Api.Enums.TileProvider.ProviderCustom)
            {
                var tiles = _context.Map.Tiles;
                var provider = tiles.Providers.FirstOrDefault(p => p.Id == tiles.ProviderId);
                msg += provider != null ? provider.Name : "Not defined";
            }
            else
            {
                msg += _context.Map.TileProvider.EnumToString();
            }

            var statusProvider = _context.StatusBar.FindItem(StatusBarKeys.TileProvider, Identity);
            statusProvider.Text = msg;
        }

        private void UpdateSelectionMessage()
        {
            var statusSelected = _context.StatusBar.FindItem(StatusBarKeys.SelectedCount, Identity);

            if (_context.Map.Layers.Current == null)
            {
                statusSelected.Text = "No selected layer";
            }
            else
            {
                var fs = _context.Map.SelectedFeatureSet;
                if (fs != null)
                {
                    statusSelected.Text = string.Format("Selected: {0} / {1}", fs.NumSelected, fs.Features.Count);

                }
                else
                {
                    var img = _context.Map.SelectedImage;
                    if (img != null)
                    {
                        statusSelected.Text = "Selected layer is raster";
                    }
                }
            }
        }

        private void MapProjectionChanged(object sender, EventArgs e)
        {
            var item = _context.StatusBar.FindItem(StatusBarKeys.ProjectionDropDown, Identity);
            var p = _context.Map.Projection;
            item.Text = !p.IsEmpty ? p.Name : "Not defined";
        }

        private void map_ExtentsChanged(object sender, EventArgs e)
        {
            var item = _context.StatusBar.FindItem(StatusBarKeys.MapScale, Identity);
            item.Text = string.Format("1:{0}", Convert.ToInt32(_context.Map.CurrentScale));
        }
    }
}
