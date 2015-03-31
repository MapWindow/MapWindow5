using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.UI.Forms;
using MW5.Properties;
using MW5.UI.Helpers;

namespace MW5.Menu
{
    public class StatusBarListener
    {
        private readonly IAppContext _context;
        private readonly IConfigService _configService;

        public StatusBarListener(IAppContext context, IConfigService configService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (configService == null) throw new ArgumentNullException("configService");
            
            _context = context;
            _configService = configService;

            InitStatusBar();

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.PluginManager.StatusItemClicked += PluginManager_MenuItemClicked;
            }

            var map = context.Map as IMap;
            if (map == null)
            {
                throw new InvalidCastException("Map must implement IMap interface");
            }
            map.ProjectionChanged += MapProjectionChanged;
        }

        private void InitStatusBar()
        {
            var bar = _context.StatusBar;

            var dropDown = bar.Items.AddDropDown("Not defined", StatusBarKeys.ProjectionDropDown, Identity);
            dropDown.Icon = new MenuIcon(Resources.icon_crs_change);
            dropDown.DropDownOpening += ProjectionDropDownOpening;

            var items = dropDown.SubItems;
            items.AddButton("Choose projection", StatusBarKeys.ChooseProjection, Identity);
            
            var item = items.AddDropDown("Absense behavior", StatusBarKeys.AbsenseBehavior, Identity);
            item.SubItems.AddButton("Assign from project", StatusBarKeys.AbsenseAssign, Identity);
            item.SubItems.AddButton("Ignore the absense", StatusBarKeys.AbsenseIgnore, Identity);
            item.SubItems.AddButton("Skip the file", StatusBarKeys.AbsenseSkip, Identity);
            item.BeginGroup = true;

            item = items.AddDropDown("Mismatch behavior", StatusBarKeys.MismatchBehavior, Identity);
            item.SubItems.AddButton("Ignore mismatch", StatusBarKeys.MismatchIgnore, Identity);
            item.SubItems.AddButton("Reproject the file", StatusBarKeys.MismatchReproject, Identity);
            item.SubItems.AddButton("Skip the file", StatusBarKeys.MismatchSkip, Identity);

            items.AddButton("Show loading report", StatusBarKeys.ProjShowLoadingReport, Identity);
            items.AddButton("Show warnings", StatusBarKeys.ProjShowWarnings, Identity);
            
            items.AddButton("Projection properties", StatusBarKeys.ProjectionProperties, Identity).BeginGroup = true;

            dropDown.Update();

            bar.Items.AddLabel("Selected: ", StatusBarKeys.SelectedCount, Identity).BeginGroup = true;

            bar.AlignNewItemsRight = true;
            bar.Items.AddLabel("Tile provider", StatusBarKeys.TileProvider, Identity);
            
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
                case StatusBarKeys.ProjectionProperties:
                    _context.ShowProjectionProperties();
                    break;
                case StatusBarKeys.ChooseProjection:
                    _context.ChangeProjection();
                    break;
                case StatusBarKeys.AbsenseAssign:
                    Config.ProjectionAbsenceBehavior = ProjectionAbsenceBehavior.AssignFromProject;
                    break;
                case StatusBarKeys.AbsenseIgnore:
                    Config.ProjectionAbsenceBehavior = ProjectionAbsenceBehavior.IgnoreAbsence;
                    break;
                case StatusBarKeys.AbsenseSkip:
                    Config.ProjectionAbsenceBehavior = ProjectionAbsenceBehavior.SkipFile;
                    break;
                case StatusBarKeys.MismatchIgnore:
                    Config.ProjectionMismatchBehavior = ProjectionMismatchBehavior.IgnoreMismatch;
                    break;
                case StatusBarKeys.MismatchReproject:
                    Config.ProjectionMismatchBehavior = ProjectionMismatchBehavior.Reproject;
                    break;
                case StatusBarKeys.MismatchSkip:
                    Config.ProjectionMismatchBehavior = ProjectionMismatchBehavior.SkipFile;
                    break;
                case StatusBarKeys.ProjShowLoadingReport:
                    Config.ProjectionShowLoadingReport = !menuItem.Checked;
                    break;
                case StatusBarKeys.ProjShowWarnings:
                    Config.ProjectionShowWarnings = !menuItem.Checked;
                    break;
                case StatusBarKeys.AbsenseBehavior:
                case StatusBarKeys.MismatchBehavior:
                    // do nothing
                    break;
                default:
                    MessageService.Current.Info("There is no handler for the item: " + e.ItemKey);
                    break;
            }
        }

        private AppConfig Config
        {
            get { return _configService.Config; }
        }

        private PluginIdentity Identity
        {
            get { return PluginIdentity.Default; }
        }

        private void ProjectionDropDownOpening(object sender, EventArgs e)
        {
            var behavior = _configService.Config.ProjectionAbsenceBehavior;
            FindItem(StatusBarKeys.AbsenseAssign).Checked = behavior == ProjectionAbsenceBehavior.AssignFromProject;
            FindItem(StatusBarKeys.AbsenseIgnore).Checked = behavior == ProjectionAbsenceBehavior.IgnoreAbsence;
            FindItem(StatusBarKeys.AbsenseSkip).Checked = behavior == ProjectionAbsenceBehavior.SkipFile;

            var behavior2 = _configService.Config.ProjectionMismatchBehavior;
            FindItem(StatusBarKeys.MismatchIgnore).Checked = behavior2 == ProjectionMismatchBehavior.IgnoreMismatch;
            FindItem(StatusBarKeys.MismatchReproject).Checked = behavior2 == ProjectionMismatchBehavior.Reproject;
            FindItem(StatusBarKeys.MismatchSkip).Checked = behavior2 == ProjectionMismatchBehavior.SkipFile;

            FindItem(StatusBarKeys.ProjShowLoadingReport).Checked = _configService.Config.ProjectionShowLoadingReport;
            FindItem(StatusBarKeys.ProjShowWarnings).Checked = _configService.Config.ProjectionShowWarnings;
        }

        protected IMenuItem FindItem(string itemKey)
        {
            return _context.StatusBar.FindItem(itemKey, Identity);
        }

        public void Update()
        {
            var bar = _context.StatusBar;
            var statusSelected = bar.FindItem(StatusBarKeys.SelectedCount, Identity);

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

            var statusProvider = bar.FindItem(StatusBarKeys.TileProvider, Identity);
            statusProvider.Text = _context.Map.TileProvider.EnumToString();
        }

        private void MapProjectionChanged(object sender, EventArgs e)
        {
            var item = _context.StatusBar.FindItem(StatusBarKeys.ProjectionDropDown, Identity);
            var p = _context.Map.GeoProjection;
            item.Text = !p.IsEmpty ? p.Name : "Not defined";
        }
    }
}
