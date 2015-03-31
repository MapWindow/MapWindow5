using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.UI.Helpers;

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
                appContext.PluginManager.StatusItemClicked += PluginManager_MenuItemClicked;
            }
        }

        private void InitStatusBar()
        {
            var bar = _context.StatusBar;

            var dropDown = bar.Items.AddDropDown("Not defined", StatusBarKeys.ProjectionDropDown, PluginIdentity.Default);
            dropDown.Icon = new MenuIcon(Resources.icon_crs_change);

            var items = dropDown.SubItems;
            items.AddButton("Choose projection", StatusBarKeys.ChooseProjection, PluginIdentity.Default);
            
            var item = items.AddDropDown("Absense behavior", StatusBarKeys.ProjAbsenseBehavior, PluginIdentity.Default);
            item.SubItems.AddButton("Assign from project", StatusBarKeys.ProjAbsenseAssign, PluginIdentity.Default);
            item.SubItems.AddButton("Ignore the absense", StatusBarKeys.ProjAbsenseIgnore, PluginIdentity.Default);
            item.SubItems.AddButton("Skip the file", StatusBarKeys.ProjAbsenseSkip, PluginIdentity.Default);
            item.BeginGroup = true;

            items.AddDropDown("Mismatch behavior", StatusBarKeys.ProjMismatchBehavior, PluginIdentity.Default);
            items.AddButton("Show loading report", StatusBarKeys.ProjShowLoadingReport, PluginIdentity.Default);
            items.AddButton("Show warnings", StatusBarKeys.ProjShowWarnings, PluginIdentity.Default);
            
            items.AddButton("Projection properties", StatusBarKeys.ProjectionProperties, PluginIdentity.Default).BeginGroup = true;

            dropDown.Update();

            bar.Items.AddLabel("Selected: ", StatusBarKeys.SelectedCount, PluginIdentity.Default).BeginGroup = true;

            bar.AlignNewItemsRight = true;
            bar.Items.AddLabel("Tile provider", StatusBarKeys.TileProvider, PluginIdentity.Default);
            
            var progressMsg = bar.Items.AddLabel("Progress", StatusBarKeys.ProgressMsg, PluginIdentity.Default);
            progressMsg.BeginGroup = true;
            progressMsg.Visible = false;

            bar.Items.AddProgressBar(StatusBarKeys.ProgressBar, PluginIdentity.Default).Visible = false;

            bar.Update();
        }

        private void PluginManager_MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case StatusBarKeys.ProjectionProperties:
                    MessageService.Current.Info("About to show projection properties.");
                    break;
                case StatusBarKeys.ChooseProjection:
                    MessageService.Current.Info("About to choose projection.");
                    break;
                case StatusBarKeys.ProjAbsenseBehavior:
                case StatusBarKeys.ProjMismatchBehavior:
                    // do nothing
                    break;
                default:
                    MessageService.Current.Info("There is no handler for the item: " + e.ItemKey);
                    break;
            }
        }

        public void Update()
        {
            var bar = _context.StatusBar;
            var statusSelected = bar.FindItem(StatusBarKeys.SelectedCount, PluginIdentity.Default);

            if (_context.Map.Layers.SelectedLayer == null)
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

            var statusProvider = bar.FindItem(StatusBarKeys.TileProvider, PluginIdentity.Default);
            statusProvider.Text = _context.Map.TileProvider.EnumToString();
        }
    }
}
