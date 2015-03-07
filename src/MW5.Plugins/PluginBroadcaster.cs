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
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins
{
    public class PluginBroadcaster
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
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args);
        }

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args)
            where T : EventArgs
        {
           BroadcastEvent(eventHandler.Body as MemberExpression, sender, args);        
        }

        private void BroadcastEvent<T>(MemberExpression expression, object sender, T args)
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
