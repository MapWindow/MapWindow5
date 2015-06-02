using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class PointIconControl : UserControl
    {
        private const string DefaultIconCollection = "events";
        private IGeometryMarkerStyle _marker;

        public event Action SelectedIconChanged;
        public event Action ScaleChanged;

        public PointIconControl()
        {
            InitializeComponent();
        }

        public void Initialize(IGeometryMarkerStyle markerStyle)
        {
            if (markerStyle == null) throw new ArgumentNullException("markerStyle");

            _marker = markerStyle;

            FillCollectionCombo();

            chkScaleIcons.Checked = !NumericHelper.Equal(_marker.IconScaleX, 1.0) ||
                                    !NumericHelper.Equal(_marker.IconScaleY, 1.0);

            iconControl1.SelectionChanged += FireSelectedIconChanged;
            chkScaleIcons.CheckStateChanged += (s, e) => FireScaleChanged();
            cboIconCollection.SelectedIndexChanged += (s, e) => UpdateIconsList();

            RestoreSelectedIconCollection();
        }

        public string SelectedCollection
        {
            get { return cboIconCollection.Text; }
        }

        public string SelectedIconPath
        {
            get { return iconControl1.SelectedPath; }
        }

        public bool ScaleIcons
        {
            get { return chkScaleIcons.Checked; }
        }

        /// <summary>
        /// Fills the image combo with the names of icons collectins (folders) 
        /// </summary>
        public void FillCollectionCombo()
        {
            cboIconCollection.Items.Clear();

            cboIconCollection.Enabled = false;
            chkScaleIcons.Enabled = false;

            var path = ResourceHelper.GetIconsPath();

            var folders = GetIconFolders(path);
            if (folders == null || folders.Length == 0)
            {
                return;
            }

            foreach (string folder in folders)
            {
                if (Directory.GetFiles(folder).Any(item => item.ToLower().EndsWith(".png")))
                {
                    string name = folder.Substring(path.Length);
                    cboIconCollection.Items.Add(name);
                }
            }

            bool enabled = cboIconCollection.Items.Count > 0;
            cboIconCollection.Enabled = enabled;
            chkScaleIcons.Enabled = enabled;
        }

        private string[] GetIconFolders(string path)
        {
            if (!Directory.Exists(path))
            {
                Logger.Current.Warn("Haven't found icons folder: " + path);
                return null;
            }

            var directories = Directory.GetDirectories(path);

            if (directories.Length <= 0)
            {
                Logger.Current.Warn("No subfolders in the icons folder: " + path);
            }

            return directories;
        }

        /// <summary>
        /// Sets the selected icon collection.
        /// </summary>
        private void RestoreSelectedIconCollection()
        {
            string iconCollection = DefaultIconCollection;
            string filename = string.Empty;
            
            var icon = _marker.Icon;
            if (icon != null)
            {
                string path = ResourceHelper.GetIconsPath();
                
                filename = icon.Filename;
                if (File.Exists(filename))
                {
                    string name = Path.GetDirectoryName(filename);
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        iconCollection = name.Substring(path.Length);
                    }
                }
            }

            foreach (var item in cboIconCollection.Items)
            {
                if (item.ToString().EqualsIgnoreCase(iconCollection))
                {
                    cboIconCollection.SelectedItem = item;

                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        iconControl1.SelectedPath = filename;
                    }
                    break;
                }
            }

            if (cboIconCollection.SelectedIndex == -1)
            {
                cboIconCollection.SelectedIndex = 0;
            }
        }

        private void UpdateIconsList()
        {
            var path = ResourceHelper.GetIconsPath() + cboIconCollection.Text;

            iconControl1.ChooseIconCellSize(path);

            UpdateCopyrightMessage(path);

            iconControl1.FilePath = path;
        }

        private void UpdateCopyrightMessage(string path)
        {
            lblCopyright.Text = "";

            string filename = path + @"\copyright.txt";
            if (!File.Exists(filename))
            {
                return;
            }

            using (var reader = new StreamReader(filename))
            {
                lblCopyright.Text = reader.ReadLine();
            }
        }

        private void FireScaleChanged()
        {
            var handler = ScaleChanged;
            if (handler != null)
            {
                handler();
            }
        }

        private void FireSelectedIconChanged()
        {
            var handler = SelectedIconChanged;
            if (handler != null)
            {
                handler();
            }
        }
    }
}
