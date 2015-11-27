using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Services
{
    public interface IConfigService
    {
        void SaveAll();
        void LoadAll();
        bool SaveConfig();
        bool LoadConfig();
        AppConfig Config { get; }
        string ConfigPath { get; }
    }
}
