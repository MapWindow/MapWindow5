using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins
{
    internal class PluginBroadcaster : IBroadcasterService
    {
        private readonly IPluginManager _manager;
        private readonly Dictionary<string, FieldInfo> _fields = new Dictionary<string,FieldInfo>();
        private readonly Guid _symbologyPluginGuid = new Guid("7B9DF651-4B8B-4AA8-A4A9-C1463A35DAC7");

        public event EventHandler<MenuItemEventArgs> MenuItemClicked;
        public event EventHandler<MenuItemEventArgs> StatusItemClicked;

        private static IBroadcasterService _instance;
        public static IBroadcasterService Instance
        {
            get { return _instance; }
        }

        public PluginBroadcaster(IPluginManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("Plugins manager is null.");
            }
            _manager = manager;

            _instance = this;
        }

        /// <summary>
        /// Broadcasts map event to all the listening plugins.
        /// </summary>
        /// <param name="eventHandler">Event of the BasePlugin class to fire, lambda like "p => p.EventName_" should be used.</param>
        /// <param name="sender">Map reference.</param>
        /// <param name="args">Event arguments</param>
        public void BroadcastEvent<T>(Expression<Func<BasePlugin, MapEventHandler<T>>> eventHandler, IMuteMap sender, T args)
            where T: EventArgs
        {
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, null);
        }

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, LegendEventHandler<T>>> eventHandler, IMuteLegend sender, T args) where T : EventArgs
        {
            // symbology plugin is the default listener for legend generated events
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, null, _symbologyPluginGuid);
        }

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args)
            where T : EventArgs
        {
           BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, null);        
        }

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args, PluginIdentity identity)
            where T : EventArgs
        {
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, identity);
        }

        /// <summary>
        /// Returns list of active plugins with default handler in the last position. 
        /// </summary>
        private List<BasePlugin> GetActiveList(Guid? defaultHandler)
        {
            var handler = defaultHandler != null ? _manager.ListeningPlugins.FirstOrDefault(p => p.Identity.Guid == defaultHandler) : null;

            var plugins = handler == null ? _manager.ListeningPlugins : _manager.ListeningPlugins.Where(p => p != handler);
            var list = plugins.ToList();

            if (handler != null)
            {
                list.Add(handler);
            }
            return list;
        }

        private void BroadcastEvent<T>(MemberExpression expression, object sender, T args, PluginIdentity identity, Guid? defaultHandler = null)
            where T : EventArgs
        {
            if (expression == null)
            {
                return;
            }
            
            string eventName = expression.Member.Name;

            bool IsCancelled() => (
                (args is ICancellableEvent bargs && bargs.Cancel) ||
                (args is CancelEventArgs cargs && cargs.Cancel)
            );
            bool StopBubbling() => (
                (args is SingleTargetEventArgs sargs && sargs.Handled) || IsCancelled()
            );

            var fieldInfo = GetEventField(eventName);
            if (fieldInfo != null)
            {
                var list = GetActiveList(defaultHandler);

                foreach (var p in list)
                {
                    if (identity != null && p.Identity != identity)
                    {
                        continue;   // it's a wrong target
                    }

                    var del = fieldInfo.GetValue(p) as MulticastDelegate;
                    if (del != null)
                    {
                        var invlst = del.GetInvocationList();
                        foreach (var adel in invlst)
                        {
                            adel.Method.Invoke(adel.Target, new[] { sender, args });
                            if (StopBubbling())
                                break;
                        }
                    }
                    if (StopBubbling())
                        break;
                }
            }
        }

        /// <summary>
        /// Returns cached field for particular event.
        /// </summary>
        private FieldInfo GetEventField(string eventName)
        {
            if (!_fields.ContainsKey(eventName))
            {
                var fieldInfo = typeof(BasePlugin).GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
                _fields.Add(eventName, fieldInfo);
                return fieldInfo;
            }

            return _fields[eventName];
        }

        private void BroadcastPluginItemClicked(object sender, MenuItemEventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                BroadcastEvent(p => p.ItemClicked_, sender, e, item.PluginIdentity);
            }
        }

        public void FireItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = MenuItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    BroadcastPluginItemClicked(sender, args);
                }
            }
        }

        public void FireStatusItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = StatusItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    BroadcastPluginItemClicked(sender, args);
                }
            }
        }
    }
}
