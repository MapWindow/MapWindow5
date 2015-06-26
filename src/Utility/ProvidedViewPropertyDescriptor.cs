using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Equin.ApplicationFramework
{
    class ProvidedViewPropertyDescriptor<T> : PropertyDescriptor
    {
        public ProvidedViewPropertyDescriptor(string name, Type propertyType)
            : base(name, null)
        {
            _propertyType = propertyType;
        }

        private Type _propertyType;

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return typeof(ObjectView<T>); }
        }

        public override object GetValue(object component)
        {
            if (ComponentType.IsAssignableFrom(component.GetType()))
            {
                return (component as ObjectView<T>).GetProvidedView(Name);
            }

            throw new ArgumentException("Type of component is not valid.", "component");
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override Type PropertyType
        {
            get { return _propertyType; }
        }

        public override void ResetValue(object component)
        {
            throw new NotSupportedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotSupportedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public static bool CanProvideViewOf(PropertyDescriptor prop)
        {
            Type listTypeDef = typeof(IList<object>).GetGenericTypeDefinition();
            Type propType = prop.PropertyType;
            Type[] args = propType.GetGenericArguments();
            // Is this a generic type, with only one generic parameter.
            if (args.Length == 1)
            {
                // Create type IList<T> where T is args[0]
                Type listType = listTypeDef.MakeGenericType(args);
                // Check if the property type implements IList<T>
                // but is not an IBindingListView (or better).
                if (listType.IsAssignableFrom(propType) && !typeof(IBindingListView).IsAssignableFrom(propType))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
