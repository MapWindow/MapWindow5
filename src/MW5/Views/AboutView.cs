using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Controls;
using MW5.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class AboutView : MapWindowView, IAboutView
    {
        public AboutView()
        {
            InitializeComponent();

            InitControls();

            ShowVersions();

            cboAssemblyFilter.SelectedIndexChanged += (s, e) => Invoke(AssemblyFilterChanged);
        }

        private string GetArchitectureName(ProcessorArchitecture type)
        {
            switch (type)
            {
                case ProcessorArchitecture.MSIL:
                    return "Any CPU";
                case ProcessorArchitecture.X86:
                    return "x86";
                case ProcessorArchitecture.Amd64:
                    return "x64";
                case ProcessorArchitecture.IA64:
                case ProcessorArchitecture.Arm:
                case ProcessorArchitecture.None:
                default:
                    return string.Empty;
            }
        }

        private void ShowVersions()
        {
            var asm = Assembly.GetExecutingAssembly();

            var name = asm.GetName();

            var cpu = GetArchitectureName(name.ProcessorArchitecture);

            lblVersion.Text = string.Format("MapWindow version: {0} {1}", name.Version, cpu);
            lblGdalVersion.Text = "GDAL version: " + MapConfig.GdalVersion;
        }

        private void InitControls()
        {
            cboAssemblyFilter.AddItemsFromEnum<AssemblyFilter>();
            cboAssemblyFilter.SetValue(AssemblyFilter.All);
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true
                };
            }
        }

        public string OcxVersion
        {
            set { lblOcxVersion.Text = "MapWinGIS version: " + value; }
        }

        public List<AssemblyInfo> Assemblies
        {
            set { assembliesGrid1.DataSource = value; }
        }

        public AssemblyFilter AssemblyFilter
        {
            get { return cboAssemblyFilter.GetValue<AssemblyFilter>(); }
            set { cboAssemblyFilter.SetValue(value); }
        }

        public event Action AssemblyFilterChanged;

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }
}
