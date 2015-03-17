using System;
using System.Collections.Generic;
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
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins
{
    internal class PluginBroadcaster : IBroadcasterService
    {
        private readonly PluginManager _manager;
        private readonly Dictionary<string, FieldInfo> _fields = new Dictionary<string,FieldInfo>();

        public PluginBroadcaster(PluginManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("Plugins manager is null.");
            }
            _manager = manager;

            _manager.PluginItemClicked += manager_PluginItemClicked;
        }

        private void manager_PluginItemClicked(object sender, MenuItemEventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                BroadcastEvent(p => p.ItemClicked_, sender, e, item.PluginIdentity);
            }
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
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, null);
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

        private void BroadcastEvent<T>(MemberExpression expression, object sender, T args, PluginIdentity identity)
            where T : EventArgs
        {
            if (expression == null)
            {
                return;
            }
            
            string eventName = expression.Member.Name;

            var fieldInfo = GetEventField(eventName);
            if (fieldInfo != null)
            {
                foreach (var p in _manager.ActivePlugins)
                {
                    if (identity != null && p.Identity != identity)
                    {
                        continue;   // it's a wrong target
                    }

                    var del = fieldInfo.GetValue(p) as MulticastDelegate;
                    if (del != null)
                    {
                        if (del.GetInvocationList().Any())
                        {
                            del.Method.Invoke(del.Target, new object[] { sender, args });
                        }
                    }
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
    }
}
