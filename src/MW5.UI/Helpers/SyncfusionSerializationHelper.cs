// -------------------------------------------------------------------------------------------
// <copyright file="SyncfusionSerializationHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using MW5.Plugins.Helpers;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Enums;
using Syncfusion.Runtime.Serialization;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Helpers
{
    /// <summary>
    /// Serializes / deserializes the state of dock panels and toolbars to / from the disk.
    /// </summary>
    public static class SyncfusionSerializationHelper
    {
        /// <summary>
        /// Tries to restore previous layout. Saves initial layout if it fails to find any previous state.
        /// </summary>
        public static void TryRestoreLayout(this DockingManager dockingManager, string key)
        {
            if (SyncfusionSerializationType.DockPanel.IsStartup(key))
            {
                dockingManager.SaveLayout(key, true);
            }
            else
            {
                dockingManager.RestoreLayout(key, false);
            }
        }
        
        /// <summary>
        /// Tries to restore previous layout. Saves initial layout if it fails to find any previous state.
        /// </summary>
        public static void TryRestoreLayout(this MainFrameBarManager mainFrameBarManager, string key)
        {
            if (SyncfusionSerializationType.ToolBar.IsStartup(key))
            {
                mainFrameBarManager.SaveLayout(key, true);
            }
            else
            {
                mainFrameBarManager.RestoreLayout(key, false);
            }
        }

        private static bool IsStartup(this SyncfusionSerializationType type, string key)
        {
            string path = GetFullPath(type, key, true);
            if (File.Exists(path))
            {
                return false;
            }

            path = GetFullPath(type, key, true);
            return !File.Exists(path);
        }

        public static void RestoreLayout(this DockingManager dockingManager, string key, bool startup)
        {
            try
            {
                var sr = GetSerializer(SyncfusionSerializationType.DockPanel, key, startup);

                string path = sr.GetPath();

                if (!File.Exists(path))
                {
                    if (startup)
                    {
                        MessageService.Current.Warn("File with initial state of panels wasn't found: " + path);
                    }

                    return;
                }

                if (!dockingManager.LoadDockState(sr))
                {
                    const string msg = "Failed to restore the state of dock panels.";
                    Logger.Current.Warn(msg);

                    if (startup)
                    {
                        MessageService.Current.Info(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to restore layout of dock panels.", ex);
            }
        }

        public static void RestoreLayout(this MainFrameBarManager manager, string key, bool startup)
        {
            try
            {
                var sr = GetSerializer(SyncfusionSerializationType.ToolBar, key, startup);

                string path = sr.GetPath();

                if (startup && !File.Exists(path))
                {
                    MessageService.Current.Warn("File with initial state of toolbars wasn't found: " + path);
                    return;
                }

                manager.LoadBarState(sr);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to restore layout of toolbars.", ex);
            }
        }

        public static void SaveLayout(this DockingManager dockingManager, string key, bool startup)
        {
            try
            {
                var sr = GetSerializer(SyncfusionSerializationType.DockPanel, key, startup);
                dockingManager.SaveDockState(sr);
                sr.PersistNow();
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to save layout of dock panels.", ex);
            }
        }

        public static void SaveLayout(this MainFrameBarManager manager, string key, bool startup)
        {
            try
            {
                var sr = GetSerializer(SyncfusionSerializationType.ToolBar, key, startup);
                manager.SaveBarState(sr);
                sr.PersistNow();
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to save layout of toolbars.", ex);
            }
        }

        private static string GetBasePath(SyncfusionSerializationType type)
        {
            switch (type)
            {
                case SyncfusionSerializationType.DockPanel:
                    return ConfigPathHelper.GetDockingConfigPath();
                case SyncfusionSerializationType.ToolBar:
                    return ConfigPathHelper.GetToolbarConfigPath();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        private static string GetFullPath(SyncfusionSerializationType type, string key, bool startup)
        {
            return GetPathCore(type, key, startup) + ".xml";
        }

        private static string GetPath(this AppStateSerializer serializer)
        {
            string path = serializer.SerializationPath as string ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(path))
            {
                path += ".xml";
            }

            return path;
        }

        private static string GetPathCore(SyncfusionSerializationType type, string key, bool startup)
        {
            string path = GetBasePath(type);

            if (!PathHelper.CreateFolder(path))
            {
                return string.Empty;
            }

            path += key;

            if (startup)
            {
                path += "_startup";
            }

            return path;
        }

        private static AppStateSerializer GetSerializer(SyncfusionSerializationType type, string key, bool startup)
        {
            string path = GetPathCore(type, key, startup);
            
            return new AppStateSerializer(SerializeMode.XMLFile, path);
        }
    }
}