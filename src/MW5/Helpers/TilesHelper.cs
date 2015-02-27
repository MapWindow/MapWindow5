using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Helpers
{
    internal static class TilesHelper
    {
        private enum Commands
        {
            SetBingApiKey = -2,
        }

        public static void Init(IDropDownMenuItem root)
        {
            root.SubItems.Clear();

            var item = root.SubItems.AddButton("No tiles");
            item.Tag = -1;
            item.Click += item_Click;
            
            var list = new[]
            {
                TileProvider.OpenStreetMap, TileProvider.OpenTransportMap,
                TileProvider.OpenHumanitarianMap, TileProvider.OpenCycleMap,
                TileProvider.MapQuestAerial, TileProvider.BingMaps,
                TileProvider.BingHybrid, TileProvider.BingSatellite
            };

            foreach (var p in list)
            {
                item = root.SubItems.AddButton(p.ToString());
                item.Tag = (int) p;
                item.Click += item_Click;
            }

            root.SetGroupBegins(1, true);     // after No tiles

            //item = root.DropDownItems.Add("Set Bing Maps API key");
            //item.Click += item_Click;
            //item.Tag = Commands.SetBingApiKey;

            root.DropDownOpening += root_DropDownOpening;
            //App.Map.Tiles.DoCaching[CacheType.Disk] = true;
            //App.Map.Tiles.UseCache[CacheType.Disk] = true;
        }

        private static void root_DropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as ParentBarItem;
            if (menu == null)
            {
                return;
            }

            var items = menu.Items.OfType<BarItem>().ToList();
            foreach (var item in items)
            {
                item.Checked = false;
            }

            // TODO: check the right one
            //Func<ToolStripMenuItem, bool> predicate =
            //    item => item.Tag != null && ((TileProvider)item.Tag == App.Map.TileProvider);

            //var selectedItem = items.FirstOrDefault(predicate);
            //if (selectedItem != null)
            //{
            //    selectedItem.Checked = true;
            //}
        }

        private static void item_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
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
                //App.Map.TileProvider = (TileProvider)item.Tag;
                //App.Map.Redraw();
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
