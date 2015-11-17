using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Model;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Tiles.Services
{
    public class TmsImporter
    {
        private readonly IFileDialogService _dialogService;
        private readonly IRepository _repository;

        public TmsImporter(IFileDialogService dialogService, IRepository repository)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            if (repository == null) throw new ArgumentNullException("repository");
            _dialogService = dialogService;
            _repository = repository;
        }

        public void ImportTms()
        {
            string filename;
            if (_dialogService.Open("*.xml|*.xml", out filename))
            {
                try
                {
                    string xml = File.ReadAllText(filename);

                    var imagery = xml.DeserializeFromXml<imagery>();

                    AddProviders(imagery);
                }
                catch (Exception ex)
                {
                    Logger.Current.Info("Failed to import TMS providers from XML file.", ex);
                }
            }
        }

        private void AddProviders(imagery imagery)
        {
            var ids = new HashSet<int>(_repository.TmsProviders.Select(p => p.Id));
            var urls = new HashSet<string>(_repository.TmsProviders.Select(p => p.Url));

            foreach (var entry in imagery.entry)
            {
                var provider = ProviderFromEntry(entry);
                if (provider != null)
                {
                    if (ids.Contains(provider.Id) || urls.Contains(provider.Url))
                    {
                        Logger.Current.Info("TMS import: provider with duplicate id / url skipped.");
                    }
                    else
                    {
                        _repository.TmsProviders.Add(provider);
                    }
                }
            }
        }

        private TmsProvider ProviderFromEntry(imageryEntry entry)
        {
            if (entry.type != type.tms) return null;

            var provider = new TmsProvider
                               {
                                   Url = entry.url,
                                   Id = TmsProvider.GenerateId(entry.url),
                                   Projection = Api.Enums.TileProjection.SphericalMercator,
                                   Name = entry.name.Value,
                               };

            if (entry.bounds != null)
            {
                provider.Bounds = new Envelope((double)entry.bounds.minlon, (double)entry.bounds.maxlon,
                    (double)entry.bounds.minlat, (double)entry.bounds.maxlat);

                provider.UseBounds = true;
            }

            return provider;
        }
    }
}
