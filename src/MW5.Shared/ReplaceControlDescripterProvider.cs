using System;
using System.ComponentModel;

namespace MW5.Shared
{
    /// <summary>
    /// Replaces control with another one in  designer. Helps to display designer 
    /// for the immediate descendants of abstract controls.
    /// </summary>
    /// <typeparam name="TAbstract">The type of the abstract.</typeparam>
    /// <typeparam name="TBase">The type of the base.</typeparam>
    /// <remarks>stackoverflow.com/questions/6817107/abstract-usercontrol-inheritance-in-visual-studio-designer    </remarks>
    public class ReplaceControlDescripterProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public ReplaceControlDescripterProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
