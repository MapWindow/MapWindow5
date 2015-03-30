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
        bool Save();
        bool Load();
        AppConfig Config { get; }
        IEnumerable<Guid> ApplicationPlugins { get; }
        string ConfigPath { get; }
    }
}
