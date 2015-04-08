﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Utility;

namespace MW5.Services.Concrete
{
    internal class ConfigService: IConfigService
    {
        private readonly IPluginManager _manager;
        private readonly IRepository _repository;
        private AppConfig _config;
        private List<Guid> _applicationPlugins;

        public ConfigService(IPluginManager manager, IRepository repository)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (repository == null) throw new ArgumentNullException("repository");

            _manager = manager;
            _repository = repository;

            _config = new AppConfig();
        }

        public AppConfig Config
        {
            get { return _config; }
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
                MessageService.Current.Info("Failed to save app config: " + ex.Message);
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
                MessageService.Current.Info("Failed to save app settings: " + ex.Message);
            }
            return false;
        }

        private XmlConfig GetXmlConfig()
        {
            var xmlConfig = new XmlConfig { Settings = _config };

            var plugins = _manager.ApplicationPlugins.Select(p => new XmlPlugin()
            {
                Guid = p.Identity.Guid,
                Name = p.Identity.Name
            });
            xmlConfig.ApplicationPlugins = plugins.ToList();

            xmlConfig.Repository = new XmlRepository(_repository);

            return xmlConfig;
        }

        private void ApplyXmlConfig(XmlConfig xmlConfig)
        {
            _config = xmlConfig.Settings;
            _applicationPlugins = xmlConfig.ApplicationPlugins.Select(p => p.Guid).ToList();

            if (xmlConfig.Repository != null)
            {
                foreach (var item in xmlConfig.Repository.Folders)
                {
                    _repository.AddFolderLink(item);
                }
            }
        }
    }
}
