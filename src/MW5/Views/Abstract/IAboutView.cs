using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Controls;
using MW5.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    public interface IAboutView: IView
    {
        string OcxVersion { set; }
        List<AssemblyInfo> Assemblies { set; }
        AssemblyFilter AssemblyFilter { get; set; }
        event Action AssemblyFilterChanged;
    }
}
