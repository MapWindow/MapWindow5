// -------------------------------------------------------------------------------------------
// <copyright file="DataRepository.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Model;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Data.Repository
{
    /// <summary>
    /// A model for repository dock panel
    /// </summary>
    public class DataRepository : IRepository
    {
        private readonly IGeoDatabaseService _databaseService;
        private readonly IFileDialogService _fileDialogService;
        private List<DatabaseConnection> _connections;
        private List<TmsProvider> _defaultTmsProviders;
        private List<string> _folders;
        private BindingList<WmsServer> _wmsServers;

        public DataRepository(IGeoDatabaseService databaseService, IFileDialogService fileDialogService)
        {
            Logger.Current.Trace("In DataRepository");
            if (databaseService == null) throw new ArgumentNullException("databaseService");

            _databaseService = databaseService;
            _fileDialogService = fileDialogService;

            Init();
        }

        public event EventHandler<FolderEventArgs> FolderAdded;

        public event EventHandler<FolderEventArgs> FolderRemoved;

        public event EventHandler<ConnectionEventArgs> ConnectionAdded;

        public event EventHandler<ConnectionEventArgs> ConnectionRemoved;

        public void PrepareToSave()
        {
            DelegateHelper.FireEvent(this, BeforeSaved);
        }

        public List<string> ExpandedFolders { get; private set; }

        public void Initialize(IAppContext context)
        {
            AddDefautlTmsProviders(context);

            if (AppConfig.Instance.FirstRun)
            {
                AddRootFolders();
            }
        }

        public RepositoryGroupList TmsGroups { get; private set; }

        public IEnumerable<string> Folders
        {
            get { return _folders; }
        }

        public IEnumerable<DatabaseConnection> Connections
        {
            get { return _connections; }
        }

        public IEnumerable<WmsServer> WmsServers
        {
            get { return _wmsServers; }
        }

        public TmsProviderList TmsProviders { get; private set; }

        public IEnumerable<TmsProvider> DefaultTmsProviders
        {
            get { return _defaultTmsProviders; }
        }

        public void AddFolderLink()
        {
            Logger.Current.Trace("In AddFolderLink");
            string path;
            if (_fileDialogService.ChooseFolder(string.Empty, out path))
            {
                AddFolderLink(path);
            }
        }

        public void AddFolderLink(string path)
        {
            if (!Directory.Exists(path) || HasFolder(path)) return;

            _folders.Add(path);
            FireEvent(FolderAdded, path);
        }

        public void RemoveFolderLink(string path, bool silent)
        {
            if (!HasFolder(path)) return;

            if (silent ||
                MessageService.Current.Ask("Do you want to remove a link to this folder from the repository?" +
                                           Environment.NewLine + "(The folder will remain intact on the disk.)"))
            {
                if (_folders.Remove(GetFolder(path)))
                {
                    FireEvent(FolderRemoved, path);
                }
            }
        }

        public void AddConnectionWithPrompt(GeoDatabaseType? databaseType = null)
        {
            Logger.Current.Trace("In AddConnectionWithPrompt");
            var connection = _databaseService.PromptUserForConnection(databaseType);
            if (connection != null)
            {
                AddConnection(connection);
            }
        }

        public void AddConnection(DatabaseConnection connection)
        {
            Logger.Current.Trace("In AddConnection");
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            _connections.Add(connection);
            FireEvent(ConnectionAdded, connection);
        }

        public void RemoveConnection(DatabaseConnection connection, bool silent)
        {
            if (!silent && _connections.Contains(connection))
            {
                if (!MessageService.Current.Ask("Do you want to remove database connection: " + connection.Name + "?"))
                {
                    return;
                }
            }

            _connections.Remove(connection);
            FireEvent(ConnectionRemoved, connection);
        }

        public void RemoveWmsServer(WmsServer server)
        {
            if (_wmsServers.Remove(server))
            {
                // TODO: fire event
            }
        }

        public void AddWmsServer(WmsServer server)
        {
            if (server != null)
            {
                // TODO: fire event
                _wmsServers.Add(server);
            }
        }

        public void UpdateWmsServer(WmsServer server)
        {
            int index = _wmsServers.IndexOf(server);
            if (index != -1)
            {
                _wmsServers[index] = server;
            }
        }

        public void ClearWmsServers()
        {
            _wmsServers.Clear();
        }

        public event EventHandler BeforeSaved;

        private void AddDefautlTmsProviders(IAppContext context)
        {
            Logger.Current.Trace("Start AddDefautlTmsProviders");
            foreach (var p in context.Map.Tiles.Providers.Where(p => !p.Custom))
            {
                if (p.Name.StartsWithIgnoreCase("google"))
                {
                    continue;
                }

                var provider = new TmsProvider
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       MinZoom = p.MinZoom,
                                       MaxZoom = p.MaxZoom,
                                       Bounds = p.GeographicBounds,
                                       IsCustom = false,
                                       Url = p.Url
                                   };

                _defaultTmsProviders.Add(provider);
            }
            Logger.Current.Trace("End AddDefautlTmsProviders");
        }

        private void AddRootFolders()
        {
            try
            {
                foreach (var d in DriveInfo.GetDrives())
                {
                    AddFolderLink(d.RootDirectory.FullName);
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to enumerate virtual drives on the machine.", ex);
            }
        }

        private void FireEvent(EventHandler<ConnectionEventArgs> handler, DatabaseConnection connection)
        {
            if (handler != null)
            {
                handler(this, new ConnectionEventArgs(connection));
            }
        }

        private void FireEvent(EventHandler<FolderEventArgs> handler, string path)
        {
            if (handler != null)
            {
                handler(this, new FolderEventArgs(path));
            }
        }

        private string GetFolder(string path)
        {
            return _folders.FirstOrDefault(f => f.EqualsIgnoreCase(path));
        }

        private bool HasFolder(string path)
        {
            return GetFolder(path) != null;
        }

        private void Init()
        {
            Logger.Current.Trace("Start DataRepository.Init()");
            _folders = new List<string>();

            ExpandedFolders = new List<string>();

            _connections = new List<DatabaseConnection>();

            _wmsServers = new BindingList<WmsServer>
                              {
                                  new WmsServer("Lizard Tech",
                                      "http://demo.lizardtech.com/lizardtech/iserv/ows")
                              };

            TmsProviders = new TmsProviderList();

            _defaultTmsProviders = new List<TmsProvider>();

            TmsGroups = new RepositoryGroupList
                            {
                                new RepositoryGroup(TmsProvider.DefaultGroupId, "Default"),
                                new RepositoryGroup(TmsProvider.CustomGroupId, "Custom")
                            };
            Logger.Current.Trace("End DataRepository.Init()");
        }
    }
}