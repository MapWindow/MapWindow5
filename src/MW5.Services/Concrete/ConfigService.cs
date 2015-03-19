using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Utility;

namespace MW5.Services.Concrete
{
    internal class ConfigService: IConfigService
    {
        private readonly IPluginManager _manager;
        private readonly IMessageService _messageService;
        private static AppSettings _settings;
        private List<Guid> _applicationPlugins;

        public ConfigService(IPluginManager manager, IMessageService messageService)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (messageService == null) throw new ArgumentNullException("messageService");
            
            _manager = manager;
            _messageService = messageService;

            _settings = new AppSettings();
        }

        public AppSettings Settings
        {
            get { return _settings; }
        }

        public IEnumerable<Guid> ApplicationPlugins
        {
            get { return _applicationPlugins; }
        }

        public string ConfigPath
        {
            get { return PathHelper.GetConfigPath(); }
        }

        public bool Save()
        {
            try
            {
                using (var stream = new StreamWriter(PathHelper.GetConfigFilePath(), false))
                {
                    string state = GetXmlConfig().Serialize(false);
                    stream.Write(state);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _messageService.Info("Failed to save app config: " + ex.Message);
            }
            return false;
        }

        public bool Load()
        {
            string path = PathHelper.GetConfigFilePath();
            if (!File.Exists(path))
            {
                return false;
            }

            try
            {
                XmlConfig xmlConfig;
                using (var stream = new StreamReader(path, Encoding.UTF8))
                {
                    string state = stream.ReadToEnd();
                    xmlConfig = state.Deserialize<XmlConfig>();
                    stream.Close();
                }

                ApplyXmlConfig(xmlConfig);
                return true;
            }
            catch(Exception ex)
            {
                _messageService.Info("Failed to save app settings: " + ex.Message);
            }
            return false;
        }

        private XmlConfig GetXmlConfig()
        {
            var xmlConfig = new XmlConfig { Settings = _settings };

            var plugins = _manager.ApplicationPlugins.Select(p => new XmlPlugin()
            {
                Guid = p.Identity.Guid,
                Name = p.Identity.Name
            });
            xmlConfig.ApplicationPlugins = plugins.ToList();
            return xmlConfig;
        }

        private void ApplyXmlConfig(XmlConfig xmlConfig)
        {
            _settings = xmlConfig.Settings;
            _applicationPlugins = xmlConfig.ApplicationPlugins.Select(p => p.Guid).ToList();
        }
    }
}
