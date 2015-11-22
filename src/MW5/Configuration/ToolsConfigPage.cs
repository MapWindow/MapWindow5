using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.UI.Controls;

namespace MW5.Configuration
{
    public partial class ToolsConfigPage : ConfigPageBase, IConfigPage
    {
        public ToolsConfigPage()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return "Settings of geoprocessing and measuring tools."; }
        }

        public Bitmap Icon
        {
            get { return Resources.img_tools32; }
        }

        public string PageName
        {
            get { return "Tools"; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.Tools; }
        }

        /// <summary>
        /// Gets a value indicating whether the page height can be adjusted to fit the the parent.
        /// </summary>
        public bool VariableHeight 
        {
            get { return true; } 
        }

        public void Initialize()
        {
            
        }

        public void Save()
        {

        }
    }
}
