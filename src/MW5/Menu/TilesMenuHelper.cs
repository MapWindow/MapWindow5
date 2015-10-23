using System;
using System.ComponentModel;
using System.Linq;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Menu
{
    /// <summary>
    /// Generates menu items for tile providers and fires TileProviderSelected event when those items are selected.
    /// </summary>
    internal static class TilesMenuHelper
    {
        private const string NoTilesMenuItem = "No tiles";
        private const int EmptyProviderId = -1;

        public static event EventHandler<TileProviderArgs> TileProviderSelected;
        public static event EventHandler<TileProviderArgs> ChooseActiveProvider;

        public static void Init(IAppContext context, IDropDownMenuItem root)
        {
            var tiles = context.Map.Tiles;
            tiles.set_UseCache(CacheType.Disk, true);
            tiles.set_UseCache(CacheType.Ram, true);

            SetInsertPosition(context, root);

            AddEmptyProvider(root);

            AddDefaultProviders(root);
            
            root.Update();

            root.DropDownOpening += OnTilesDropDownOpening;
        }

        private static void SetInsertPosition(IAppContext context, IDropDownMenuItem root)
        {
            var menuItem = context.Menu.FindItem(MenuKeys.BingApiKey, PluginIdentity.Default);
            if (menuItem != null)
            {
                root.SubItems.InsertBefore = menuItem;
            }
        }

        private static void AddEmptyProvider(IDropDownMenuItem root)
        {
            var item = root.SubItems.AddButton(NoTilesMenuItem, PluginIdentity.Default);
            item.Tag = EmptyProviderId;
            item.ItemClicked += OnItemClick;
        }

        private static void AddDefaultProviders(IDropDownMenuItem root)
        {
            var list = new[]
            {
                TileProvider.OpenStreetMap, TileProvider.OpenTransportMap,
                TileProvider.OpenHumanitarianMap, TileProvider.OpenCycleMap,
                TileProvider.MapQuestAerial, TileProvider.BingMaps,
                TileProvider.BingHybrid, TileProvider.BingSatellite,
            };

            foreach (var p in list)
            {
                var item = root.SubItems.AddButton(p.EnumToString(), PluginIdentity.Default);
                item.Tag = p;
                item.ItemClicked += OnItemClick;
            }

            root.SubItems[1].BeginGroup = true;
        }

        private static void OnTilesDropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as IDropDownMenuItem;
            if (menu == null)
            {
                return;
            }

            foreach (var item in menu.SubItems.Where(item => !item.Skip))
            {
                item.Checked = false;
            }

            int providerId = FireChooseActiveProvider();

            Func<IMenuItem, bool> predicate =
                item => !item.Skip && item.Tag != null && ((int)item.Tag == providerId);

            var selectedItem = menu.SubItems.FirstOrDefault(predicate);
            if (selectedItem != null)
            {
                selectedItem.Checked = true;
            }
        }

        private static void OnItemClick(object sender, EventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null && item.Tag != null)
            {
                FireProviderSelected(item, (int)item.Tag);
            }
        }

        private static int FireChooseActiveProvider()
        {
            var handler = ChooseActiveProvider;
            if (handler != null)
            {
                var args = new TileProviderArgs(EmptyProviderId);
                handler(null, args);
                return args.ProviderId;
            }

            return EmptyProviderId;
        }

        private static bool FireProviderSelected(object item, int providerId)
        {
            var handler = TileProviderSelected;
            if (handler != null)
            {
                var args = new TileProviderArgs(providerId);
                handler(item, args);
                return args.Cancel;
            }

            return true;
        }
    }
}
