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

namespace MW5.UI.Controls
{
    public partial class ConfigPageBase : UserControl
    {
        public ConfigPageBase()
        {
            InitializeComponent();
        }

        public virtual ConfigPageType ParentPage
        {
            get { return ConfigPageType.None; }
        }

        /// <summary>
        /// Gets or sets the index of the image (used internally).
        /// </summary>
        public int ImageIndex { get; set; }

        public Size OriginalSize { get; set; }
    }
}
