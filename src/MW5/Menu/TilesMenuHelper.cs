using System;
using System.Linq;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Menu
{
    // I leave it static, there is no need to inject it anywhere
    internal static class TilesMenuHelper
    {
        private const string NO_TILES_MENU_ITEM_CAPTION = "No tiles";

        private enum Commands
        {
            SetBingApiKey = -2,
        }

        private static IMuteMap _map;

        public static void Init(IMuteMap map, IDropDownMenuItem root)
        {
            _map = map;
            
            root.SubItems.Clear();

            var item = root.SubItems.AddButton(NO_TILES_MENU_ITEM_CAPTION, PluginIdentity.Default);
            item.Tag = -1;
            item.AttachClickEventHandler(item_Click);
            
            var list = new[]
            {
                TileProvider.OpenStreetMap, TileProvider.OpenTransportMap,
                TileProvider.OpenHumanitarianMap, TileProvider.OpenCycleMap,
                TileProvider.MapQuestAerial, TileProvider.BingMaps,
                TileProvider.BingHybrid, TileProvider.BingSatellite
            };

            foreach (var p in list)
            {
                item = root.SubItems.AddButton(EnumHelper.EnumToString(p), PluginIdentity.Default );
                item.Tag = p;
                item.AttachClickEventHandler(item_Click);
            }

            root.SubItems[1].BeginGroup = true;
            root.Update();

            //item = root.DropDownItems.Add("Set Bing Maps API key");
            //item.Click += item_Click;
            //item.Tag = Commands.SetBingApiKey;

            root.DropDownOpening += root_DropDownOpening;
            _map.Tiles.set_IsCaching(CacheType.Disk, true);
            _map.Tiles.set_UseCache(CacheType.Disk, true);
        }

        private static void root_DropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as IDropDownMenuItem;
            if (menu == null)
            {
                return;
            }

            foreach (var item in menu.SubItems)
            {
                item.Checked = false;
            }

            Func<IMenuItem, bool> predicate =
                item => item.Tag != null && ((TileProvider)item.Tag == _map.TileProvider);

            var selectedItem = menu.SubItems.FirstOrDefault(predicate);
            if (selectedItem != null)
            {
                selectedItem.Checked = true;
            }
        }

        private static void item_Click(object sender, EventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null && item.Tag != null)
            {
                if ((int)item.Tag == (int)Commands.SetBingApiKey)
                {
                    SetBingApiKey();
                    return;
                }

                TileProvider provider = (TileProvider)item.Tag;
                switch (provider)
                {
                    case TileProvider.BingSatellite:
                    case TileProvider.BingMaps:
                    case TileProvider.BingHybrid:
                        //var gs = new GlobalSettings();
                        //if (string.IsNullOrWhiteSpace(gs.BingApiKey))
                        //{
                        //    if (!string.IsNullOrWhiteSpace(AppSettings.Instance.BingApiKey))
                        //    {
                        //        gs.BingApiKey = AppSettings.Instance.BingApiKey;
                        //    }
                        //    else
                        //    {
                        //        if (!SetBingApiKey()) return;
                        //    }
                        //}
                        break;
                }
                _map.TileProvider = (TileProvider)item.Tag;
                _map.Redraw();
            }
        }

        private static bool SetBingApiKey()
        {
            //using (var form = new BingApiKeyForm())
            //{
            //    if (form.ShowDialog(MainForm.Instance) != DialogResult.OK)
            //        return false;
            //}
            return true;
        }
    }
}
