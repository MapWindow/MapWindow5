using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Helpers
{
    internal static class TilesHelper
    {
        private enum Commands
        {
            SetBingApiKey = -2,
        }

        public static void Init(ParentBarItem root)
        {
            root.Items.Clear();

            var item = new BarItem("No tiles", item_Click) { Tag = -1 };
            root.Items.Add(item);
            
            var list = new[]
            {
                TileProvider.OpenStreetMap, TileProvider.OpenTransportMap,
                TileProvider.OpenHumanitarianMap, TileProvider.OpenCycleMap,
                TileProvider.MapQuestAerial, TileProvider.BingMaps,
                TileProvider.BingHybrid, TileProvider.BingSatellite
            };

            bool beginGroup = true;

            foreach (var p in list)
            {
                item = new BarItem(p.ToString(), item_Click) { Tag = (int)p };
                root.Items.Add(item);

                if (beginGroup)
                {
                    root.BeginGroupAt(item);
                    beginGroup = false;
                }
            }

            //item = root.DropDownItems.Add("Set Bing Maps API key");
            //item.Click += item_Click;
            //item.Tag = Commands.SetBingApiKey;

            root.Popup += root_DropDownOpening;
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
