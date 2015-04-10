using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MW5.Shared
{
    // The code copied from  http: //www.codeproject.com/Articles/103542/Removing-Event-Handlers-using-Reflection
    public static class EventHelper
    {
        private static readonly Dictionary<Type, List<FieldInfo>> DicEventFieldInfos = new Dictionary<Type, List<FieldInfo>>();

        static BindingFlags AllBindings
        {
            get
            {
                return BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic |
                       BindingFlags.Instance | BindingFlags.Static;
            }
        }

        private static List<FieldInfo> GetTypeEventFields(Type t)
        {
            if (DicEventFieldInfos.ContainsKey(t))
            {
                return DicEventFieldInfos[t];
            }

            List<FieldInfo> lst = new List<FieldInfo>();
            BuildEventFields(t, lst);
            DicEventFieldInfos.Add(t, lst);
            return lst;
        }

        private static void BuildEventFields(Type t, List<FieldInfo> lst)
        {
            // Type.GetEvent(s) gets all Events for the type AND it's ancestors
            // Type.GetField(s) gets only Fields for the exact type.
            //  (BindingFlags.FlattenHierarchy only works on PROTECTED & PUBLIC
            //   doesn't work because Fieds are PRIVATE)

            // NEW version of this routine uses .GetEvents and then uses .DeclaringType
            // to get the correct ancestor type so that we can get the FieldInfo.
            foreach (EventInfo ei in t.GetEvents(AllBindings))
            {
                Type dt = ei.DeclaringType;
                if (dt != null)
                {
                    FieldInfo fi = dt.GetField(ei.Name, AllBindings);
                    if (fi != null)
                    {
                        lst.Add(fi);
                    }
                }
            }
        }

        private static EventHandlerList GetStaticEventHandlerList(Type t, object obj)
        {
            MethodInfo mi = t.GetMethod("get_Events", AllBindings);
            return (EventHandlerList)mi.Invoke(obj, new object[] { });
        }

        public static void RemoveAllEventHandlers(object obj)
        {
            RemoveEventHandler(obj, "");
        }

        public static void RemoveEventHandler(object obj, string eventName)
        {
            if (obj == null)
            {
                return;
            }

            Type t = obj.GetType();
            List<FieldInfo> eventFields = GetTypeEventFields(t);
            EventHandlerList staticEventHandlers = null;

            foreach (FieldInfo fi in eventFields)
            {
                if (eventName != "" && string.Compare(eventName, fi.Name, true) != 0)
                {
                    continue;
                }

                // After hours and hours of research and trial and error, it turns out that
                // STATIC Events have to be treated differently from INSTANCE Events...
                if (fi.IsStatic)
                {
                    if (staticEventHandlers == null)
                    {
                        staticEventHandlers = GetStaticEventHandlerList(t, obj);
                    }

                    object idx = fi.GetValue(obj);
                    Delegate eh = staticEventHandlers[idx];
                    if (eh == null)
                    {
                        continue;
                    }

                    Delegate[] dels = eh.GetInvocationList();

                    EventInfo ei = t.GetEvent(fi.Name, AllBindings);
                    if (ei != null)
                    {
                        foreach (Delegate del in dels)
                        {
                            ei.RemoveEventHandler(obj, del);
                        }
                    }
                }
                else
                {
                    // instance event
                    EventInfo ei = t.GetEvent(fi.Name, AllBindings);
                    if (ei != null)
                    {
                        object val = fi.GetValue(obj);
                        Delegate mdel = (val as Delegate);

                        if (mdel != null)
                        {
                            foreach (Delegate del in mdel.GetInvocationList())
                            {
                                ei.RemoveEventHandler(obj, del);
                            }
                        }
                    }
                }
            }
        }
    }
}
