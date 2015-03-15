using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization.Utility;

namespace MW5.Services.Concrete
{
    internal class ConfigService: IConfigService
    {
        private readonly IMessageService _messageService;
        private static AppConfig _config;

        public ConfigService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public AppConfig Config
        {
            get { return _config; }
        }

        public bool Save()
        {
            try
            {
                if (_config != null)
                {
                    using (var stream = new StreamWriter(PathHelper.GetSettingsPath(), false))
                    {
                        string state = _config.Serialize();
                        stream.Write(state);
                        stream.Flush();
                        stream.Close();
                        return true;
                    }
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
            if (File.Exists(PathHelper.GetSettingsPath()))
            {
                try
                {
                    using (var stream = new StreamReader(PathHelper.GetSettingsPath(), Encoding.UTF8))
                    {
                        string state = stream.ReadToEnd();
                        _config = state.Deserialize<AppConfig>();
                        stream.Close();
                        return true;
                    }
                }
                catch(Exception ex)
                {
                    _messageService.Info("Failed to save app settings: " + ex.Message);
                }
            }
            return false;
        }
    }
}
